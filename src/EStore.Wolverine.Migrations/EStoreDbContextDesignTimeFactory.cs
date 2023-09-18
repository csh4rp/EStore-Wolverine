using EStore.Wolverine.Infrastructure.Database.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EStore.Wolverine.Migrations;

internal sealed class EStoreDbContextDesignTimeFactory : IDesignTimeDbContextFactory<EStoreDbContext>
{
    public EStoreDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<EStoreDbContext>();

        optionsBuilder.UseSqlServer(args[0], o =>
        {
            o.MigrationsAssembly("EStore.Wolverine.Migrations");
        });

        return new EStoreDbContext(optionsBuilder.Options);
    }
}
