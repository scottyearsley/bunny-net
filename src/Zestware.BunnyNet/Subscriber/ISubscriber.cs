namespace BunnyNet;

public interface ISubscriber
{
    void Handle<T>(Func<Message<T>, Task<Result>> messageReceived);

    string? QueueName { get; }
}