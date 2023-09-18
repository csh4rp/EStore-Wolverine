using System.Runtime.CompilerServices;
using EStore.Wolverine.Domain.Repositories;
using EStore.Wolverine.Infrastructure.Database.Contexts;
using EStore.Wolverine.Infrastructure.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Wolverine.EntityFrameworkCore;

[assembly: InternalsVisibleTo("EStore.Wolverine.Migrations")]

namespace EStore.Wolverine.Infrastructure.Database;

public static class DatabaseExtensions
{
    public static IServiceCollection AddDatabaseServices(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        serviceCollection.AddScoped<IProductRepository, ProductRepository>()
            .AddScoped<IOrderRepository, OrderRepository>()
            .AddScoped<IShipmentRepository, ShipmentRepository>()
            .AddScoped<IPaymentRepository, PaymentRepository>();
        
        return serviceCollection;
    }
}
