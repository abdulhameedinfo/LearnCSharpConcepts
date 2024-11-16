using Microsoft.Extensions.Caching.Memory;

public class CachedProductService : IProductService
{
    private readonly IProductService _inner;
    private readonly IMemoryCache _cache;

    public CachedProductService(IProductService inner, IMemoryCache cache)
    {
        _inner = inner;
        _cache = cache;
    }

    public string GetProductById(int id)
    {
        // Check if the product is in the cache
        if (_cache.TryGetValue(id, out string cachedProduct))
        {
            Console.WriteLine($"Cache hit for ID: {id}");
            return cachedProduct; // Return cached value
        }

        // If not in cache, fetch from the inner service
        Console.WriteLine($"Cache miss for ID: {id}");
        var product = _inner.GetProductById(id);

        // Store the product in the cache
        _cache.Set(id, product);
        return product;
    }
}
