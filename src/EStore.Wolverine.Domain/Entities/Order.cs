using EStore.Wolverine.Domain.Abstract;
using EStore.Wolverine.Domain.Enums;
using EStore.Wolverine.Domain.ValueObjects;

namespace EStore.Wolverine.Domain.Entities;

public class Order : IEntity
{
    private Order()
    {
    }

    public Order(DateTimeOffset createdAt, string email, Address address,
        IEnumerable<OrderLine> lines)
    {
        CreatedAt = createdAt;
        Email = email;
        Address = address;
        Status = OrderStatus.New;
        OrderLines = lines.ToList();
    }

    public long Id { get; init; }
    
    public DateTimeOffset CreatedAt { get; private set; }
    
    public OrderStatus Status { get; private set; }

    public string Email { get; private set; } = default!;

    public Address Address { get; private set; } = default!;

    public IList<OrderLine> OrderLines { get; private set; } = new List<OrderLine>();

    public void MarkOrderAsPaid()
    {
        if (Status != OrderStatus.New)
        {
            throw new InvalidOperationException("Order can't be mark as paid unless it's new");
        }

        Status = OrderStatus.Paid;
    }

    public void MarkAsPrepared()
    {
        if (Status != OrderStatus.Paid)
        {
            throw new InvalidOperationException("Order can't be marked as prepared unless it was paid");
        }

        Status = OrderStatus.Prepared;
    }

    public void MarkAsSent()
    {
        if (Status != OrderStatus.Prepared)
        {
            throw new InvalidOperationException("Order can't be marked as sent unless it was prepared");
        }

        Status = OrderStatus.Sent;
    }

    public void MarkAsDelivered()
    {
        if (Status != OrderStatus.Sent)
        {
            throw new InvalidOperationException("Order can't be marked as delivered unless it was sent");
        }

        Status = OrderStatus.Delivered;
    }
    
    public void MarkAsReturned()
    {
        if (Status != OrderStatus.Sent)
        {
            throw new InvalidOperationException("Order can't be marked as returned unless it was sent");
        }

        Status = OrderStatus.Returned;
    }

    public void MarkAsCancelled()
    {
        if (Status is OrderStatus.Delivered)
        {
            throw new InvalidOperationException("Order that was either delivered or sent can't be cancelled");
        }
        
        Status = OrderStatus.Cancelled;
    }

}
