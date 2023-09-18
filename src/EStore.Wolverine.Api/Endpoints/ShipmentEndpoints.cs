using EStore.Wolverine.Contracts.Commands.Shipments;
using EStore.Wolverine.Contracts.Results.Common;
using Wolverine;
using Wolverine.Http;

namespace EStore.Wolverine.Api.Endpoints;

public static class ShipmentEndpoints
{
    [WolverinePost("/api/v1/shipments")]
    public static async Task<CreatedResult<long>> CreateAsync(CreateShipmentCommand command, IMessageBus bus)
    {
        var result = await bus.InvokeAsync<CreatedResult<long>>(command);

        return result;
    }
    
    [WolverinePost("/api/v1/shipments/{shipmentId}/mark-as-sent")]
    public static async Task MarkAsSentAsync(long shipmentId, IMessageBus bus)
    {
        await bus.InvokeAsync<CreatedResult<long>>(new MarkShipmentAsSentCommand(shipmentId));
    }
    
    [WolverinePost("/api/v1/shipments/{shipmentId}/mark-as-delivered")]
    public static async Task MarkAsDeliveredAsync(long shipmentId, IMessageBus bus)
    {
        await bus.InvokeAsync<CreatedResult<long>>(new MarkShipmentAsDeliveredCommand(shipmentId));
    }
    
    [WolverinePost("/api/v1/shipments/{shipmentId}/mark-as-returned")]
    public static async Task MarkAsReturnedAsync(long shipmentId, IMessageBus bus)
    {
        await bus.InvokeAsync<CreatedResult<long>>(new MarkShipmentAsReturnedCommand(shipmentId));
    }
}
