using EStore.Wolverine.Contracts.Commands.Payments;
using EStore.Wolverine.Contracts.Results.Common;
using EStore.Wolverine.Domain.Entities;
using EStore.Wolverine.Domain.Events;
using EStore.Wolverine.Domain.Repositories;
using Wolverine;
using Wolverine.Attributes;

namespace EStore.Wolverine.Application.CommandHandlers.Payments;

[WolverineHandler]
public class CreatePaymentCommandHandler
{
    [Transactional]
    public static async Task<CreatedResult<long>> Handle(CreatePaymentCommand command,
        CancellationToken cancellationToken,
        IPaymentRepository paymentRepository,
        IMessageBus bus)
    {
        var payment = new Payment(DateTimeOffset.UtcNow, command.OrderId);

        await paymentRepository.AddAsync(payment, cancellationToken);

        await bus.PublishAsync(new PaymentReceived(payment.Id, payment.OrderId));

        return new CreatedResult<long>(payment.Id);
    }
}
