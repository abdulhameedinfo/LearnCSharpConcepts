public class NotificationSender
{
    public static void Send()
    {
        INotifier notifier = new EmailNotifier();
        notifier = new SMSNotifier(notifier);
        notifier = new PushNotifier(notifier);
        notifier.Send("Hello Tuli eServices!");
    }
}