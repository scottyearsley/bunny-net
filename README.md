# BunnyNet

## Motivation

blah, blah, blah

## Features
- Retry policy
  - Queue or inline
- Error queues
  - Default
  - Custom
- Connection pooling

## Best practices
- Separate connections for publishers and subscribers
- Prefetch counts for work and pub sub

## Examples

### Setup

```csharp
using BunnyNet;

var bunny = Bunny.Configure(new BunnyConfiguration("localhost", "guest", "guest"));
```

### Create subscriber (fluent)

```csharp
var subscriber = bunny.Subscriber
    .ForWork()
    .WithExchange("tasks")
    .WithQueue("tasks_work")
    .WithBindings("tasks.daily")
    .Create();
```

### Create subscriber (configuration)

```csharp
bunny.Subscriber.Create(new SubscriberConfiguration
{
    Queue = new Queue("tasks_work", QueueType.Quorum),
    Exchange = "tasks",
    Topics = new HashSet<string> { "tasks.daily"  }
});
```

### Handle messages

```csharp
subscriber.Handle<Dictionary<string, string>>(async m =>
{
    await DoWork(m);
    return Result.Ok();
});
```