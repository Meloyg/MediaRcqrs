using MediatR;
using MediatRCqrs.API.Models;
using MediatRCqrs.API.Queries;

namespace MediatRCqrs.API.Handlers;

public class GetProductHandler : IRequestHandler<GetProductQuery, IEnumerable<Product>>
{
    private readonly FakeDataStore _fakeDataStore;

    public GetProductHandler(FakeDataStore fakeDataStore)
    {
        _fakeDataStore = fakeDataStore;
    }

    public async Task<IEnumerable<Product>> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        return await _fakeDataStore.GetProducts();
    }
}