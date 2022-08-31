using System.Net;
using RabbitMQ.Client.Exceptions;
using Zestware;
using Zestware.Data;

namespace BunnyNet;

internal static class ConnectionPool
{
    private static readonly ReaderWriterLockSlim ConnectionLock = new();
    private static readonly Dictionary<string, IConnection> Connections = new();

    public static int ConnectionCount => Connections.Count;

    public static IConnection Get(BunnyConfiguration configuration)
    {
        // TODO: Review whether ConcurrentDictionary is better here (and simpler)
        string connectionHash;
        
        ConnectionLock.EnterReadLock();
        try
        {
            connectionHash = Hasher.XxHash(configuration.ToJson());

            if (Connections.ContainsKey(connectionHash))
            {
                return Connections[connectionHash];
            }
        }
        finally
        {
            ConnectionLock.ExitReadLock();
        }
        
        ConnectionLock.EnterWriteLock();
        try
        {
            if (Connections.ContainsKey(connectionHash))
            {
                return Connections[connectionHash];
            }

            var connection = Create(configuration);
            Connections[connectionHash] = connection;
            return connection;
        }
        finally
        {
            ConnectionLock.ExitWriteLock();
        }
    }

    private static IConnection Create(BunnyConfiguration configuration)
    {
        
        var factory = new ConnectionFactory
        {
            UserName = configuration.Username,
            Password = configuration.Password,
            VirtualHost = configuration.VirtualHost,
            AutomaticRecoveryEnabled = true,
            NetworkRecoveryInterval = TimeSpan.FromSeconds(5),
            TopologyRecoveryEnabled = true,
            DispatchConsumersAsync = true, // Allow async threads in the subscriber
            ClientProvidedName = $"{configuration.AppId} ({Dns.GetHostName()})",
            RequestedConnectionTimeout = configuration.Timeout,
            RequestedHeartbeat = TimeSpan.FromSeconds(60)
        };

        var initialConnectionAttemptDateTime = DateTime.Now;
        Exception? exception = null;

        // this.Log().Info("Attempting initial rabbit connection");

        while (DateTime.Now - initialConnectionAttemptDateTime < TimeSpan.FromMinutes(1))
        {
            try
            {
                var connection = factory.CreateConnection(configuration.Hosts.ToList());
                // connection.ConnectionBlocked += (sender, args) =>
                // {
                //     this.Log().Error("The rabbit connection has been blocked",
                //         LogContext.AddData(new { reason = args.Reason }));
                // };
                // connection.ConnectionShutdown += (sender, args) =>
                // {
                //     this.Log().Error("The rabbit connection has been shut down",
                //         LogContext.AddData(new { args = args.ToJson() }));
                // };
                // connection.ConnectionUnblocked += (sender, args) =>
                // {
                //     this.Log().Info("The rabbit connection has been unblocked");
                // };

                if (!connection.IsOpen)
                {
                    connection.Dispose();
                    throw new Exception("Connection created but not opened");
                }
                    
                return connection;
            }
            catch (BrokerUnreachableException e)
            {
                // this.Log().Error(
                //     $"Connection attempt failed - host(s) '{string.Join(",", Configuration.Hosts)}' unreachable");
                exception = e;
                Thread.Sleep(1000);
            }
            catch (Exception e)
            {
                // this.Log().Error(
                //     $"Connection attempt failed - " + e.Message);
                exception = e;
                Thread.Sleep(1000);
            }
        }

        throw exception!;
    }
}