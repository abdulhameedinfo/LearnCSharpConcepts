using Microsoft.Extensions.Logging;

public class LoggingProductService : IProductService
{
    private readonly IProductService _innerService;
    private readonly ILogger<LoggingProductService> _logger;

    public LoggingProductService(IProductService innerService, ILogger<LoggingProductService> logger)
    {
        _innerService = innerService;
        _logger = logger;
    }

    public string GetProductById(int id)
    {
        _logger.LogInformation($"Fetching product with ID: {id}");
        var product = _innerService.GetProductById(id);
        _logger.LogInformation($"Fetched product: {product}");
        return product;
    }
}