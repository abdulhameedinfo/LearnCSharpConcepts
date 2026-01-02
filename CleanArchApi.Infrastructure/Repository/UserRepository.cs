using CleanArchApi.Domain.Entities;
using CleanArchApi.Domain.Interfaces;
using CleanArchApi.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace CleanArchApi.Infrastructure.Repository;

public class UserRepository(AppDbContext context) : IUserRepository
{
    public async Task<User?> GetByUsernameAsync(string username) => 
        await context.Users.FirstOrDefaultAsync(u => u.Username == username);

    public async Task AddAsync(User user) => await context.Users.AddAsync(user);

    public async Task UpdateAsync(User user) => await Task.Run(() => context.Users.Update(user));

    public async Task DeleteAsync(User user) => await Task.Run(() => context.Users.Remove(user));

    public async Task SaveChangesAsync() => await context.SaveChangesAsync();
}