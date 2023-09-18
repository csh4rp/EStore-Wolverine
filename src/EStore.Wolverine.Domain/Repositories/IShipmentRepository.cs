using EStore.Wolverine.Domain.Entities;

namespace EStore.Wolverine.Domain.Repositories;

public interface IShipmentRepository
{
    Task AddAsync(Shipment shipment, CancellationToken cancellationToken);

    Task UpdateAsync(Shipment shipment, CancellationToken cancellationToken);
    
    Task<Shipment> GetByIdAsync(long id, CancellationToken cancellationToken);
}
