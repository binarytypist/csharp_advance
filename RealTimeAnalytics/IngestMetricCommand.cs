using MediatR;

namespace RealTimeAnalytics
{
    public record IngestMetricCommand(
     string DeviceId,
     string MetricName,
     double Value
 ) : IRequest;
}