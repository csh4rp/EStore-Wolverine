using EStore.Wolverine.Contracts.Commands.Shipments;
using EStore.Wolverine.Domain.Events;
using EStore.Wolverine.Domain.Repositories;
using Wolverine;
using Wolverine.Attributes;

namespace EStore.Wolverine.Application.CommandHandlers.Shipments;

[WolverineHandler]
public class MarkShipmentAsDeliveredCommandHandler
{
    [Transactional]
    public static async Task Handle(MarkShipmentAsDeliveredCommand command,
        CancellationToken cancellationToken,
        IShipmentRepository shipmentRepository,
        IMessageBus bus)
    {
        var shipment = await shipmentRepository.GetByIdAsync(command.ShipmentId, cancellationToken);
        
        shipment.MarkAsDelivered();

        await shipmentRepository.UpdateAsync(shipment, cancellationToken);

        await bus.PublishAsync(new ShipmentDelivered(shipment.Id, shipment.OrderId));
    }
}
