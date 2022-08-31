namespace BunnyNet;

public class SubscriberConfiguration
{
    public Exchange? Exchange { get; set; }
    
    public Queue? Queue { get; set; }

    public int PrefetchCount { get; set; } = 1;

    public HashSet<string> Topics { get; set; } = new();

    internal void EnsureDefaults()
    {
        Topics = Topics?.Count > 0 ? Topics : new HashSet<string> { "#" };
    }
}