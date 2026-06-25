using Microsoft.AspNetCore.SignalR;

namespace RealTimeAnalytics
{
    /// <summary>
    /// SignalR Hub used for real-time communication between server and Angular clients.
    /// Clients connect here to receive live metric updates instantly.
    /// </summary>
    public class MetricsHub : Hub
    {
        /// <summary>
        /// Allows a client to subscribe to a specific device group.
        /// This enables filtering updates per device instead of broadcasting to everyone.
        /// </summary>
        /// <param name="deviceId">
        /// The device identifier used as SignalR group name.
        /// </param>
        public Task Subscribe(string deviceId)
        {
            // Add the current connection to a SignalR group based on deviceId
            return Groups.AddToGroupAsync(Context.ConnectionId, deviceId);
        }
    }
}