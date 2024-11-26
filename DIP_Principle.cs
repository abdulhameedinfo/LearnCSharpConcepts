public class DIP_Principle_To_Send_Notifications
{
    public DIP_Principle_To_Send_Notifications()
    {
        // Send Email Notification
        NotificationService notificationService = new NotificationService(new EmailSender());
        notificationService._notificationSender.Send("Hi, We are informing you via email...");

        // Send SMS
        notificationService = new NotificationService(new SmsSender());
        notificationService._notificationSender.Send("Hi, We are informing you via SMS...");
    }
}

public interface INotificationSender
{
    void SendNotification(string message);
}

public class EmailSender : INotificationSender
{
    public void SendNotification(string message)
    {
        System.Console.WriteLine(message);
    }
}

public class SmsSender : INotificationSender
{
    public void SendNotification(string message)
    {
        System.Console.WriteLine(message);
    }
}

public class NotificationService
{
    private readonly INotificationSenderFactory _senderFactory;

    public NotificationService(INotificationSenderFactory senderFactory)
    {
        _senderFactory = senderFactory;
    }
    public void Notify(string message, NotificationType type)
    {
        var sender = _senderFactory.GetSender(type);
        sender.SendNotification(message);
    }

}
public enum NotificationType
{
    Email,
    SMS
}

public interface INotificationSenderFactory
{
    INotificationSender GetSender(NotificationType type);
}
public class NotificationSenderFactory : INotificationSenderFactory
{
    public INotificationSender GetSender(NotificationType type)
    {
        return type switch
        {
            NotificationType.Email => new EmailSender(),
            NotificationType.SMS => new SmsSender(),
            _ => throw new NotSupportedException($"Notification type ${type} is not supported.")
        };
    }
}