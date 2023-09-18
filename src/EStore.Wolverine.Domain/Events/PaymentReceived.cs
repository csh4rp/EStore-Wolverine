namespace EStore.Wolverine.Domain.Events;

public record PaymentReceived(long PaymentId, long OrderId);
