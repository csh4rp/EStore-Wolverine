using EStore.Wolverine.Contracts.Commands.Products;
using EStore.Wolverine.Contracts.Results.Common;
using Microsoft.AspNetCore.Mvc;
using Wolverine;
using Wolverine.Http;

namespace EStore.Wolverine.Api.Endpoints;

public static class ProductEndpoints
{
    [WolverinePost("/api/v1/products")]
    public static async Task<CreatedResult<long>> CreateAsync(CreateProductCommand command, [FromServices] IMessageBus bus)
    {
        var response = await bus.InvokeAsync<CreatedResult<long>>(command);

        return response;
    }
}
