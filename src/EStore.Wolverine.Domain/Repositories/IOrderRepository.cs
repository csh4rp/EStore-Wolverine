using EStore.Wolverine.Domain.Entities;

namespace EStore.Wolverine.Domain.Repositories;

public interface IOrderRepository
{
    Task AddAsync(Order order, CancellationToken cancellationToken);

    Task UpdateAsync(Order order, CancellationToken cancellationToken);

    Task<Order> GetByIdAsync(long id, CancellationToken cancellationToken);
}
