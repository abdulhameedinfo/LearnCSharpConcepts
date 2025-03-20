using LearnDotNetConsole.DesignPatterns.FactoryMethod.Notification.Interfaces;

namespace LearnDotNetConsole.DesignPatterns.FactoryMethod.Notification.Notifications;

public class EmailNotification: INotification
{
    public void SendEmail() => System.Console.WriteLine("Sending Email");
}