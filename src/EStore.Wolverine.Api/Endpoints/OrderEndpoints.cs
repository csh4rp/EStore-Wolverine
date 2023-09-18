using EStore.Wolverine.Contracts.Commands.Orders;
using EStore.Wolverine.Contracts.Results.Common;
using Microsoft.AspNetCore.Mvc;
using Wolverine;
using Wolverine.Http;

namespace EStore.Wolverine.Api.Endpoints;

public static class OrderEndpoints
{
    [WolverinePost("/api/v1/orders")]
    public static async Task<CreatedResult<long>> CreateAsync(CreateOrderCommand command, [FromServices] IMessageBus bus)
    {
        var response = await bus.InvokeAsync<CreatedResult<long>>(command);

        return response;
    }
    
    [WolverinePost("/api/v1/orders/{orderId}/cancel")]
    public static async Task CancelAsync(long orderId, [FromServices] IMessageBus bus)
    {
        await bus.InvokeAsync(new RequestOrderCancellationCommand(orderId));
    }
}
