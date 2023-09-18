using EStore.Wolverine.Domain.Events;
using EStore.Wolverine.Domain.Repositories;
using Microsoft.Extensions.Logging;
using Wolverine.Attributes;

namespace EStore.Wolverine.Application.EventHandlers.Orders;

[WolverineHandler]
public sealed class OrderCancellationRequestedEventHandler
{
    public async Task Handle(OrderCancellationRequested @event,
        CancellationToken cancellationToken,
        IOrderRepository orderRepository,
        ILogger<OrderCancellationRequestedEventHandler> logger)
    {
        var order = await orderRepository.GetByIdAsync(@event.OrderId, cancellationToken);
        
        order.MarkAsCancelled();

        await orderRepository.UpdateAsync(order, cancellationToken);

        logger.LogInformation("Order with ID: {OrderId} was cancelled", order.Id);
    }
}
