// <auto-generated/>
#pragma warning disable
using Microsoft.AspNetCore.Routing;
using System;
using System.Linq;
using Wolverine.Http;
using Wolverine.Runtime;

namespace Internal.Generated.WolverineHandlers
{
    // START: POST_api_v1_shipments
    public class POST_api_v1_shipments : Wolverine.Http.HttpHandler
    {
        private readonly Wolverine.Http.WolverineHttpOptions _wolverineHttpOptions;
        private readonly Wolverine.Runtime.IWolverineRuntime _wolverineRuntime;

        public POST_api_v1_shipments(Wolverine.Http.WolverineHttpOptions wolverineHttpOptions, Wolverine.Runtime.IWolverineRuntime wolverineRuntime) : base(wolverineHttpOptions)
        {
            _wolverineHttpOptions = wolverineHttpOptions;
            _wolverineRuntime = wolverineRuntime;
        }



        public override async System.Threading.Tasks.Task Handle(Microsoft.AspNetCore.Http.HttpContext httpContext)
        {
            var messageContext = new Wolverine.Runtime.MessageContext(_wolverineRuntime);
            Wolverine.Http.Runtime.RequestIdMiddleware.Apply(httpContext, ((Wolverine.IMessageContext)messageContext));
            var (command, jsonContinue) = await ReadJsonAsync<EStore.Wolverine.Contracts.Commands.Shipments.CreateShipmentCommand>(httpContext);
            if (jsonContinue == Wolverine.HandlerContinuation.Stop) return;
            var createdResult_response = await EStore.Wolverine.Api.Endpoints.ShipmentEndpoints.CreateAsync(command, ((Wolverine.IMessageBus)messageContext)).ConfigureAwait(false);
            await WriteJsonAsync(httpContext, createdResult_response);
        }

    }

    // END: POST_api_v1_shipments
    
    
}

