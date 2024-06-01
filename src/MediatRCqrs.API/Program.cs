using MediatRCqrs.API.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly));
builder.Services.AddSingleton<FakeDataStore>();

var app = builder.Build();

app.UseHttpsRedirection();


app.MapControllers();

app.Run();