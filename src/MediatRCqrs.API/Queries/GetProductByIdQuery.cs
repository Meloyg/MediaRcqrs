using MediatR;
using MediatRCqrs.API.Models;

namespace MediatRCqrs.API.Queries;

public record GetProductByIdQuery(int Id) : IRequest<Product>;