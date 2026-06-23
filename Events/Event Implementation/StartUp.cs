
using CSharpFundamentals.EventImplementation.Models;
using System;

namespace CSharpFundamentals.EventImplementation
{
    // This project shows how changing a value triggers an event that automatically notifies other classes

    public class StartUp
    {
        public static void Main()
        {
            // Create the event publisher (Dispatcher)
            // This object will raise an event when its Name changes
            var dispatcher = new Dispatcher();

            // Create the event subscriber (Handler)
            // ConsoleWriter is injected so Handler can output messages
            var handler = new Handler(new ConsoleWriter());

            // Subscribe to the event:
            // When dispatcher.NameChange is triggered,
            // handler.OnDispatcherNameChange will be executed automatically
            dispatcher.NameChange += handler.OnDispatcherNameChange;

            // Read initial input from the user
            var dispatcherName = Console.ReadLine();

            // Loop until user types "End"
            while (dispatcherName != "End")
            {
                // When we assign a new value to Name:
                // → Dispatcher raises the NameChange event
                // → Handler reacts automatically
                dispatcher.Name = dispatcherName;

                // Read next input
                dispatcherName = Console.ReadLine();
            }
        }
    }
}


//                ┌──────────────────────────────┐
//                │          StartUp             │
//                │  (Application Entry Point)  │
//                └──────────────┬──────────────┘
//                               │
//                               │ creates objects
//                               ▼
//        ┌────────────────────────────────────────┐
//        │              Dispatcher                │
//        │--------------------------------------│
//        │ + Name : string                      │
//        │ + event NameChange                   │
//        │--------------------------------------│
//        │ + OnNameChange()                     │
//        └──────────────┬────────────────────────┘
//                       │
//                       │ RAISES EVENT
//                       ▼
//        ┌────────────────────────────────────────┐
//        │        NameChangeEventArgs             │
//        │--------------------------------------│
//        │ + Name : string (event data)         │
//        └──────────────┬────────────────────────┘
//                       │
//                       │ passed through event
//                       ▼
//        ┌────────────────────────────────────────┐
//        │              Handler                  │
//        │--------------------------------------│
//        │ + OnDispatcherNameChange()           │
//        │--------------------------------------│
//        │ uses IWriter                         │
//        └──────────────┬────────────────────────┘
//                       │
//                       │ dependency injection
//                       ▼
//        ┌──────────────────────────────┐
//        │        IWriter              │
//        │   (interface / contract)    │
//        └──────────────┬──────────────┘
//                       │
//        ┌──────────────┴──────────────┐
//        ▼                             ▼
//┌──────────────────┐        ┌──────────────────┐
//│  ConsoleWriter   │        │ (future: File/DB)│
//│ writes to Console│        │ other outputs    │
//└──────────────────┘        └──────────────────┘

//  1.Publisher–Subscriber Pattern
//  Dispatcher = Publisher
//  Handler = Subscriber

//  2. Event-driven programming

//  3. Loose coupling
//  Dispatcher does NOT know Handler
//  Handler does NOT know Dispatcher

// They only communicate through: EVENT

// 4. Dependency Injection
// Handler depends on IWriter
// Not on Console directly