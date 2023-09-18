using EStore.Wolverine.Contracts.Commands.Orders;
using EStore.Wolverine.Domain.Events;
using Wolverine;
using Wolverine.Attributes;

namespace EStore.Wolverine.Application.CommandHandlers.Orders;

[WolverineHandler]
public class RequestOrderCancellationCommandHandler
{
    [Transactional]
    public static async Task Handle(RequestOrderCancellationCommand command, IMessageBus bus)
    {
        await bus.PublishAsync(new OrderCancellationRequested(command.OrderId));
    }
}
