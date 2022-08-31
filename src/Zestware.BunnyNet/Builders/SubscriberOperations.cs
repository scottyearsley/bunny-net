namespace BunnyNet.Builders;

internal class SubscriberOperations : ISubscriberOperations
{
    private readonly BunnyConfiguration _connectionConfiguration;

    public SubscriberOperations(BunnyConfiguration connectionConfiguration)
    {
        _connectionConfiguration = connectionConfiguration;
    }
    
    public ISubscriberBuilder ForWork()
    {
        var builder = new SubscriberBuilder(_connectionConfiguration);
        builder.WithPrefetchCount(1); // TODO: set globally?
        return builder;
    }
    
    public ISubscriberBuilder ForPubSub()
    {
        var builder = new SubscriberBuilder(_connectionConfiguration);
        builder.WithPrefetchCount(10); // TODO: set globally?
        return builder;
    }

    public ISubscriber Create(SubscriberConfiguration configuration)
    {
        return new Subscriber(_connectionConfiguration, configuration);
    }
}