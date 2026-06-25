namespace RealTimeAnalytics
{
    /// <summary>
    /// Domain event representing a metric produced by a device.
    /// This is the core event that flows through the entire system:
    /// API → EventStore → Kafka → InfluxDB → SignalR → Angular
    /// </summary>
    public record MetricReceivedEvent(
        string DeviceId,
        string MetricName,
        double Value,
        DateTime Timestamp
    ) : IDomainEvent
    {
        // Unique identifier for this event instance
        public Guid EventId { get; } = Guid.NewGuid();

        // When the event was created in the system (server time)
        public DateTime OccurredAt { get; } = DateTime.UtcNow;
    }
}