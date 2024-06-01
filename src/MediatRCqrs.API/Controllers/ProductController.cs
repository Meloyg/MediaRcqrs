using MediatR;
using MediatRCqrs.API.Queries;
using Microsoft.AspNetCore.Mvc;

namespace MediatRCqrs.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly ISender _sender;

    public ProductController(ISender sender) => _sender = sender;

    [HttpGet]
    public async Task<IResult> GetProducts()
    {
        var products = await _sender.Send(new GetProductQuery());

        return Results.Ok(products);
    }
}