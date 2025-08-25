using DaprPublisherWorker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddDaprClient();
builder.Services.AddHostedService<PublisherWorker>();
await builder.Build().RunAsync();