using EStore.Wolverine.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EStore.Wolverine.Infrastructure.Database.Contexts;

public sealed class EStoreDbContext : DbContext
{
    public EStoreDbContext(DbContextOptions<EStoreDbContext> options) : base(options)
    {
    }

    public DbSet<Order> Orders { get; set; } = default!;

    public DbSet<Product> Products { get; set; } = default!;

    public DbSet<Shipment> Shipments { get; set; } = default!;
    
    public DbSet<Payment> Payments { get; set; } = default!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EStoreDbContext).Assembly);
    }
}
