
namespace LearnDotNetConsole.DesignPatterns.Pipeline;

public class EnrollmentCommand: ICommand
{
    public required string Name { get; set; }

    public int Age { get; set; }
    public List<string> Logs { get; set; } = [];
    public string CreatedAt { get; set; }
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}