public interface IRepository<T>
{
    IEnumerable<T> GetAll();
}

public class UserRepository : IRepository<User>
{
    public IEnumerable<User> GetAll() => UsersList;
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
        var allUsers =  _docoratedRepository.GetAll();
        System.Console.WriteLine("Fetched the users.");
        return allUsers;
    }
}
public class User(int id, string name)
{
    private int Id = id;
    private string Name = name;
}