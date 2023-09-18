using EStore.Wolverine.Domain.Entities;
using EStore.Wolverine.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EStore.Wolverine.Infrastructure.Database.EntityConfigurations;

internal sealed class ShipmentEntityConfiguration : IEntityTypeConfiguration<Shipment>
{
    public void Configure(EntityTypeBuilder<Shipment> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Status)
            .IsRequired()
            .HasMaxLength(16)
            .HasConversion(b => b.ToString(), b => Enum.Parse<ShipmentStatus>(b));

        builder.HasOne<Order>()
            .WithMany()
            .HasForeignKey(b => b.OrderId);
    }
}
