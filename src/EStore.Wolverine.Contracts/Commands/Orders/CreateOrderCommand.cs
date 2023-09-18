using EStore.Wolverine.Contracts.Models.Common;
using EStore.Wolverine.Contracts.Models.Orders;

namespace EStore.Wolverine.Contracts.Commands.Orders;

public record CreateOrderCommand
{
    public required string Email { get; init; }
    
    public required AddressModel Address { get; init; }
    
    public required IReadOnlyList<OrderLineModel> Lines { get; init; }
}
