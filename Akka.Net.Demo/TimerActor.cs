namespace Akka.Net.Demo;

internal class TimerActor : ReceiveActor, IWithTimers
{
    public TimerActor(IRequiredActor<HelloActor> helloActor)
    {
        var helloActorRef = helloActor.ActorRef;

        Receive<string>(message =>
        {
            helloActorRef.Tell(message);
        });
    }

    protected override void PreStart()
    {
        Timers.StartPeriodicTimer("hello-key", "hello", TimeSpan.FromSeconds(1));
    }

    public required ITimerScheduler Timers { get; set; }
}