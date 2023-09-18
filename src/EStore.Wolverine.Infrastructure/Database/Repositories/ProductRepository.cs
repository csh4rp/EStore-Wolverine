using EStore.Wolverine.Domain.Entities;
using EStore.Wolverine.Domain.Repositories;
using EStore.Wolverine.Infrastructure.Database.Contexts;

namespace EStore.Wolverine.Infrastructure.Database.Repositories;

public sealed class ProductRepository : IProductRepository
{
    private readonly EStoreDbContext _dbContext;

    public ProductRepository(EStoreDbContext dbContext) => _dbContext = dbContext;

    public Task AddAsync(Product product, CancellationToken cancellationToken)
    {
        _dbContext.Products.Add(product);
        return _dbContext.SaveChangesAsync(cancellationToken);
    }
}
