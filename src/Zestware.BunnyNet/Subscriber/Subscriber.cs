namespace BunnyNet;

internal class Subscriber: ClientBase, ISubscriber
{
    private readonly BunnyConfiguration _connectionConfiguration;
    private readonly SubscriberConfiguration _subscriberConfiguration;

    public Subscriber(
        BunnyConfiguration connectionConfiguration, 
        SubscriberConfiguration subscriberConfiguration)
        : base(connectionConfiguration)
    {
        _connectionConfiguration = connectionConfiguration;
        _subscriberConfiguration = subscriberConfiguration;
        _subscriberConfiguration.EnsureDefaults();
        
        //ConfigureErrorHandling(errorHandlingPolicy);
            
        // _errorPublisher = new LazyDisposable<MessagingPublisher>(() => 
        //     new MessagingPublisher(configuration, 
        //         new Exchange(MessagingModel.DefaultErrorExchange) { IsUndefined = true }));
    }
    
    public void Handle<T>(Func<Message<T>, Task<Result>> messageReceived)
    {
        QueueName = "wibble";
        throw new NotImplementedException();
    }

    public string? QueueName { get; private set; }
}