using EStore.Wolverine.Domain.Entities;

namespace EStore.Wolverine.Domain.Repositories;

public interface IPaymentRepository
{
    Task AddAsync(Payment payment, CancellationToken cancellationToken);
}
