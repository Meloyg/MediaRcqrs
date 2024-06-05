using MediatR;
using MediatRCqrs.API.Commands;
using MediatRCqrs.API.Models;
using MediatRCqrs.API.Queries;
using Microsoft.AspNetCore.Mvc;

namespace MediatRCqrs.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly ISender _mediatr;

    public ProductController(ISender mediatr) => _mediatr = mediatr;

    [HttpGet]
    public async Task<IResult> GetProducts()
    {
        var products = await _mediatr.Send(new GetProductQuery());

        return Results.Ok(products);
    }
    
    [HttpGet("{id:int}", Name = "GetProductById")]
    public async Task<IResult> GetProductById(int id)
    {
        var product = await _mediatr.Send(new GetProductByIdQuery(id));

        return product is not null ? Results.Ok(product) : Results.NotFound();
    }
    
    [HttpPost]
    public async Task<IResult> AddProduct(Product product)
    {
        var productToReturn = await _mediatr.Send(new AddProductCommand(product));

        return Results.CreatedAtRoute("GetProductById", new { id = product.Id }, productToReturn);
    }
}