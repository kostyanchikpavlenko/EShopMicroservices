using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//Add service
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

var app = builder.Build();

app.MapCarter();

//Configure http request pipeline

app.Run();
