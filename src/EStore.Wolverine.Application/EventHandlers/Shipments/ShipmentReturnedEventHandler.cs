using EStore.Wolverine.Domain.Events;
using EStore.Wolverine.Domain.Repositories;
using Microsoft.Extensions.Logging;
using Wolverine.Attributes;

namespace EStore.Wolverine.Application.EventHandlers.Shipments;

[WolverineHandler]
public sealed class ShipmentReturnedEventHandler
{
    public async Task Consume(ShipmentReturned @event,
        CancellationToken cancellationToken,
        IOrderRepository orderRepository,
        ILogger<ShipmentReturnedEventHandler> logger)
    {
        var order = await orderRepository.GetByIdAsync(@event.OrderId, cancellationToken);
        
        order.MarkAsReturned();

        await orderRepository.UpdateAsync(order, cancellationToken);
        
        logger.LogInformation("Order with ID: {OrderId} was returned", order.Id);
    }
}
