using LearnDotNetConsole.DesignPatterns.Pipeline.Interface;

namespace LearnDotNetConsole.DesignPatterns.Pipeline;

public class InsertionStep<TCommand>: IPipelineStep<TCommand> where TCommand : EnrollmentCommand
{
    public Task Execute(TCommand command)
    {
        command.Logs.Add("InsertionStep<TCommand>");
        command.Logs.Add("Inserted successfully!");
        return Task.CompletedTask;
    }
}