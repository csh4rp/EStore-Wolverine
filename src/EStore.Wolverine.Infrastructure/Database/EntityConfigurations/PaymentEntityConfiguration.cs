using EStore.Wolverine.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EStore.Wolverine.Infrastructure.Database.EntityConfigurations;

internal sealed class PaymentEntityConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.HasKey(b => b.Id);

        builder.HasOne<Order>()
            .WithMany()
            .HasForeignKey(b => b.OrderId);
    }
}
