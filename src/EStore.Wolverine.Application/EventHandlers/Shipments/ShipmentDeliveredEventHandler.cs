using EStore.Wolverine.Domain.Events;
using EStore.Wolverine.Domain.Repositories;
using Microsoft.Extensions.Logging;
using Wolverine.Attributes;

namespace EStore.Wolverine.Application.EventHandlers.Shipments;

[WolverineHandler]
public sealed class ShipmentDeliveredEventHandler
{
    public async Task Consume(ShipmentDelivered @event,
        CancellationToken cancellationToken,
        IOrderRepository orderRepository,
        ILogger<ShipmentDeliveredEventHandler> logger)
    {
        var order = await orderRepository.GetByIdAsync(@event.OrderId, cancellationToken);
        
        order.MarkAsDelivered();

        await orderRepository.UpdateAsync(order, cancellationToken);
        
        logger.LogInformation("Shipment was delivered for order with ID: {OrderId}", order.Id);
    }
}
