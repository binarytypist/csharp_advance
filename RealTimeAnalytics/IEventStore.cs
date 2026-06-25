namespace RealTimeAnalytics
{
    /// <summary>
    /// Abstraction for event storage.
    /// This hides the actual implementation (EventStoreDB, Kafka, etc.)
    /// and allows the system to follow clean architecture principles.
    /// </summary>
    public interface IEventStore
    {
        /// <summary>
        /// Appends (saves) a domain event into a specific stream.
        /// </summary>
        /// <param name="streamId">
        /// The stream identifier (usually represents an aggregate like device-123)
        /// </param>
        /// <param name="evt">
        /// The domain event to store (immutable event data)
        /// </param>
        Task AppendAsync(string streamId, IDomainEvent evt);
    }
}