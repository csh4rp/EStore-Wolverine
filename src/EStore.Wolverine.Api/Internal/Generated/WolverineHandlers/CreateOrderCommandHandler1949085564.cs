// <auto-generated/>
#pragma warning disable
using Microsoft.EntityFrameworkCore;

namespace Internal.Generated.WolverineHandlers
{
    // START: CreateOrderCommandHandler1949085564
    public class CreateOrderCommandHandler1949085564 : Wolverine.Runtime.Handlers.MessageHandler
    {
        private readonly Microsoft.EntityFrameworkCore.DbContextOptions<EStore.Wolverine.Infrastructure.Database.Contexts.EStoreDbContext> _dbContextOptions;

        public CreateOrderCommandHandler1949085564(Microsoft.EntityFrameworkCore.DbContextOptions<EStore.Wolverine.Infrastructure.Database.Contexts.EStoreDbContext> dbContextOptions)
        {
            _dbContextOptions = dbContextOptions;
        }



        public override async System.Threading.Tasks.Task HandleAsync(Wolverine.Runtime.MessageContext context, System.Threading.CancellationToken cancellation)
        {
            await using var eStoreDbContext = new EStore.Wolverine.Infrastructure.Database.Contexts.EStoreDbContext(_dbContextOptions);
            var orderRepository = new EStore.Wolverine.Infrastructure.Database.Repositories.OrderRepository(eStoreDbContext);
            var createOrderCommand = (EStore.Wolverine.Contracts.Commands.Orders.CreateOrderCommand)context.Envelope.Message;
            
            // Enroll the DbContext & IMessagingContext in the outgoing Wolverine outbox transaction
            var envelopeTransaction = Wolverine.EntityFrameworkCore.WolverineEntityCoreExtensions.BuildTransaction(eStoreDbContext, context);
            await context.EnlistInOutboxAsync(envelopeTransaction);
            var outgoing1 = await EStore.Wolverine.Application.CommandHandlers.Orders.CreateOrderCommandHandler.Handle(createOrderCommand, cancellation, orderRepository, context).ConfigureAwait(false);
            
            // Outgoing, cascaded message
            await context.EnqueueCascadingAsync(outgoing1).ConfigureAwait(false);

            
            // Added by EF Core Transaction Middleware
            var result_of_SaveChangesAsync = await eStoreDbContext.SaveChangesAsync(cancellation).ConfigureAwait(false);

            // If we have separate context for outbox and application, the we need to manually commit the transaction
            if (envelopeTransaction is Wolverine.EntityFrameworkCore.Internals.RawDatabaseEnvelopeTransaction rawTx) { await rawTx.CommitAsync(); }
        }

    }

    // END: CreateOrderCommandHandler1949085564
    
    
}

