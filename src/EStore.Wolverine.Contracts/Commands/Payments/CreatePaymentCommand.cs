namespace EStore.Wolverine.Contracts.Commands.Payments;

public record CreatePaymentCommand
{
    public required long OrderId { get; init; }
}
