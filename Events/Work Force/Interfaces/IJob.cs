namespace WorkForce.JobManagementSystem.Interfaces
{
    using WorkForce.JobManagementSystem.Models;

    // Represents a contract for a Job in the system
    // A Job is a unit of work that decreases over time until completion

    // Why interface?
    // - Allows different job implementations if needed
    // - Enables event-driven architecture (JobDone event)
    // - Keeps Engine independent from concrete Job class

    public interface IJob
    {
        // Event triggered when the job is completed
        // Subscribers (Engine / other systems) can react when job finishes
        event JobDoneEventHandler JobDone;

        // Name/identifier of the job
        string Name { get; }

        // Remaining work hours needed to complete the job
        int RequiredHoursOfWork { get; }

        // Updates job progress (reduces remaining hours)
        void Update();
    }
}