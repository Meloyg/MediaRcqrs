using MediatR;
using MediatRCqrs.API.Models;

namespace MediatRCqrs.API.Commands;

// TODO: use a dto instead of a model
public record AddProductCommand(Product Product) : IRequest<Product>;