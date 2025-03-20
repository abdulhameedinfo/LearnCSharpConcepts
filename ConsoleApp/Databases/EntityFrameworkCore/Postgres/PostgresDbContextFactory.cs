using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace LearnDotNetConsole.Databases.EntityFrameworkCore.Postgres;

public class PostgresDbContextFactory : IDesignTimeDbContextFactory<PostgresDbContext>
{
    public PostgresDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<PostgresDbContext>();
        optionsBuilder.UseNpgsql("Host=localhost;Database=csharconcepts;Username=postgres;Password=postgres");

        return new PostgresDbContext(optionsBuilder.Options);
    }
}