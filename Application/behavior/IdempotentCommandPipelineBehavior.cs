using Application.Interfaces.Idempotency;
using MediatR;

namespace Application.behavior;

internal sealed class IdempotentCommandPipelineBehavior<TRequest, TResponse> 
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IdempotentCommand
{
    private readonly IIdempotencyService _idempotencyService;

    public IdempotentCommandPipelineBehavior(IIdempotencyService idempotencyService)
    {
        _idempotencyService = idempotencyService;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (await _idempotencyService.IsRequestExistsAsync(request.RequestId))
        {
            throw new IdempotentRequestAlreadyExistsException(request.RequestId);
        }

        await _idempotencyService.AddRequestAsync(request.RequestId, typeof(TRequest).Name );
        var response =  await next();
        return response;
    }
}
