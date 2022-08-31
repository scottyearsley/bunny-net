namespace BunnyNet.Builders;

internal class SubscriberBuilder: ISubscriberBuilder
{
    private readonly SubscriberConfiguration _subscriberConfiguration = new();
    private readonly BunnyConfiguration _connectionConfiguration;

    public SubscriberBuilder(BunnyConfiguration configuration)
    {
        _connectionConfiguration = configuration;
    }
    
    public ISubscriberBuilder WithQueue(Queue queue)
    {
        _subscriberConfiguration.Queue = queue;
        return this;
    }

    public ISubscriberBuilder WithQueue(string name)
    {
        _subscriberConfiguration.Queue = new Queue(name);
        return this;
    }

    public ISubscriberBuilder WithExchange(Exchange exchange)
    {
        _subscriberConfiguration.Exchange = exchange;
        return this;
    }

    public ISubscriberBuilder WithExchange(string name)
    {
        _subscriberConfiguration.Exchange = new Exchange(name);
        return this;
    }

    public ISubscriberBuilder WithBindings(params string[] topics)
    {
        foreach (var topic in topics)
        {
            _subscriberConfiguration.Topics.Add(topic);
        }
        return this;
    }

    public ISubscriberBuilder WithPrefetchCount(int count)
    {
        _subscriberConfiguration.PrefetchCount = count;
        return this;
    }

    public ISubscriber Create()
    {
        return new Subscriber(_connectionConfiguration, _subscriberConfiguration);
    }
}