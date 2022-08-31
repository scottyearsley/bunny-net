using BunnyNet.Builders;

namespace BunnyNet;

public interface IBunny
{
    PublisherOperations Publisher { get; }

    ISubscriberOperations Subscriber { get; }

    int ConnectionCount { get; }
}