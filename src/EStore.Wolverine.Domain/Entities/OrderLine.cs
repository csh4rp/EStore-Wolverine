using EStore.Wolverine.Domain.ValueObjects;

namespace EStore.Wolverine.Domain.Entities;

public class OrderLine
{
    private OrderLine()
    {
    }

    public OrderLine(long productId, int quantity, Money unitPrice)
    {
        ProductId = productId;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }
    
    public long ProductId { get; private set; }
    
    public int Quantity { get; private set; }

    public Money UnitPrice { get; private set; } = default!;
}
