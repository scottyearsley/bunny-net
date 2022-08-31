namespace BunnyNet;

/// <summary>
/// The exchange type.
/// </summary>
public enum ExchangeType
{
    /// <summary>
    /// Topic AMQP exchange type.
    /// </summary>
    Topic,
        
    /// <summary>
    /// Fanout AMQP exchange type.
    /// </summary>
    Fanout,
        
    /// <summary>
    /// Direct AMQP exchange type.
    /// </summary>
    Direct,
        
    /// <summary>
    /// Headers AMQP exchange type.
    /// </summary>
    Headers
}