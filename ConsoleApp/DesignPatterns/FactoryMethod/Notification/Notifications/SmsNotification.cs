using LearnDotNetConsole.DesignPatterns.FactoryMethod.Notification.Interfaces;

namespace LearnDotNetConsole.DesignPatterns.FactoryMethod.Notification.Notifications;

public class SmsNotification: INotification
{
    public string Send() => "Sending sms notification";
}