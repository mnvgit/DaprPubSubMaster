using Dapr.Client;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DaprPublisherWorker
{
    public record Order(int Id, DateTime Timestamp);

    public class PublisherWorker : BackgroundService
    {
        private readonly DaprClient _dapr;
        private readonly ILogger<PublisherWorker> _logger;

        public PublisherWorker(ILogger<PublisherWorker> logger, DaprClient dapr)
        {
            _logger = logger;
            _dapr = dapr;
        }

        protected override async Task ExecuteAsync(CancellationToken ct)
        {
            int counter = 0;
            while (!ct.IsCancellationRequested)
            {
                var msg = new Order(counter++, DateTime.UtcNow);
                await _dapr.PublishEventAsync("pubsub", "orders", msg, ct);
                _logger.LogInformation("Published: {msg}", msg);
                await Task.Delay(5000, ct); // every 5s
            }
        }
    }
}
