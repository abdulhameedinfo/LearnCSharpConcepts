
using CleanArchApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchApi.Infrastructure.Persistance;


public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();
}