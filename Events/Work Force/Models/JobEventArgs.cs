using System;
using WorkForce.JobManagementSystem.Interfaces;

namespace WorkForce.JobManagementSystem.Models
{
    // Custom event arguments class for Job-related events
    // Inherits from EventArgs (standard base class for .NET events)

    // Why do we need this?
    // - To pass additional data when an event is triggered
    // - In this case, we send the Job object itself
    // - Allows subscribers (Engine) to know which job finished

    public class JobEventArgs : EventArgs
    {
        // Constructor receives the job that triggered the event
        public JobEventArgs(IJob job)
        {
            this.Job = job;
        }

        // Read-only property holding the job instance
        public IJob Job { get; }
    }
}