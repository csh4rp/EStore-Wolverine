using EStore.Wolverine.Domain.Events;
using EStore.Wolverine.Domain.Repositories;
using Microsoft.Extensions.Logging;
using Wolverine.Attributes;

namespace EStore.Wolverine.Application.EventHandlers.Shipments;

[WolverineHandler]
public sealed class ShipmentPreparedEventHandler
{
    public async Task Handle(ShipmentPrepared @event,
        CancellationToken cancellationToken,
        IOrderRepository orderRepository,
        ILogger<ShipmentPreparedEventHandler> logger)
    {
        var order = await orderRepository.GetByIdAsync(@event.OrderId, cancellationToken);
        
        order.MarkAsPrepared();

        await orderRepository.UpdateAsync(order, cancellationToken);
        
        logger.LogInformation("Shipment was prepared for order with ID: {OrderId}", order.Id);
    }
}
