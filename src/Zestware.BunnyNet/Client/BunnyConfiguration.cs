namespace BunnyNet;

/// <summary>
/// 
/// </summary>
public record BunnyConfiguration
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="host"></param>
    /// <param name="username"></param>
    /// <param name="password"></param>
    public BunnyConfiguration(string host, string username, string password)
    {
        Hosts = new[] { host };
        Username = username;
        Password = password;
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="hosts"></param>
    /// <param name="username"></param>
    /// <param name="password"></param>
    public BunnyConfiguration(IEnumerable<string> hosts, string username, string password)
    {
        Hosts = hosts;
        Username = username;
        Password = password;
    }

    public IEnumerable<string> Hosts { get; }

    public string Username { get; }
    
    public string Password { get; }

    /// <summary>
    /// The R
    /// </summary>
    public string VirtualHost { get; init; } = "/";
    
    /// <summary>
    /// The application identifier.
    /// </summary>
    public string AppId { get; set; } = AppDomain.CurrentDomain.FriendlyName;
        
    /// <summary>
    /// The host port number, defaulted to 5672.
    /// </summary>
    public ushort Port { get; set; } = 5672;
    
    /// <summary>
    /// The connection timeout.
    /// </summary>
    public TimeSpan Timeout { get; set; }
#if RELEASE
        = TimeSpan.FromSeconds(5);
#else
        = TimeSpan.FromMinutes(20);
#endif

    public string DefaultErrorExchangeName { get; set; } = "";
}