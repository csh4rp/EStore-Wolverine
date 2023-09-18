using EStore.Wolverine.Contracts.Models.Common;

namespace EStore.Wolverine.Contracts.Models.Orders;

public record OrderLineModel
{
    public required long ProductId { get; init; }
    
    public required int Quantity { get; init; }
    
    public required MoneyModel UnitPrice { get; init; }
}
