using Confluent.Kafka;
using System.Text.Json;

namespace RealTimeAnalytics;

/// <summary>
/// Publishes events/messages to Kafka topics.
/// Used to decouple event production from event consumption.
/// </summary>
public class KafkaEventPublisher
{
    // Kafka producer used to send messages to Kafka broker
    private readonly IProducer<string, string> _producer;

    public KafkaEventPublisher(IConfiguration config)
    {
        // Kafka producer configuration
        var kafkaConfig = new ProducerConfig
        {
            // Kafka broker address (from configuration)
            BootstrapServers = config["Kafka:BootstrapServers"]
        };

        // Create Kafka producer instance
        _producer = new ProducerBuilder<string, string>(kafkaConfig).Build();
    }

    /// <summary>
    /// Publishes an event to a Kafka topic.
    /// </summary>
    /// <param name="topic">Kafka topic name</param>
    /// <param name="evt">Event object to serialize and send</param>
    public async Task PublishAsync(string topic, object evt)
    {
        // Convert object into JSON string for transport
        var message = new Message<string, string>
        {
            // Unique key for partitioning (optional but useful for ordering)
            Key = Guid.NewGuid().ToString(),

            // Serialized event payload
            Value = JsonSerializer.Serialize(evt)
        };

        // Send message to Kafka asynchronously
        await _producer.ProduceAsync(topic, message);
    }
}