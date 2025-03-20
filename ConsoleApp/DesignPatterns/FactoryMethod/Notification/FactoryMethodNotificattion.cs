namespace LearnDotNetConsole.DesignPatterns.FactoryMethod.Notification;

public class FactoryMethodNotificattion
{
    public static void SendEmail()
    {
        var emailNotification = EmailNotificationFactory.CreateNotification();
        emailNotification.SendEmail();
    }
}