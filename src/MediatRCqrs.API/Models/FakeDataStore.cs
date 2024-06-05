namespace MediatRCqrs.API.Models;

public class FakeDataStore
{
    private static List<Product> _products;

    public FakeDataStore()
    {
        _products = new()
        {
            new() { Id = 1, Name = "Product 1" },
            new() { Id = 2, Name = "Product 2" },
            new() { Id = 3, Name = "Product 3" },
        };
    }

    public async Task AddProduct(Product product)
    {
        _products.Add(product);

        await Task.CompletedTask;
    }

    public async Task<IEnumerable<Product>> GetProducts() => await Task.FromResult(_products);

    public async Task<Product> GetProductById(int id) => await Task.FromResult(_products.Single(p => p.Id == id));
}