public class ProductService : IProductService
{
    public string GetProductById(int id)
    {
        Console.WriteLine("Product main service is called!");
        return "Product";
    }
}


// public class ProductService : IProductService
// {
//     public string GetProductById(int id)
//     {
//         System.Console.WriteLine("Product main service is called!");
//         return AllProducts().Single(x => x.id == id).name;
//     }

//     private IEnumerable<Product> AllProducts()
//     {
//         Product[] products = [
//             new Product(1, "Composition"),
//             new Product(2, "Decorator"),
//             new Product(3, "Repository"),
//             new Product(4, "Singleton")
//             ];
//         return products;
//     }
// }

// record Product(int id, string name);