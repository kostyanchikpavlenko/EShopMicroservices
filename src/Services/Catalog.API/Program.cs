var builder = WebApplication.CreateBuilder(args);

//Add service

var app = builder.Build();

//Configure http request pipeline

app.Run();
