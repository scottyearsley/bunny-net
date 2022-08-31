namespace Zestware.BunnyNet.Tests;

public class Connect
{
    [Fact]
    public void CreatePublisher()
    {
        var configuration = new BunnyConfiguration("ojn", "", "");
        var bunny = Bunny.Configure(configuration);
        var subscriber = bunny.Subscriber
            .ForWork()
            .WithExchange("")
            .WithQueue("")
            .WithBindings("sdc")
            .WithPrefetchCount(6)
            .Create();
        
        subscriber.Handle<Dictionary<string, string>>(async m =>
        {
            await HandleMessage(m);
            
            return Result.Ok();
        });
        
        

        bunny.Subscriber.Create(new SubscriberConfiguration
        {
            Queue = new Queue("tasks_work", QueueType.Quorum),
            Exchange = "tasks",
            Topics = new HashSet<string> { "tasks_daily"  }
        });
    }

    public Task HandleMessage(object message)
    {
        
        
        return Task.CompletedTask;
    }
}