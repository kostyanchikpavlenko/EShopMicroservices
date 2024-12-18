using BuildingBlocks.Result;

namespace Catalog.API.Products.Errors;

public static class ProductErrors
{
    public static Error ProductNotFound = new("GetProductByIdHandler.Handle", "Product was not found");
}