using MediatR;
namespace Application.Interfaces.Idempotency;

public abstract record IdempotentCommand(Guid RequestId) : IRequest;