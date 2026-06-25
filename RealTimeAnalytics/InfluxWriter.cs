using InfluxDB.Client;
using InfluxDB.Client.Writes;
using InfluxDB.Client.Api.Domain;

namespace RealTimeAnalytics
{
    /// <summary>
    /// Writes metric data into InfluxDB (time-series database).
    /// Used for analytics dashboards (charts, Grafana, etc.)
    /// </summary>
    public class InfluxWriter : IInfluxWriter
    {
        // InfluxDB client used to communicate with the database
        private readonly InfluxDBClient _client;

        public InfluxWriter(InfluxDBClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Writes a single metric event into InfluxDB as a time-series point.
        /// </summary>
        public async Task WriteAsync(MetricReceivedEvent e)
        {
            // Convert domain event into InfluxDB "Point"
            var point = PointData
                .Measurement(e.MetricName)        // metric name becomes measurement
                .Tag("device", e.DeviceId)        // tag for filtering/grouping
                .Field("value", e.Value)          // numeric value stored
                .Timestamp(e.Timestamp, WritePrecision.Ns); // time axis

            // Create write API (simple blocking writer)
            using var writeApi = _client.GetWriteApi();

            // Write into bucket: "analytics", org: "metrics"
            writeApi.WritePoint(point, "metrics", "analytics");

            await Task.CompletedTask;
        }

        /// <summary>
        /// Writes multiple metrics in batch (faster for high throughput systems).
        /// </summary>
        public Task WriteBatchAsync(IEnumerable<MetricReceivedEvent> metrics)
        {
            throw new NotImplementedException();
        }
    }
}