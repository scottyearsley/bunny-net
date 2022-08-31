namespace BunnyNet;

internal class TopologyModel: ClientBase
{
    private readonly BunnyConfiguration _configuration;

    public TopologyModel(BunnyConfiguration configuration)
        : base(configuration)
    {
        _configuration = configuration;
    }


    public void Dispose()
    {
    }
}