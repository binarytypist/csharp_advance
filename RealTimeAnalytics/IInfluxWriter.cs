namespace RealTimeAnalytics
{
    /// <summary>
    /// Abstraction layer for writing metrics into InfluxDB (time-series database).
    /// This allows the system to separate analytics storage from business logic.
    /// </summary>
    public interface IInfluxWriter
    {
        /// <summary>
        /// Writes a single metric event into InfluxDB.
        /// </summary>
        /// <param name="metric">
        /// The metric event containing device data, metric name, value, and timestamp.
        /// </param>
        Task WriteAsync(MetricReceivedEvent metric);

        /// <summary>
        /// Writes multiple metric events in a batch for better performance.
        /// Useful when processing high-throughput streams.
        /// </summary>
        /// <param name="metrics">
        /// Collection of metric events to persist in one operation.
        /// </param>
        Task WriteBatchAsync(IEnumerable<MetricReceivedEvent> metrics);
    }
}