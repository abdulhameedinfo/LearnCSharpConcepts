namespace Application.Interfaces.Idempotency;

public interface IIdempotencyService
{
    Task<bool> IsRequestExistsAsync(Guid requestId);
    Task AddRequestAsync(Guid requestId, string name);
}