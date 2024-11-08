using System.Reflection;
using Marten;

var builder = WebApplication.CreateBuilder(args);

//Add service
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

builder.Services.AddMarten(opt =>
{
    opt.Connection(builder.Configuration.GetConnectionString("Database")!);
})
.UseLightweightSessions();

var app = builder.Build();

app.MapCarter();

//Configure http request pipeline

app.Run();
