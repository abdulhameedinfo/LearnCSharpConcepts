using Application.Interfaces.Idempotency;
using CleanArchApi.Infrastructure.Idempotency;
using CleanArchApi.Infrastructure.Persistance;
using CleanArchApi.Infrastructure.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Domain.Interfaces;

namespace CleanArchApi.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IIdempotencyService, IdempotentService>();
        services.AddScoped<IProductRepository, ProductRepository>();

        return services;
    }
}
