using CleanArchApi.Domain.Entities;

namespace CleanArchApi.Domain.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByUsernameAsync(string username);
    Task AddAsync(User user);
    Task UpdateAsync(User user);
    Task DeleteAsync(User user);
    Task SaveChangesAsync();
}