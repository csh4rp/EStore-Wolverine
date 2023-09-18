using System.Reflection;
using System.Text.Json.Serialization;
using EStore.Wolverine.Infrastructure.Database;
using EStore.Wolverine.Infrastructure.Database.Contexts;
using Humanizer;
using JasperFx.CodeGeneration;
using Microsoft.EntityFrameworkCore;
using Oakton;
using Oakton.Resources;
using Wolverine;
using Wolverine.EntityFrameworkCore;
using Wolverine.Http;
using Wolverine.Http.FluentValidation;
using Wolverine.RabbitMQ;
using Wolverine.SqlServer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDatabaseServices(builder.Configuration);

builder.Services.AddResourceSetupOnStartup();
builder.Services.AddMvcCore();

builder.Host.UseWolverine((cnx, opt) =>
{
    opt.UseRabbitMq(c =>
    {
        c.HostName = cnx.Configuration.GetValue<string>("RabbitMQ:Host");
        c.UserName = cnx.Configuration.GetValue<string>("RabbitMQ:UserName");
        c.Password = cnx.Configuration.GetValue<string>("RabbitMQ:Password");
    }).AutoProvision();

    opt.ListenToRabbitQueue("WolverineQueue")
        .PreFetchCount(100)
        .ListenerCount(5) // use 5 parallel listeners
        .CircuitBreaker(cb =>
        {
            cb.PauseTime = 1.Minutes();
            cb.FailurePercentageThreshold = 10;
        })
        .UseDurableInbox();
    
    opt.PublishAllMessages().ToRabbitExchange("WolverineExchange", e =>
    {
        e.ExchangeType = ExchangeType.Direct;

        e.BindQueue("WolverineQueue");
    }).UseDurableOutbox();
    
    opt.Services.AddDbContextWithWolverineIntegration<EStoreDbContext>(options =>
    {
        options.UseSqlServer(cnx.Configuration.GetConnectionString("SqlServer"));
    });
    
    opt.PersistMessagesWithSqlServer(cnx.Configuration.GetConnectionString("SqlServer")!);
    opt.UseEntityFrameworkCoreTransactions();
    
    opt.Policies.AutoApplyTransactions();
    opt.AutoBuildMessageStorageOnStartup = true;
    opt.CodeGeneration.TypeLoadMode = TypeLoadMode.Static;

    opt.Discovery.IncludeAssembly(Assembly.Load("EStore.Wolverine.Api"));
    opt.Discovery.IncludeAssembly(Assembly.Load("EStore.Wolverine.Application"));
    opt.Discovery.IncludeAssembly(Assembly.Load("EStore.Wolverine.Contracts"));
});

builder.Services.AddResourceSetupOnStartup();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.ApplyOaktonExtensions();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapWolverineEndpoints(a =>
{
    a.UseFluentValidationProblemDetailMiddleware();
});

await app.RunOaktonCommands(args);
