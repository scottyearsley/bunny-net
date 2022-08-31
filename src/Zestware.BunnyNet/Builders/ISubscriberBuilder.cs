namespace BunnyNet.Builders;

public interface ISubscriberBuilder
{
    ISubscriberBuilder WithQueue(Queue queue);

    ISubscriberBuilder WithQueue(string name);

    ISubscriberBuilder WithExchange(Exchange exchange);

    ISubscriberBuilder WithExchange(string name);

    ISubscriberBuilder WithBindings(params string[] topics);

    ISubscriberBuilder WithPrefetchCount(int count);
    
    ISubscriber Create();
}