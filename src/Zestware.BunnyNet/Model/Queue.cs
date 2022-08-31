namespace BunnyNet;

/// <summary>
/// Queue definition.
/// </summary>
public class Queue
{
    /// <summary>
    /// Creates a new queue instance.
    /// </summary>
    public Queue() { }

    public Queue(string name, QueueType queueType = QueueType.Classic)
    {
        Name = name;
        QueueType = queueType;
    }
    
    // TODO: Add more detail that the queue name will be auto-created if none supplied.
    /// <summary>
    /// The queue name.
    /// </summary>
    public string? Name { get; set; }
        
    /// <summary>
    /// Enables the queue to persist across restarts.
    /// </summary>
    public bool IsDurable { get; set; }
    
    /// <summary>
    /// The expiration time (TTL) for items on the queue.
    /// </summary>
    public TimeSpan? MessageTimeToLive { get; set; }

    /// <summary>
    /// The maximum size the queue can grow - FIFO.
    /// </summary>
    public int? MaxSize { get; set; }

    /// <summary>
    /// Auto delete the queue when all subscribers unsubscribe.
    /// </summary>
    public bool AutoDelete { get; set; }

    /// <summary>
    /// Declares the queue as a priority queue.
    /// </summary>
    public bool IsPrioritized { get; set; }

    /// <summary>
    /// Specifies the queue type.
    /// </summary>
    public QueueType QueueType { get; set; }

    /// <summary>
    /// Additional arguments declared for the queue.
    /// </summary>
    public Dictionary<string, object> Arguments { get; set; } = new ();
    // TODO: Consider creating a type instead of using object.

    /// <summary>
    /// If set to <c>true</c> and the existing queue parameters don't match this definition,
    /// then the queue will be deleted and redeclared.
    /// </summary>
    /// <remarks>WARNING: Will potentially delete the queue and all messages will be lost.</remarks>
    public bool AllowRedefinition { get; set; }
    
    /// <summary>
    /// TODO: Add comment
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static implicit operator Queue(string name) => new Queue(name);
    
    /// <summary>
    /// This indicates internally whether the queue is only named (presumed existing) 
    /// or full definition details have been specified.
    /// </summary>
    internal bool IsUndefined { get; set; }
}