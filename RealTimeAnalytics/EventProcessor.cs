using EventStore.Client;
using Microsoft.AspNetCore.SignalR;
using RealTimeAnalytics;
using System.Text;
using System.Text.Json;

/// <summary>
/// Background service that listens to EventStoreDB in real time
/// and forwards events to Kafka + SignalR.
/// </summary>
public class EventProcessor : BackgroundService
{
    // EventStore client used to subscribe to event stream
    private readonly EventStoreClient _client;

    // Kafka publisher used to forward events to Kafka topic
    private readonly KafkaEventPublisher _kafka;

    // SignalR hub context used to push real-time updates to Angular clients
    private readonly IHubContext<MetricsHub> _hub;

    public EventProcessor(
        EventStoreClient client,
        KafkaEventPublisher kafka,
        IHubContext<MetricsHub> hub)
    {
        _client = client;
        _kafka = kafka;
        _hub = hub;
    }

    /// <summary>
    /// Main background execution loop
    /// Runs continuously for the lifetime of the application
    /// </summary>
    protected override async Task ExecuteAsync(CancellationToken ct)
    {
        // Subscribe to ALL events in EventStoreDB starting from the beginning
        await _client.SubscribeToAllAsync(
            FromAll.Start,
            async (subscription, resolvedEvent, token) =>
            {
                // Read event type name (e.g. MetricReceivedEvent)
                var evtType = resolvedEvent.Event.EventType;

                // Ignore all events except MetricReceivedEvent
                if (evtType != "MetricReceivedEvent")
                    return;

                // Convert event data (byte[]) → string (JSON)
                var data = resolvedEvent.Event.Data.ToArray();
                var json = Encoding.UTF8.GetString(data);

                // Deserialize JSON into strongly typed object
                var metric = JsonSerializer.Deserialize<MetricReceivedEvent>(json);

                // If deserialization fails, skip event
                if (metric == null)
                    return;

                // =====================================================
                // 1. Send event to Kafka topic (for streaming pipeline)
                // =====================================================
                await _kafka.PublishAsync("metrics-events", json);

                // =====================================================
                // 2. Push real-time update to all connected clients
                // (Angular dashboard receives this instantly)
                // =====================================================
                await _hub.Clients.All.SendAsync(
                    "metric-update",
                    metric,
                    token);
            },
            cancellationToken: ct
        );

        // Keep service alive forever (prevents exit)
        await Task.Delay(Timeout.Infinite, ct);
    }
}