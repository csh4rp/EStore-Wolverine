using EStore.Wolverine.Domain.Events;
using EStore.Wolverine.Domain.Repositories;
using Microsoft.Extensions.Logging;
using Wolverine.Attributes;

namespace EStore.Wolverine.Application.EventHandlers.Payments;

[WolverineHandler]
public sealed class PaymentReceivedEventHandler
{
    public async Task Handle(PaymentReceived @event,
        CancellationToken cancellationToken,
        IOrderRepository orderRepository,
        ILogger<PaymentReceivedEventHandler> logger)
    {
        var order = await orderRepository.GetByIdAsync(@event.OrderId, cancellationToken);
        
        order.MarkOrderAsPaid();

        await orderRepository.UpdateAsync(order, cancellationToken);
        
        logger.LogInformation("Order with ID: {OrderId} received payment", order.Id);
    }
}
