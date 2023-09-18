// <auto-generated/>
#pragma warning disable
using Microsoft.EntityFrameworkCore;

namespace Internal.Generated.WolverineHandlers
{
    // START: MarkShipmentAsReturnedCommandHandler631158596
    public class MarkShipmentAsReturnedCommandHandler631158596 : Wolverine.Runtime.Handlers.MessageHandler
    {
        private readonly Microsoft.EntityFrameworkCore.DbContextOptions<EStore.Wolverine.Infrastructure.Database.Contexts.EStoreDbContext> _dbContextOptions;

        public MarkShipmentAsReturnedCommandHandler631158596(Microsoft.EntityFrameworkCore.DbContextOptions<EStore.Wolverine.Infrastructure.Database.Contexts.EStoreDbContext> dbContextOptions)
        {
            _dbContextOptions = dbContextOptions;
        }



        public override async System.Threading.Tasks.Task HandleAsync(Wolverine.Runtime.MessageContext context, System.Threading.CancellationToken cancellation)
        {
            var markShipmentAsReturnedCommandHandler = new EStore.Wolverine.Application.CommandHandlers.Shipments.MarkShipmentAsReturnedCommandHandler();
            await using var eStoreDbContext = new EStore.Wolverine.Infrastructure.Database.Contexts.EStoreDbContext(_dbContextOptions);
            var shipmentRepository = new EStore.Wolverine.Infrastructure.Database.Repositories.ShipmentRepository(eStoreDbContext);
            var markShipmentAsReturnedCommand = (EStore.Wolverine.Contracts.Commands.Shipments.MarkShipmentAsReturnedCommand)context.Envelope.Message;
            
            // Enroll the DbContext & IMessagingContext in the outgoing Wolverine outbox transaction
            var envelopeTransaction = Wolverine.EntityFrameworkCore.WolverineEntityCoreExtensions.BuildTransaction(eStoreDbContext, context);
            await context.EnlistInOutboxAsync(envelopeTransaction);
            await markShipmentAsReturnedCommandHandler.Handle(markShipmentAsReturnedCommand, cancellation, shipmentRepository, context).ConfigureAwait(false);
            
            // Added by EF Core Transaction Middleware
            var result_of_SaveChangesAsync = await eStoreDbContext.SaveChangesAsync(cancellation).ConfigureAwait(false);

            // If we have separate context for outbox and application, the we need to manually commit the transaction
            if (envelopeTransaction is Wolverine.EntityFrameworkCore.Internals.RawDatabaseEnvelopeTransaction rawTx) { await rawTx.CommitAsync(); }
        }

    }

    // END: MarkShipmentAsReturnedCommandHandler631158596
    
    
}

