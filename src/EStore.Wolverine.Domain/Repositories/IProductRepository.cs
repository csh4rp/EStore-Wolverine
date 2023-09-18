using EStore.Wolverine.Domain.Entities;

namespace EStore.Wolverine.Domain.Repositories;

public interface IProductRepository
{
    Task AddAsync(Product product, CancellationToken cancellationToken);
}
