namespace Zestware.BunnyNet.Tests;

public class Connect
{
    [Fact]
    public void CreatePublisher()
    {
        var configuration = new BunnyConfiguration("ojn", "", "");
        
        var bunny = Bunny.Connect(configuration);
        var publisher = bunny.CreatePublisher();

    }
}