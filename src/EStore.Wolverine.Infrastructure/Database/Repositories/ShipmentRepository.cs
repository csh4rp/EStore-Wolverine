using EStore.Wolverine.Domain.Entities;
using EStore.Wolverine.Domain.Repositories;
using EStore.Wolverine.Infrastructure.Database.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EStore.Wolverine.Infrastructure.Database.Repositories;

public sealed class ShipmentRepository : IShipmentRepository
{
    private readonly EStoreDbContext _dbContext;

    public ShipmentRepository(EStoreDbContext dbContext) => _dbContext = dbContext;

    public Task AddAsync(Shipment shipment, CancellationToken cancellationToken)
    {
        _dbContext.Shipments.Add(shipment);
        return _dbContext.SaveChangesAsync(cancellationToken);
    }

    public Task UpdateAsync(Shipment shipment, CancellationToken cancellationToken)
    {     
        if (_dbContext.Entry(shipment).State != EntityState.Modified)
        {
            _dbContext.Shipments.Update(shipment);
        }
        
        return _dbContext.SaveChangesAsync(cancellationToken);
    }

    public Task<Shipment> GetByIdAsync(long id, CancellationToken cancellationToken)
        => _dbContext.Shipments.SingleAsync(s => s.Id == id, cancellationToken);
}
