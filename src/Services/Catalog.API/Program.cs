using BuildingBlocks.Behaviors;

var builder = WebApplication.CreateBuilder(args);

//Add service
builder.Services.AddCarter();

var assembly = typeof(Program).Assembly;

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
});

builder.Services.AddMarten(opt =>
{
    opt.Connection(builder.Configuration.GetConnectionString("Database")!);
})
.UseLightweightSessions();

builder.Services.AddValidatorsFromAssembly(assembly);

var app = builder.Build();

app.MapCarter();

//Configure http request pipeline

app.Run();
