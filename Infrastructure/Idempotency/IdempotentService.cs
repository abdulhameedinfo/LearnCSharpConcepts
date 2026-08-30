using Application.Interfaces.Idempotency;
using CleanArchApi.Infrastructure.Persistance;
using CleanArchApi.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace CleanArchApi.Infrastructure.Idempotency;

public class IdempotentService(AppDbContext dbContext) : IIdempotencyService
{
    public async  Task<bool> IsRequestExistsAsync(Guid requestId)
    {
        return await dbContext.Set<IdempotentRequest>().AnyAsync(x => x.Id == requestId);
    }

    public async Task AddRequestAsync(Guid requestId, string name)
    {
        var request = new IdempotentRequest()
        {
            Id = requestId, Name = name, CreatedAtUtc = DateTime.UtcNow
        };
        dbContext.Add(request);
        await dbContext.SaveChangesAsync();
    }
}