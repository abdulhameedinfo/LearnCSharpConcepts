Pipeline Pattern:
- ICommand: carries request data. 
- IPipelineStep<TCommand>: a unit that modifies TCommand. 
- IPipeline<TCommand>: holds a list of IPipelineStep<TCommand> and runs them sequentially.
- Example Steps: ValidationStep, SaveStep, NotifyStep