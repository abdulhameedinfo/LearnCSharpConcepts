using LearnCSharpConcepts.Databases.EntityFrameworkCore;

public partial class Program
{
    public class ApplicationWithDIServices
    {
        private readonly IProductService _productService;
        private readonly IRepository<User> _userRepository;
        private PostgresDbContext _postgresDbContext;

        public ApplicationWithDIServices(IProductService productService, IRepository<User> userRepository, PostgresDbContext postgresDbContext)
        {
            _productService = productService;
            _userRepository = userRepository;
            _postgresDbContext = postgresDbContext;
        }
        public void Start()
        {
            // System.Console.WriteLine("App WITH DI...");

            // /Call decorator services
            // var product = _productService.GetProductById(2);
            // System.Console.WriteLine($"product is {product}");

            // With decorator it should first call loging decorator then user repository
            // _userRepository.GetAll();
            
            // Descriminator | Postgres
            new PaymentService(_postgresDbContext).GetPayments();
        }
    }
}