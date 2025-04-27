using LearnDotNetConsole.DesignPatterns.FactoryMethod.Notification.Factories;
using LearnDotNetConsole.DesignPatterns.FactoryMethod.Notification.Interfaces;

namespace LearnDotNetConsole.DesignPatterns.FactoryMethod.Notification;

public class NotificationServiceFactory(INotificationFactoryCreator notificationFactoryCreator)
{
    // private readonly INotification _notification = notificationFactoryCreator.CreateNotificationFactoryMethod();

    public void Send()
    {
        Console.WriteLine("I am client code, I am unaware of creator' class. \n" +
                          notificationFactoryCreator.PostNotification());
    }
}