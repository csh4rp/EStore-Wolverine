using EStore.Wolverine.Domain.Events;
using EStore.Wolverine.Domain.Repositories;
using Wolverine.Attributes;

namespace EStore.Wolverine.Application.EventHandlers.Shipments;

[WolverineHandler]
public sealed class ShipmentSentEventHandler
{
    public async Task Consume(ShipmentSent @event,
        CancellationToken cancellationToken,
        IOrderRepository orderRepository)
    {
        throw new Exception();
        
        var order = await orderRepository.GetByIdAsync(@event.OrderId, cancellationToken);
        
        order.MarkAsSent();
        
        await orderRepository.UpdateAsync(order, cancellationToken);
    }
}
