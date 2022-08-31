using BunnyNet.Builders;

namespace BunnyNet;

public class Bunny: IBunny
{
    private Bunny(BunnyConfiguration configuration)
    {
        Subscriber = new SubscriberOperations(configuration);
        Publisher = new PublisherOperations();
    }
    
    public static IBunny Configure(BunnyConfiguration configuration)
    {
        return new Bunny(configuration);
    }
    
    public PublisherOperations Publisher { get; }

    public ISubscriberOperations Subscriber { get; }

    /// <summary>
    /// Gets the number of active connections.
    /// </summary>
    public int ConnectionCount => ConnectionPool.ConnectionCount;
}