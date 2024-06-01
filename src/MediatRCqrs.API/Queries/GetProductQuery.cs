using MediatR;
using MediatRCqrs.API.Models;

namespace MediatRCqrs.API.Queries;

public record GetProductQuery() : IRequest<IEnumerable<Product>>;