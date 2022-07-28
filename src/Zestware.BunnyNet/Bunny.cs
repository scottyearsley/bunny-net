namespace BunnyNet;

public class Bunny: IBunny
{
    private readonly IConnection _connection;

    private Bunny(IConnection connection)
    {
        _connection = connection;
    }
    
    public static IBunny Connect(BunnyConfiguration configuration)
    {
        var connection = ConnectionPool.Get(configuration); 
        return new Bunny(connection);
    }

    IPublisher IBunny.CreatePublisher()
    {
        throw new NotImplementedException();
    }

    ISubscriber IBunny.CreateSubscriber(SubscriberDefaults defaults
    {
        throw new NotImplementedException();
    }
}

public interface IBunny
{
    IPublisher CreatePublisher();

    ISubscriber CreateSubscriber(string queueName, SubscriberDefaults defaults);
    
    ISubscriber CreateSubscriber(string queueName, SubscriberDefaults defaults);

    IModel CreateModel();
}

public interface SubscriberOptions
{
    
}



public enum SubscriberDefaults
{
    PubSub,
    Work
}

public class SubscriberOptions
{
    // Queuename
    // Retry, prefetch
}

public interface IPublisher
{

}

public interface ISubscriber
{

}

public interface IModel
{
    
}