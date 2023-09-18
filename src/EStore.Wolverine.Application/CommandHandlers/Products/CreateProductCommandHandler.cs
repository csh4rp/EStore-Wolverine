using EStore.Wolverine.Contracts.Commands.Products;
using EStore.Wolverine.Contracts.Results.Common;
using EStore.Wolverine.Domain.Entities;
using EStore.Wolverine.Domain.Repositories;
using EStore.Wolverine.Domain.ValueObjects;
using Wolverine.Attributes;

namespace EStore.Wolverine.Application.CommandHandlers.Products;

[WolverineHandler]
public class CreateProductCommandHandler
{
    [Transactional]
    public static async Task<CreatedResult<long>> Handle(CreateProductCommand command,
        CancellationToken cancellationToken,
        IProductRepository productRepository)
    {
        var product = new Product(DateTimeOffset.UtcNow,
            command.Ean, 
            command.Name,
            command.Description,
            new Money(command.UnitPrice.Value, command.UnitPrice.Currency));

        await productRepository.AddAsync(product, cancellationToken);

        return new CreatedResult<long>(product.Id);
    }
}
