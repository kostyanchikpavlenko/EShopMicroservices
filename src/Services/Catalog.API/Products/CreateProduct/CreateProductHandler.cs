using BuildingBlocks.CQRS;
using Catalog.API.Models;
using MediatR;

namespace Catalog.API.Products.CreateProduct;

public record CreateProductCommand(
    Guid ProductId,
    string Name,
    List<string> Categories,
    string Description,
    string ImageFile,
    decimal Price) : ICommand<CreateProductResult>;

public record CreateProductResult(Guid Id);

internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Name = request.Name,
            Categories = request.Categories,
            Description = request.Description,
            ImageFile = request.ImageFile,
            Price = request.Price,
            ProductId = request.ProductId
        };

        return Task.FromResult(new CreateProductResult(Guid.NewGuid()));
    }
}