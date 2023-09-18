using EStore.Wolverine.Domain.Abstract;
using EStore.Wolverine.Domain.Enums;

namespace EStore.Wolverine.Domain.Entities;

public class Shipment : IEntity
{
    private Shipment()
    {
    }

    public Shipment(long orderId)
    {
        OrderId = orderId;
        Status = ShipmentStatus.Prepared;
    }

    public long Id { get; init; }
    
    public long OrderId { get; private init; }
    
    public ShipmentStatus Status { get; private set; }

    public void MarkShipmentAsInDelivery()
    {
        if (Status != ShipmentStatus.Prepared)
        {
            throw new InvalidOperationException("Shipment can't be marked as sent when it was not prepared");
        }

        Status = ShipmentStatus.InDelivery;
    }

    public void MarkAsDelivered()
    {
        if (Status != ShipmentStatus.InDelivery)
        {
            throw new InvalidOperationException("Shipment can't be marked as delivered when it was not in delivery");
        }

        Status = ShipmentStatus.Delivered;
    }

    public void MarkAsReturned()
    {
        if (Status != ShipmentStatus.InDelivery)
        {
            throw new InvalidOperationException("Shipment can't be marked as returned when it was not in delivery");
        }

        Status = ShipmentStatus.Returned;
    }
}
