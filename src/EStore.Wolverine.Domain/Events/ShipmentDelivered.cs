namespace EStore.Wolverine.Domain.Events;

public record ShipmentDelivered(long ShipmentId, long OrderId);
