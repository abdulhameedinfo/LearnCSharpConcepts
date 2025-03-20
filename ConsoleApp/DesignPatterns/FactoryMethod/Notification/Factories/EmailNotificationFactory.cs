using LearnDotNetConsole.DesignPatterns.FactoryMethod.Notification.Interfaces;
using LearnDotNetConsole.DesignPatterns.FactoryMethod.Notification.Notifications;

namespace LearnDotNetConsole.DesignPatterns.FactoryMethod;

public abstract class EmailNotificationFactory
{
    public static INotification CreateNotification() => new EmailNotification();
}