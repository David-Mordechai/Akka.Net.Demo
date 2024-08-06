namespace Akka.Net.Demo;

internal class HelloActor : ReceiveActor
{
    private readonly ILoggingAdapter _logger = Context.GetLogger();
    private int _helloCounter;

    public HelloActor()
    {
        Receive<string>(message =>
        {
            _logger.Info("{0} {1}", message, _helloCounter++);
        });
    }
}