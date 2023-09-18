namespace EStore.Wolverine.Domain.Events;

public record ShipmentPrepared(long ShipmentId, long OrderId);
