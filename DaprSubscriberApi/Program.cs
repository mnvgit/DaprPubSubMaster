using Dapr;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddDapr();
var app = builder.Build();

app.MapPost("/orders", [Topic("pubsub", "orders")] (Order order, ILogger<Program> logger) =>
{
    logger.LogInformation("Received: {Id} at {Time}", order.Id, order.Timestamp);
    // simulate DB save or other processing...
    return Results.Ok();
});

app.MapSubscribeHandler();

await app.RunAsync();

public record Order(int Id, DateTime Timestamp);
