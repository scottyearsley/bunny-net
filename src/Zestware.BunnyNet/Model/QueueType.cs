namespace BunnyNet;

/// <summary>
/// The queue type.
/// </summary>
public enum QueueType
{
    /// <summary>
    /// Classic (default)
    /// </summary>
    Classic,

    /// <summary>
    /// <see href="https://www.rabbitmq.com/quorum-queues.html">Quorum Queue</see>
    /// </summary>
    Quorum
}