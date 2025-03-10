using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace UnitOfWork
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<T> GetById(Guid id);
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> expression);
        bool Exists(Guid Id);
    }
    public class Repository<T> : IRepository<T> where T : class
    {
        private DbContext dbContext;
        private DbSet<T> dbset;
        public Repository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbset = dbContext.Set<T>();
        }

        public void Add(T entity)
        {
            dbset.Add(entity);
        }
        public void Update(T entity)
        {
            dbset.Update(entity);
        }
        public void Delete(T entity)
        {
            dbset.Remove(entity);
        }
        public async Task<T> GetById(Guid id)
        {
            return await dbset.FindAsync(id);
        }
        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> expression)
        {
            return await dbset.Where(expression).ToListAsync();
        }
        public bool Exists(Guid Id)
        {
            return dbset.FindAsync(Id).Result != null;
        }
    }

    // public class OrderRepository<T> : Repository<T>
    // {

    // }
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext dbContext;
        Dictionary<Type, object> repositories = new Dictionary<Type, object>();
        public UnitOfWork(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IRepository<T> Repository<T>() where T : class
        {
            if (!repositories.ContainsKey(typeof(T)))
            {
                var repositoryInstance = new Repository<T>(dbContext);
                repositories[typeof(T)] = repositoryInstance;
            }
            return (IRepository<T>)repositories[typeof(T)];

        }
        public void Commit()
        {
            dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class Order
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string Product { get; set; }
    }

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
    public class UnitOfWorkExample
    {
        public void Start()
        {
            // Database configurations
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("UnitOfWorkExample").Options;
            var dbContext = new ApplicationDbContext(options);
            var unitOfWork = new UnitOfWork(dbContext);
            var newCustomerId = Guid.NewGuid();
            unitOfWork.Repository<Customer>().Add(new Customer() { Id = newCustomerId, Name = "Abdul Hameed" });
            unitOfWork.Repository<Order>().Add(new Order() { Id = Guid.NewGuid(), CustomerId = newCustomerId, Product = "HDMI 2.0" });
            unitOfWork.Commit();

            // Confirm it is saved. 
            var savedCustomer = unitOfWork.Repository<Customer>().GetById(newCustomerId);
            System.Console.WriteLine($"Saved customer name: {savedCustomer.Result.Name}");

            // Confirm the saved order
            var savedOrder = unitOfWork.Repository<Order>().GetAll(x => x.CustomerId == newCustomerId);
            System.Console.WriteLine($"Saved order product: {savedOrder.Result.FirstOrDefault()?.Product}");

            // Confirm the update 
            savedCustomer.Result.Name = "Abdul Hameed Updated";
            unitOfWork.Repository<Customer>().Update(savedCustomer.Result);
            unitOfWork.Commit();
            var updatedCustomer = unitOfWork.Repository<Customer>().GetById(newCustomerId);
            System.Console.WriteLine($"Updated customer name: {updatedCustomer.Result.Name}");

            // Confirm the delete
            unitOfWork.Repository<Customer>().Delete(savedCustomer.Result);
            unitOfWork.Commit();
            var customerExists = unitOfWork.Repository<Customer>().Exists(newCustomerId);
            System.Console.WriteLine($"Customer exists: {customerExists}");
        }
    }
}