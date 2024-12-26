using Microsoft.Extensions.Caching.Memory;

public interface IRepository<T>
{
    IEnumerable<T> GetAll();
}

// Decorator1: Logging
public class RepositoryLoggerDecorator<T> : IRepository<T>
{
    private readonly IRepository<T> _docoratedRepository;

    public RepositoryLoggerDecorator(IRepository<T> docoratedRepository)
    {
        this._docoratedRepository = docoratedRepository;
    }
    public IEnumerable<T> GetAll()
    {
        System.Console.WriteLine("Fetching the users...");
        var allUsers = _docoratedRepository.GetAll();
        System.Console.WriteLine("Fetched the users.");
        return allUsers;
    }
}

// Decorator2: Caching
public class RepositoryCacheDecorator<T> : IRepository<T>
{
    private readonly IRepository<T> docoratedRepository;
    private readonly IMemoryCache memoryCache;

    public RepositoryCacheDecorator(IRepository<T> docoratedRepository, IMemoryCache memoryCache)
    {
        this.docoratedRepository = docoratedRepository;
        this.memoryCache = memoryCache;
    }

    public IEnumerable<T> GetAll()
    {
        System.Console.WriteLine("Get from memory cache.");

        IEnumerable<T>? users;
        if (memoryCache.TryGetValue("users", out users))
        {
            System.Console.WriteLine("Fetched from memory cache.");
        }
        {
            users = docoratedRepository.GetAll();
            memoryCache.Set("users", users);
            System.Console.WriteLine("Added to memory cache.");
        }
        return users;
    }
}


public class UserRepository : IRepository<User>
{
    public IEnumerable<User> GetAll()
    {
        System.Console.WriteLine("Fetch from database.");
        return UsersList;
    }
    public List<User> UsersList
    {
        get
        {
            return [
                new User(1, "Abdul Hameed"),
                new User(2, "Alp Arsalan")
            ];
        }
    }
}
public class User(int id, string name)
{
    private int Id = id;
    private string Name = name;
}