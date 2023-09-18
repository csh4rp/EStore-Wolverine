using EStore.Wolverine.Contracts.Commands.Shipments;
using EStore.Wolverine.Contracts.Results.Common;
using EStore.Wolverine.Domain.Entities;
using EStore.Wolverine.Domain.Events;
using EStore.Wolverine.Domain.Repositories;
using Wolverine;
using Wolverine.Attributes;

namespace EStore.Wolverine.Application.CommandHandlers.Shipments;

[WolverineHandler]
public class CreateShipmentCommandHandler
{
    [Transactional]
    public static async Task<CreatedResult<long>> Handle(CreateShipmentCommand command,
        CancellationToken cancellationToken,
        IShipmentRepository shipmentRepository,
        IMessageBus bus)
    {
        var shipment = new Shipment(command.OrderId);

        await shipmentRepository.AddAsync(shipment, cancellationToken);

        await bus.PublishAsync(new ShipmentPrepared(shipment.Id, shipment.OrderId));

        return new CreatedResult<long>(shipment.Id);
    }
}
