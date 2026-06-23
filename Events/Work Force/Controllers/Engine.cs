
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using WorkForce.JobManagementSystem.Interfaces;
using WorkForce.JobManagementSystem.Models;
using WorkForce.JobManagementSystem.Models.Employees;


namespace WorkForce.JobManagementSystem.Controllers
{

    public class Engine
    {
        // Exception messages
        private const string MissingEmployeeExceptionMessage = "Employee {0} is not available";
        private const string WrongParametersCountInCommandExceptionMessage = "Expected parameters are: {0}";
        private const string CommandNameSuffix = "Command";
        private const string EndCommand = "End";

        // Storage for system state
        private IList<IEmployee> employees;
        private IList<IJob> jobs;

        private IReader reader;
        private IWriter writer;

        // Reflection cache of methods (for dynamic command execution)
        private MethodInfo[] methods;

        public Engine(IReader reader, IWriter writer)
        {
            this.employees = new List<IEmployee>();
            this.jobs = new List<IJob>();
            this.reader = reader;
            this.writer = writer;

            // Load all methods in this class for reflection-based command mapping
            this.methods = this.GetType()
                .GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        }

        public void Run()
        {
            ExecuteCommands();
        }

        private void ExecuteCommands()
        {
            var inputLine = this.reader.ReadLine().Split();

            // Read commands until "End"
            while (inputLine[0] != EndCommand)
            {
                var commandName = inputLine[0] + CommandNameSuffix;

                // Find method matching command name
                var methodForExecution = this.methods
                    .FirstOrDefault(m => m.Name.Equals(commandName, StringComparison.OrdinalIgnoreCase));

                if (methodForExecution != null)
                {
                    // Execute method dynamically
                    InvokeMethod(inputLine.Skip(1).ToArray(), methodForExecution);
                }

                inputLine = this.reader.ReadLine().Split();
            }
        }

        private void InvokeMethod(string[] cmdArgs, MethodInfo methodForExecution)
        {
            var requiredParams = methodForExecution.GetParameters();

            if (cmdArgs.Length < requiredParams.Length)
            {
                throw new ArgumentException(
                    string.Format(WrongParametersCountInCommandExceptionMessage,
                    string.Join(", ", requiredParams.Select(r => r.Name))));
            }

            var parsedParams = new object[requiredParams.Length];

            // Convert string input into correct parameter types
            for (int i = 0; i < requiredParams.Length; i++)
            {
                parsedParams[i] = Convert.ChangeType(cmdArgs[i], requiredParams[i].ParameterType);
            }

            methodForExecution.Invoke(this, parsedParams);
        }

        // ================= COMMAND METHODS =================

        // Creates a job and attaches event handler
        private void JobCommand(string jobName, int requiredHoursOfWork, string employeeName)
        {
            var employee = this.employees.FirstOrDefault(e => e.Name == employeeName);

            if (employee == null)
            {
                throw new ArgumentException(
                    string.Format(MissingEmployeeExceptionMessage, employeeName));
            }

            var job = new Job(jobName, requiredHoursOfWork, employee);

            // Subscribe to job completion event
            job.JobDone += this.OnJobDone;

            this.jobs.Add(job);
        }

        // Event handler when job is completed
        private void OnJobDone(object sender, JobEventArgs args)
        {
            this.writer.WriteLine($"Job {args.Job.Name} done!");
        }

        private void StandartEmployeeCommand(string name)
            => this.employees.Add(new StandartEmployee(name));

        private void PartTimeEmployeeCommand(string name)
            => this.employees.Add(new PartTimeEmployee(name));

        private void StatusCommand()
            => this.writer.WriteLine(string.Join(Environment.NewLine, this.jobs.Select(j => j.ToString())));

        // Advances time (updates all jobs)
        private void PassCommand()
        {
            foreach (var job in this.jobs)
            {
                job.Update();
            }
        }
    }
}