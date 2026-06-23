
using System;
using WorkForce.JobManagementSystem.Interfaces;

namespace WorkForce.JobManagementSystem.Models
{
    
    // Delegate defines the signature for Job completion event handlers
    // Any method that matches this signature can handle JobDone event
    public delegate void JobDoneEventHandler(object sender, JobEventArgs args);

    public class Job : IJob
    {
        // Event triggered when job is completed (hours <= 0)
        public event JobDoneEventHandler JobDone;

        private int requiredHoursOfWork;
        private IEmployee employee;

        // Constructor initializes job with name, required hours, and assigned employee
        public Job(string name, int requiredHoursOfWork, IEmployee employee)
        {
            this.Name = name;
            this.requiredHoursOfWork = requiredHoursOfWork;
            this.employee = employee;
        }

        // Job identifier
        public string Name { get; private set; }

        // Remaining work hours property
        public int RequiredHoursOfWork
        {
            get
            {
                return this.requiredHoursOfWork;
            }

            set
            {
                this.requiredHoursOfWork = value;

                // When job is finished (0 or less hours remaining)
                if (this.requiredHoursOfWork <= 0)
                {
                    this.requiredHoursOfWork = 0;

                    // Notify system that job is completed
                    Console.WriteLine($"Job {this.Name} done!");

                    // Trigger event (notify subscribers like Engine)
                    this.JobDone?.Invoke(this, new JobEventArgs(this));
                }
            }
        }

        // Updates job progress by reducing required hours
        public void Update()
        {
            this.RequiredHoursOfWork -= this.employee.WorkHoursPerWeek;
        }

        // Human-readable representation of job state
        public override string ToString()
        {
            return $"Job: {this.Name} Hours Remaining: {this.RequiredHoursOfWork}";
        }
    }
}