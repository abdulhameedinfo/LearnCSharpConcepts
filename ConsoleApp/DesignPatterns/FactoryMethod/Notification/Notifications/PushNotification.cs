using LearnDotNetConsole.DesignPatterns.FactoryMethod.Notification.Interfaces;

namespace LearnDotNetConsole.DesignPatterns.FactoryMethod.Notification.Notifications;

public class Pushotification: INotification
{
    public string Send() => "Sending push notification";
}