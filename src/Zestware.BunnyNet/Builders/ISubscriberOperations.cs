namespace BunnyNet.Builders;

public interface ISubscriberOperations
{
    ISubscriberBuilder ForWork();
    ISubscriberBuilder ForPubSub();
    ISubscriber Create(SubscriberConfiguration configuration);
}