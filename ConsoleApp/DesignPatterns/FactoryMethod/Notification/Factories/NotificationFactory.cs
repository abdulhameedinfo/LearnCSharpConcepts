using System.Diagnostics;
using LearnDotNetConsole.DesignPatterns.FactoryMethod.Notification.Interfaces;
using LearnDotNetConsole.DesignPatterns.FactoryMethod.Notification.Notifications;

namespace LearnDotNetConsole.DesignPatterns.FactoryMethod.Notification.Factories;

public interface INotificationFactoryCreator
{
    public INotification CreateNotificationFactoryMethod();

    public string PostNotification()
    {
        // Call the factory method to create a notification object. 
        var notification = CreateNotificationFactoryMethod();

        // Now, use the notification object. 
        var result = "Creator: The same creator factory method code has just worked with "
                     + notification.Send();
        return result;
    }
}

public class EmailNotificationFactoryCreator : INotificationFactoryCreator
{
    public INotification CreateNotificationFactoryMethod() => new EmailNotification();
}

public class SmsNotificationFactoryCreator : INotificationFactoryCreator
{
    public INotification CreateNotificationFactoryMethod() => new SmsNotification();
}

public class PushNotificationFactoryCreator : INotificationFactoryCreator
{
    public INotification CreateNotificationFactoryMethod() => new Pushotification();
}