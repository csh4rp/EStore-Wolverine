using EStore.Wolverine.Domain.Entities;
using EStore.Wolverine.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EStore.Wolverine.Infrastructure.Database.EntityConfigurations;

internal sealed class OrderEntityConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Email)
            .IsRequired()
            .HasMaxLength(128);

        builder.Property(b => b.Status)
            .IsRequired()
            .HasMaxLength(16)
            .HasConversion(b => b.ToString(), b => Enum.Parse<OrderStatus>(b));

        builder.OwnsOne(b => b.Address, b =>
        {
            b.ToJson();
        });

        builder.OwnsMany(b => b.OrderLines, b =>
        {
            b.ToJson();

            b.OwnsOne(o => o.UnitPrice, c =>
                {
                    c.Property(p => p.Value).HasPrecision(3);
                })
                .ToJson();
        });
    }
}
