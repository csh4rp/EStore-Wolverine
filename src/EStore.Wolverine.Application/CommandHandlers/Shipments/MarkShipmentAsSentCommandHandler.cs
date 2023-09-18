using EStore.Wolverine.Contracts.Commands.Shipments;
using EStore.Wolverine.Domain.Events;
using EStore.Wolverine.Domain.Repositories;
using Wolverine;
using Wolverine.Attributes;

namespace EStore.Wolverine.Application.CommandHandlers.Shipments;

[WolverineHandler]
public class MarkShipmentAsSentCommandHandler
{
    [Transactional]
    public async Task Handle(MarkShipmentAsSentCommand command,
        CancellationToken cancellationToken,
        IShipmentRepository shipmentRepository,
        IMessageBus bus)
    {
        var shipment = await shipmentRepository.GetByIdAsync(command.ShipmentId, cancellationToken);
        
        shipment.MarkShipmentAsInDelivery();

        await shipmentRepository.UpdateAsync(shipment, cancellationToken);

        await bus.PublishAsync(new ShipmentSent(shipment.Id, shipment.OrderId));
    }
}
