namespace BunnyNet;

public class Exchange
{
    /// <summary>
    /// Represents an AMQP exchange.
    /// </summary>
    /// <param name="name">The name of the exchange.</param>
    /// <param name="type">The type of the exchange - see <see cref="ExchangeType"/>.</param>
    /// <param name="isDurable">Optional - if true, the exchange is durable. Defaults to true.</param>
    public Exchange(string name, ExchangeType type = ExchangeType.Topic, bool isDurable = true)
    {
        Name = name;
        Type = type;
        IsDurable = isDurable;
    }
    
    /// <summary>
    /// The name of the exchange.
    /// </summary>
    public string Name { get; }
        
    /// <summary>
    /// The exchange type.
    /// </summary>
    public ExchangeType Type { get; }

    /// <summary>
    /// The exchange durability (survives restart).
    /// </summary>
    public bool IsDurable { get; }

    public static implicit operator Exchange(string name) => new(name);
    
    /// <summary>
    /// This indicates internally whether the exchange is only named (presumed existing) 
    /// or full definition details have been specified.
    /// </summary>
    internal bool IsUndefined { get; set; }
}