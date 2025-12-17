namespace LearnDotNetConsole.DesignPatterns.Pipeline.Interface;

public interface IPipelineStep<TCommand> where TCommand : ICommand
{
    Task Execute(TCommand command);
}