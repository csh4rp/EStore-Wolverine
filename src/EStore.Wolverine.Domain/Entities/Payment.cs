using EStore.Wolverine.Domain.Abstract;

namespace EStore.Wolverine.Domain.Entities;

public class Payment : IEntity
{
    private Payment()
    {
    }

    public Payment(DateTimeOffset createdAt, long orderId)
    {
        CreatedAt = createdAt;
        OrderId = orderId;
    }

    public long Id { get; init; }
    
    public DateTimeOffset CreatedAt { get; private set; }
    
    public long OrderId { get; private set; }
}
