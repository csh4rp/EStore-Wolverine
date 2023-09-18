using EStore.Wolverine.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EStore.Wolverine.Infrastructure.Database.EntityConfigurations;

internal sealed class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Ean)
            .IsRequired()
            .HasMaxLength(64);

        builder.Property(b => b.Name)
            .IsRequired()
            .HasMaxLength(128);

        builder.Property(b => b.Description)
            .IsRequired()
            .HasMaxLength(2000);

        builder.OwnsOne(b => b.UnitPrice, b =>
        {
            b.Property(p => p.Value).HasPrecision(3);
            b.ToJson();
        });
    }
}
