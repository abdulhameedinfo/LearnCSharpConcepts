public partial class Program
{
    public class ApplicationWithDIServices
    {
        private readonly IProductService _productService;
        private readonly IRepository<User> _userRepository;

        public ApplicationWithDIServices(IProductService productService, IRepository<User> userRepository)
        {
            _productService = productService;
            _userRepository = userRepository;
        }
        public void Start()
        {
            // System.Console.WriteLine("App WITH DI...");

            // /Call decorator services
            // var product = _productService.GetProductById(2);
            // System.Console.WriteLine($"product is {product}");

            // With decorator it should first call loging decorator then user repository
            // _userRepository.GetAll();
        }
    }
}