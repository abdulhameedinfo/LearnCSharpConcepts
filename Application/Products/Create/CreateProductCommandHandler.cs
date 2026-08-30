using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Products.Create;

public sealed class CreateProductCommandHandler(IProductRepository productRepository)
    : IRequestHandler<CreateProductCommand>
{
    public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Name = request.Name,
            Price = request.Price,
            Sku = request.Sku
        };

        await productRepository.AddAsync(product);
        await productRepository.SaveChangesAsync();
    }
}
