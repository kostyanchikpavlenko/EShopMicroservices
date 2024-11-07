namespace Catalog.API.Models;

public class Product
{
    public Guid ProductId { get; set; }
    public string Name { get; set; }
    public List<string> Categories { get; set; } = [];
    public string Description { get; set; }
    public string ImageFile { get; set; }
    public decimal Price { get; set; }
}
