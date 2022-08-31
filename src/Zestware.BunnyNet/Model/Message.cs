namespace BunnyNet;

public class Message<T>
{
    public Message()
    {
    }

    public Message(T body, string topic)
    {
        Body = body;
        Topic = topic.ToLowerInvariant();
        Id = Guid.NewGuid();
    }
    
    /// <summary>
    /// The unique message identifier.
    /// </summary>
    public Guid Id { get; internal set; }
    
    /// <summary>
    /// The message data.
    /// </summary>
    public T Body { get; internal set; }
    
    /// <summary>
    /// The topic for the message (direct or topic).
    /// </summary>
    public string Topic { get; internal set; }
}