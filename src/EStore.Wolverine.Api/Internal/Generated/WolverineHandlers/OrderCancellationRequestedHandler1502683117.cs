// <auto-generated/>
#pragma warning disable
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Internal.Generated.WolverineHandlers
{
    // START: OrderCancellationRequestedHandler1502683117
    public class OrderCancellationRequestedHandler1502683117 : Wolverine.Runtime.Handlers.MessageHandler
    {
        private readonly Microsoft.EntityFrameworkCore.DbContextOptions<EStore.Wolverine.Infrastructure.Database.Contexts.EStoreDbContext> _dbContextOptions;
        private readonly Microsoft.Extensions.Logging.ILogger<EStore.Wolverine.Application.EventHandlers.Orders.OrderCancellationRequestedEventHandler> _logger;

        public OrderCancellationRequestedHandler1502683117(Microsoft.EntityFrameworkCore.DbContextOptions<EStore.Wolverine.Infrastructure.Database.Contexts.EStoreDbContext> dbContextOptions, Microsoft.Extensions.Logging.ILogger<EStore.Wolverine.Application.EventHandlers.Orders.OrderCancellationRequestedEventHandler> logger)
        {
            _dbContextOptions = dbContextOptions;
            _logger = logger;
        }



        public override async System.Threading.Tasks.Task HandleAsync(Wolverine.Runtime.MessageContext context, System.Threading.CancellationToken cancellation)
        {
            var orderCancellationRequestedEventHandler = new EStore.Wolverine.Application.EventHandlers.Orders.OrderCancellationRequestedEventHandler();
            await using var eStoreDbContext = new EStore.Wolverine.Infrastructure.Database.Contexts.EStoreDbContext(_dbContextOptions);
            var orderRepository = new EStore.Wolverine.Infrastructure.Database.Repositories.OrderRepository(eStoreDbContext);
            var orderCancellationRequested = (EStore.Wolverine.Domain.Events.OrderCancellationRequested)context.Envelope.Message;
            
            // Enroll the DbContext & IMessagingContext in the outgoing Wolverine outbox transaction
            var envelopeTransaction = Wolverine.EntityFrameworkCore.WolverineEntityCoreExtensions.BuildTransaction(eStoreDbContext, context);
            await context.EnlistInOutboxAsync(envelopeTransaction);
            await orderCancellationRequestedEventHandler.Handle(orderCancellationRequested, cancellation, orderRepository, _logger).ConfigureAwait(false);
            
            // Added by EF Core Transaction Middleware
            var result_of_SaveChangesAsync = await eStoreDbContext.SaveChangesAsync(cancellation).ConfigureAwait(false);

            // If we have separate context for outbox and application, the we need to manually commit the transaction
            if (envelopeTransaction is Wolverine.EntityFrameworkCore.Internals.RawDatabaseEnvelopeTransaction rawTx) { await rawTx.CommitAsync(); }
        }

    }

    // END: OrderCancellationRequestedHandler1502683117
    
    
}

