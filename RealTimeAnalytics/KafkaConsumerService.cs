using Confluent.Kafka;

namespace RealTimeAnalytics;

/// <summary>
/// Background service that consumes Kafka messages
/// and writes them into InfluxDB for analytics storage.
/// </summary>
public class KafkaConsumerService : BackgroundService
{
    // Kafka consumer used to read messages from topic
    private readonly IConsumer<string, string> _consumer;

    // Influx writer used to store metrics in time-series database
    private readonly IInfluxWriter _influx;

    public KafkaConsumerService(IConfiguration config, IInfluxWriter influx)
    {
        _influx = influx;

        // Kafka consumer configuration
        var consumerConfig = new ConsumerConfig
        {
            // Kafka broker address (from appsettings.json)
            BootstrapServers = config["Kafka:BootstrapServers"],

            // Consumer group (enables load balancing across instances)
            GroupId = "analytics-service",

            // Start from earliest message if no offset exists
            AutoOffsetReset = AutoOffsetReset.Earliest
        };

        // Create Kafka consumer instance
        _consumer = new ConsumerBuilder<string, string>(consumerConfig).Build();

        // Subscribe to Kafka topic that contains metric events
        _consumer.Subscribe("metrics-events");
    }

    /// <summary>
    /// Main background loop that continuously consumes Kafka messages
    /// </summary>
    protected override async Task ExecuteAsync(CancellationToken ct)
    {
        while (!ct.IsCancellationRequested)
        {
            // Wait for next Kafka message
            var result = _consumer.Consume(ct);

            // Deserialize JSON payload into domain event
            var metric = System.Text.Json.JsonSerializer
                .Deserialize<MetricReceivedEvent>(result.Message.Value);

            // If deserialization succeeds, write to InfluxDB
            if (metric != null)
            {
                await _influx.WriteAsync(metric);
            }
        }
    }
}