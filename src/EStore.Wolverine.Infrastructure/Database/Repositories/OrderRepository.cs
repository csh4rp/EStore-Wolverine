using EStore.Wolverine.Domain.Entities;
using EStore.Wolverine.Domain.Repositories;
using EStore.Wolverine.Infrastructure.Database.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EStore.Wolverine.Infrastructure.Database.Repositories;

public sealed class OrderRepository : IOrderRepository
{
    private readonly EStoreDbContext _dbContext;

    public OrderRepository(EStoreDbContext dbContext) => _dbContext = dbContext;

    public Task AddAsync(Order order, CancellationToken cancellationToken)
    {
        _dbContext.Orders.Add(order);
        return _dbContext.SaveChangesAsync(cancellationToken);
    }

    public Task UpdateAsync(Order order, CancellationToken cancellationToken)
    {
        if (_dbContext.Entry(order).State != EntityState.Modified)
        {
            _dbContext.Orders.Update(order);
        }
        
        return _dbContext.SaveChangesAsync(cancellationToken);
    }

    public Task<Order> GetByIdAsync(long id, CancellationToken cancellationToken)
        => _dbContext.Orders.SingleAsync(o => o.Id == id, cancellationToken);
}
