// <auto-generated/>
#pragma warning disable
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Internal.Generated.WolverineHandlers
{
    // START: ShipmentPreparedHandler1881770509
    public class ShipmentPreparedHandler1881770509 : Wolverine.Runtime.Handlers.MessageHandler
    {
        private readonly Microsoft.EntityFrameworkCore.DbContextOptions<EStore.Wolverine.Infrastructure.Database.Contexts.EStoreDbContext> _dbContextOptions;
        private readonly Microsoft.Extensions.Logging.ILogger<EStore.Wolverine.Application.EventHandlers.Shipments.ShipmentPreparedEventHandler> _logger;

        public ShipmentPreparedHandler1881770509(Microsoft.EntityFrameworkCore.DbContextOptions<EStore.Wolverine.Infrastructure.Database.Contexts.EStoreDbContext> dbContextOptions, Microsoft.Extensions.Logging.ILogger<EStore.Wolverine.Application.EventHandlers.Shipments.ShipmentPreparedEventHandler> logger)
        {
            _dbContextOptions = dbContextOptions;
            _logger = logger;
        }



        public override async System.Threading.Tasks.Task HandleAsync(Wolverine.Runtime.MessageContext context, System.Threading.CancellationToken cancellation)
        {
            var shipmentPreparedEventHandler = new EStore.Wolverine.Application.EventHandlers.Shipments.ShipmentPreparedEventHandler();
            await using var eStoreDbContext = new EStore.Wolverine.Infrastructure.Database.Contexts.EStoreDbContext(_dbContextOptions);
            var orderRepository = new EStore.Wolverine.Infrastructure.Database.Repositories.OrderRepository(eStoreDbContext);
            var shipmentPrepared = (EStore.Wolverine.Domain.Events.ShipmentPrepared)context.Envelope.Message;
            
            // Enroll the DbContext & IMessagingContext in the outgoing Wolverine outbox transaction
            var envelopeTransaction = Wolverine.EntityFrameworkCore.WolverineEntityCoreExtensions.BuildTransaction(eStoreDbContext, context);
            await context.EnlistInOutboxAsync(envelopeTransaction);
            await shipmentPreparedEventHandler.Handle(shipmentPrepared, cancellation, orderRepository, _logger).ConfigureAwait(false);
            
            // Added by EF Core Transaction Middleware
            var result_of_SaveChangesAsync = await eStoreDbContext.SaveChangesAsync(cancellation).ConfigureAwait(false);

            // If we have separate context for outbox and application, the we need to manually commit the transaction
            if (envelopeTransaction is Wolverine.EntityFrameworkCore.Internals.RawDatabaseEnvelopeTransaction rawTx) { await rawTx.CommitAsync(); }
        }

    }

    // END: ShipmentPreparedHandler1881770509
    
    
}
