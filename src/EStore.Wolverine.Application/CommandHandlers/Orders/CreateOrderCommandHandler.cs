using EStore.Wolverine.Contracts.Commands.Orders;
using EStore.Wolverine.Contracts.Results.Common;
using EStore.Wolverine.Domain.Entities;
using EStore.Wolverine.Domain.Events;
using EStore.Wolverine.Domain.Repositories;
using EStore.Wolverine.Domain.ValueObjects;
using Wolverine;
using Wolverine.Attributes;

namespace EStore.Wolverine.Application.CommandHandlers.Orders;

[WolverineHandler]
public class CreateOrderCommandHandler
{
    [Transactional]
    public static async Task<CreatedResult<long>> Handle(CreateOrderCommand command,
        CancellationToken cancellationToken,
        IOrderRepository orderRepository,
        IMessageContext messageContext)
    {
        var address = new Address(command.Address.FirstLine, command.Address.SecondLine);

        var orderLines = command.Lines.Select(l =>
            new OrderLine(l.ProductId, l.Quantity, new Money(l.UnitPrice.Value, l.UnitPrice.Currency)));

        var order = new Order(DateTimeOffset.UtcNow, command.Email, address, orderLines);

        await orderRepository.AddAsync(order, cancellationToken);

        await messageContext.PublishAsync(new OrderCreated(order.Id));
        
        return new CreatedResult<long>(order.Id);
    }
}
