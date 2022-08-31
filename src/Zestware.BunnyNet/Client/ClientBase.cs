namespace BunnyNet;

internal abstract class ClientBase: IDisposable
{
    private readonly BunnyConfiguration _configuration;
    private IModel? _channel;
    private static readonly int[] RecoverableChannelReplyCodes = { 404, 406 };

    public ClientBase(BunnyConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    protected IModel Channel
    {
        get
        {
            // Don't recreate the channel unless it has been closed due to a request to an exchange/queue
            // that does not exist - something that may happen in MessagingModel
            // The official client will re-establish a channel if Rabbit goes down and then comes back up again,
            // so we don't want to fight that and risk duplications
            if (_channel == null || ChannelHasClosedAndCannotRecover(_channel.CloseReason))
            {
                EnsureChannelIsClosedAndDisposed();
                _channel = ConnectionPool.Get(_configuration).CreateModel();
                // _channel.ModelShutdown += (sender, args) =>
                // {
                //     if (args.ReplyCode != 200)
                //     {
                //         this.Log().Error(
                //             "The rabbit channel has been shut down", 
                //             LogContext.AddData(new { args = args.ToJson() }));
                //     }
                // };
            }

            return _channel;
        }
    }

    public void Dispose()
    {
    }
    
    protected void EnsureChannelIsClosedAndDisposed()
    {
        if (_channel == null)
        {
            return;
        }

        if (_channel.IsOpen)
        {
            _channel.Close();
        }
        _channel.Dispose();
        _channel = null;
    }
    
    private static bool ChannelHasClosedAndCannotRecover(ShutdownEventArgs shutdownEventArgs)
    {
        return shutdownEventArgs != null && !RecoverableChannelReplyCodes.Contains(shutdownEventArgs.ReplyCode);
    }
}