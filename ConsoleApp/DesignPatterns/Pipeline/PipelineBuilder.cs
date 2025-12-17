
using LearnDotNetConsole.DesignPatterns.Pipeline.Interface;

namespace LearnDotNetConsole.DesignPatterns.Pipeline;

public class PipelineBuilder<TCommand>  where TCommand : ICommand
{
    private List<IPipelineStep<TCommand>> _steps = new();

    public Task Execute(TCommand command)
    {
        _steps.ForEach(x => x.Execute(command));
        return Task.CompletedTask;
    }

    public void Use(IPipelineStep<TCommand> step)
    {
        _steps.Add(step);
    }
}