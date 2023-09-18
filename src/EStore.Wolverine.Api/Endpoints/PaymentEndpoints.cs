using EStore.Wolverine.Contracts.Commands.Payments;
using EStore.Wolverine.Contracts.Results.Common;
using Microsoft.AspNetCore.Mvc;
using Wolverine;
using Wolverine.Http;

namespace EStore.Wolverine.Api.Endpoints;

public static class PaymentEndpoints
{
    [WolverinePost("/api/v1/payments")]
    public static async Task<CreatedResult<long>> CreateAsync(CreatePaymentCommand command, [FromServices] IMessageBus bus)
    {
        var response = await bus.InvokeAsync<CreatedResult<long>>(command);

        return response;
    }
}
