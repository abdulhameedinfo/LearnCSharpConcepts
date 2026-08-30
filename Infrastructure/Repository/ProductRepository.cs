using Domain.Entities;
using Domain.Interfaces;
using CleanArchApi.Infrastructure.Persistance;

namespace CleanArchApi.Infrastructure.Repository;

public class ProductRepository(AppDbContext context) : IProductRepository
{
    public async Task AddAsync(Product product) => await context.Products.AddAsync(product);

    public async Task SaveChangesAsync() => await context.SaveChangesAsync();
}
