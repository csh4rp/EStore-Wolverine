using EStore.Wolverine.Domain.Abstract;
using EStore.Wolverine.Domain.ValueObjects;

namespace EStore.Wolverine.Domain.Entities;

public class Product : IEntity
{
    private Product()
    {
    }

    public Product(DateTimeOffset createdAt, string ean, string name, string description, Money unitPrice)
    {
        CreatedAt = createdAt;
        Ean = ean;
        Name = name;
        Description = description;
        UnitPrice = unitPrice;
    }

    public long Id { get; init; }
    
    public DateTimeOffset CreatedAt { get; private set; }

    public string Ean { get; private set; } = default!;

    public string Name { get; private set; } = default!;

    public string Description { get; private set; } = default!;

    public Money UnitPrice { get; private set; } = default!;
}
