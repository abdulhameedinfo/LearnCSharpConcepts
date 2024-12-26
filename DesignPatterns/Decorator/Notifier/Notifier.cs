public interface INotifier
{
    void Send(string message);
}

// Concrete class email notifier 
public class EmailNotifier : INotifier
{
    public void Send(string message)
    {
        System.Console.WriteLine($"Sending Email: {message}");
    }
}

// Base Decorator
public class NotifierDecorator : INotifier
{
    private INotifier _notifierService;
    public NotifierDecorator(INotifier notifierService)
    {
        _notifierService = notifierService;
    }

    public virtual void Send(string message)
    {
        _notifierService.Send(message);
    }
}

// SMS decorator
public class SMSNotifier : NotifierDecorator
{
    public SMSNotifier(INotifier notifier) : base(notifier) { }
    public override void Send(string message)
    {
        base.Send(message);
        System.Console.WriteLine($"Sending SMS: {message}");
    }
}

// Push notifier decorator
public class PushNotifier : NotifierDecorator
{
    private readonly INotifier notifierService;

    public PushNotifier(INotifier notifier) : base(notifier)
    {
        this.notifierService = notifier;
    }
    public override void Send(string message)
    {
        base.Send(message);
        System.Console.WriteLine($"Sending Push Notification: {message}");
    }
}
