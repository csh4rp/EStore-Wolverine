using EStore.Wolverine.Contracts.Models.Common;

namespace EStore.Wolverine.Contracts.Commands.Products;

public class CreateProductCommand
{
    public required string Ean { get; init; }
    
    public required string Name { get; init; }
    
    public required string Description { get; init; }
    
    public required MoneyModel UnitPrice { get; init; }
}
