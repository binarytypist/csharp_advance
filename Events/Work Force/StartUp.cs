
using WorkForce.JobManagementSystem.Controllers;
using WorkForce.JobManagementSystem.IO;

namespace WorkForce.JobManagementSystem
{

    // WorkForce is an event-driven system where Jobs are assigned to Employees, updated over time, and notify the Engine through events when completed.

    // WorkForce is a task management system where:
    // Employees do jobs
    // Jobs decrease over time
    // When a job finishes → it triggers an event
    // Engine reacts automatically
    //  Key pattern: Observer Pattern(Events & Delegates)

    public class StartUp
    {
        public static void Main()
        {
            // Console input/output abstraction (Dependency Injection)
            var reader = new ConsoleReader();
            var writer = new ConsoleWriter();

            // Engine runs the entire command system

            // StandartEmployee John
            // PartTimeEmployee Peter
            // Job Task1 10 John
            // Job Task2 5 Peter
            // Status
            // Pass
            
            new Engine(reader, writer).Run();
        }
    }
}



//┌──────────────────────────────┐
//│          StartUp             │
//│------------------------------│
//│ - Creates Engine             │
//│ - Injects ConsoleReader      │
//│ - Injects ConsoleWriter      │
//│ - Starts Run()               │
//└──────────────┬───────────────┘
//               │
//               ▼
//┌──────────────────────────────┐
//│           Engine             │
//│------------------------------│
//│ - Reads commands             │
//│ - Creates Employees          │
//│ - Creates Jobs               │
//│ - Controls system flow       │
//└──────────────┬───────────────┘
//               │
//     ┌─────────┼─────────┐
//     │         │         │
//     ▼         ▼         ▼

//┌──────────────┐   ┌──────────────┐   ┌──────────────────┐
//│  IReader     │   │   IWriter    │   │ Reflection/Logic │
//│ ConsoleRead  │   │ ConsoleWrite │   │ Command handler  │
//└──────────────┘   └──────────────┘   └──────────────────┘

// 