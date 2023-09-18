namespace EStore.Wolverine.Domain.Events;

public record ShipmentSent(long ShipmentId, long OrderId);
