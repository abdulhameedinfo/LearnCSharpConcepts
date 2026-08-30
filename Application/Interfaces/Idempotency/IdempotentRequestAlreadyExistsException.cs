namespace Application.Interfaces.Idempotency;

public sealed class IdempotentRequestAlreadyExistsException : Exception
{
    public IdempotentRequestAlreadyExistsException(Guid requestId)
        : base($"Request with idempotency key '{requestId}' already exists.")
    {
        RequestId = requestId;
    }

    public Guid RequestId { get; }
}
