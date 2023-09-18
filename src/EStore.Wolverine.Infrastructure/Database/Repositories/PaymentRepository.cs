using EStore.Wolverine.Domain.Entities;
using EStore.Wolverine.Domain.Repositories;
using EStore.Wolverine.Infrastructure.Database.Contexts;

namespace EStore.Wolverine.Infrastructure.Database.Repositories;

public sealed class PaymentRepository : IPaymentRepository
{
    private readonly EStoreDbContext _dbContext;

    public PaymentRepository(EStoreDbContext dbContext) => _dbContext = dbContext;

    public Task AddAsync(Payment payment, CancellationToken cancellationToken)
    {
        _dbContext.Payments.Add(payment);
        return _dbContext.SaveChangesAsync(cancellationToken);
    }
}
