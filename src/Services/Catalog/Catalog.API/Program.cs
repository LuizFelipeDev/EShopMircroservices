var builder = WebApplication.CreateBuilder(args);

//Add services to the container

builder.Services.AddCarter();

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});
builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();

var app = builder.Build();
//app.Logger.LogInformation("Carter module routes are registered.");  // Adiciona um log para verificar se os endpoints estão mapeados
//app.MapGet("/test", () => Results.Ok("Application is running"));
//Configure the HTTP request pipeline
app.MapCarter();

app.Run();
