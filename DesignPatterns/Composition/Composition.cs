public class Composition
{
    public static void CompleteRobot()
    {
        ISpeaker basicSpeaker = new BasicSpeaker();
        IMover basicMover = new BasicMover();
        var robot = new Robot(basicSpeaker, basicMover);
        System.Console.WriteLine(robot.CanSpeak());
        System.Console.WriteLine(robot.CanMove());
    }
}