using Domain.Entities;

namespace Domain.Interfaces;

public interface IProductRepository
{
    Task AddAsync(Product product);
    Task SaveChangesAsync();
}
