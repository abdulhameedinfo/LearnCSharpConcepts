public partial class Program
{
    public class ApplicationWithDIServices
    {
        private readonly IProductService _productService;

        public ApplicationWithDIServices(IProductService productService)
        {
            _productService = productService;
        }
        public void Start()
        {
            // System.Console.WriteLine("This is application with DI services");

            // /Call decorator services
            // var product = _productService.GetProductById(2);
            // System.Console.WriteLine($"product is {product}");
        }
    }
}