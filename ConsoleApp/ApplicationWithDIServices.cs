using LearnDotNetConsole.Databases.EntityFrameworkCore;
using LearnDotNetConsole.Databases.EntityFrameworkCore.Postgres;

public partial class Program
{
    public class ApplicationWithDiServices(
        IProductService productService,
        IRepository<User> userRepository,
        PostgresDbContext postgresDbContext)
    {
        private readonly IProductService _productService = productService;
        private readonly IRepository<User> _userRepository = userRepository;

        public void Start()
        {
            // System.Console.WriteLine("App WITH DI...");

            // /Call decorator services
            // var product = _productService.GetProductById(2);
            // System.Console.WriteLine($"product is {product}");

            // With decorator it should first call loging decorator then user repository
            // _userRepository.GetAll();
            
            // Descriminator | Postgres
            // new PaymentService(postgresDbContext).GetPayments();
        }
    }
}