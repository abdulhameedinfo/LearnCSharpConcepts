using Application.Interfaces.Idempotency;

namespace Application.Products.Create;

public record CreateProductCommand(
    Guid RequestId, 
    string Name, 
    decimal Price, 
    string Sku) : IdempotentCommand(RequestId);

public record CreateProductRequest
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Sku { get; set; }
}