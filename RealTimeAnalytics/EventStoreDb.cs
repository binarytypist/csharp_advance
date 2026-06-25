using EventStore.Client;
using System.Text.Json;

namespace RealTimeAnalytics
{
    /// <summary>
    /// Implementation of IEventStore using EventStoreDB.
    /// Responsible for persisting domain events into event streams.
    /// </summary>
    public class EventStoreDb : IEventStore
    {
        // EventStoreDB client used to communicate with EventStore server
        private readonly EventStoreClient _client;

        public EventStoreDb(EventStoreClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Appends a domain event to a specific stream in EventStoreDB.
        /// Each stream usually represents an aggregate (e.g. device-123)
        /// </summary>
        public async Task AppendAsync(string streamId, IDomainEvent evt)
        {
            // Convert domain event into EventStoreDB event format
            var eventData = new EventStore.Client.EventData(
                Uuid.NewUuid(), // unique event ID

                // Event type name (used for filtering in projections)
                evt.GetType().Name,

                // Serialize event payload to JSON bytes
                JsonSerializer.SerializeToUtf8Bytes(evt)
            );

            // Append event to stream
            await _client.AppendToStreamAsync(
                streamId,          // e.g. "device-123"
                StreamState.Any,   // no optimistic concurrency check
                new[] { eventData } // list of events to append
            );
        }
    }
}