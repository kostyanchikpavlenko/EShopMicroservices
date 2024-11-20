
namespace Catalog.API.Products.CreateProduct;

public record CreateProductRequest(
    string Name,
    List<string> Category,
    string Description,
    string ImageFile,
    decimal Price);

public record CreateProductResponse(Guid Id);

public class CreateProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/products",
            async(CreateProductRequest request,
                ISender mediatr) =>
            {
                var command = request.Adapt<CreateProductCommand>();
                var result = await mediatr.Send(command);
                var response = result.Adapt<CreateProductResponse>();
                return Results.Created($"/products", response);
            })
            .WithName("CreateProduct")
            .Produces<CreateProductResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("CreateProduct")
            .WithDescription("CreateProduct");
    }
}