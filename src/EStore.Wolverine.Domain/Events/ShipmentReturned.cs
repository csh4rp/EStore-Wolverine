namespace EStore.Wolverine.Domain.Events;

public record ShipmentReturned(long ShipmentId, long OrderId);
