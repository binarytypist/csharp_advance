using Microsoft.AspNetCore.SignalR;
using MediatR;

namespace RealTimeAnalytics
{
    public class IngestMetricHandler : IRequestHandler<IngestMetricCommand>
    {
        private readonly IEventStore _eventStore;
        private readonly IHubContext<MetricsHub> _hub;

        public IngestMetricHandler(IEventStore eventStore, IHubContext<MetricsHub> hub)
        {
            _eventStore = eventStore;
            _hub = hub;
        }

        public async Task Handle(IngestMetricCommand request, CancellationToken ct)
        {
            // Create a domain event from the incoming request
            var evt = new MetricReceivedEvent(
                request.DeviceId,
                request.MetricName,
                request.Value,
                DateTime.UtcNow
            );

            // 1. Persist the event into EventStore (source of truth / event sourcing)
            await _eventStore.AppendAsync($"device-{request.DeviceId}", evt);

            // 2. Push real-time update to all connected Angular clients via SignalR
            await _hub.Clients.All.SendAsync("metric-update", new
            {
                deviceId = request.DeviceId,
                metricName = request.MetricName,
                value = request.Value,
                timestamp = DateTime.UtcNow
            });
        }
    }
}