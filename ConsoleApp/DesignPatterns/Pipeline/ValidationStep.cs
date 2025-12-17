using BenchmarkDotNet.Exporters;
using LearnDotNetConsole.DesignPatterns.Pipeline.Interface;

namespace LearnDotNetConsole.DesignPatterns.Pipeline;

public class ValidationStep<TCommand>  : IPipelineStep<TCommand> where TCommand : EnrollmentCommand
{
    public Task Execute(TCommand command)
    {
        command.Logs.Add("ValidationStep<TCommand>");

        if (command.Age > 70)
        {
            throw new InvalidDataException("Age must be greater than or equal to 70");
        }
        command.Logs.Add("Validation completed!");

        var student = new Student()
        {
            FullName = "Arsalan",
            Age = 70,
            Gender = Gender.Male,
            Status = StudentStatus.Active
        };

        if (student is { Age: < 18, Gender: Gender.Male, Status: StudentStatus.Active })
        {
            
        }
        return Task.CompletedTask;
    }
}


public class Student
{
    public string FullName { get; set; }
    public StudentStatus Status { get; set; }
    public int Age { get; set; }
    public Gender Gender { get; set; }
}

public enum StudentStatus
{
    Active,
    Inactive
}

public enum Gender
{
    Male,
    Female
}