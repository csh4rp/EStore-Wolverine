using EStore.Wolverine.Contracts.Commands.Shipments;
using EStore.Wolverine.Domain.Events;
using EStore.Wolverine.Domain.Repositories;
using Wolverine;
using Wolverine.Attributes;

namespace EStore.Wolverine.Application.CommandHandlers.Shipments;

[WolverineHandler]
public class MarkShipmentAsReturnedCommandHandler
{
    [Transactional]
    public async Task Handle(MarkShipmentAsReturnedCommand command,
        CancellationToken cancellationToken,
        IShipmentRepository shipmentRepository,
        IMessageBus bus)
    {
        var shipment = await shipmentRepository.GetByIdAsync(command.ShipmentId, cancellationToken);
        
        shipment.MarkAsReturned();

        await shipmentRepository.UpdateAsync(shipment, cancellationToken);

        await bus.PublishAsync(new ShipmentReturned(shipment.Id, shipment.OrderId));
    }
}
