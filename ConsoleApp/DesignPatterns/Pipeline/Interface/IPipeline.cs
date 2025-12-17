namespace LearnDotNetConsole.DesignPatterns.Pipeline;

public interface IPipeline<TCommand> : ICommand where TCommand : ICommand
{
    Task Execute(TCommand command);
}