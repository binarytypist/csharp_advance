using CSharpFundamentals.EventImplementation.Interfaces;

namespace CSharpFundamentals.EventImplementation.Models
{
    // Handler class is an event subscriber (listener)
    // It reacts when the Dispatcher raises the NameChange event

    public class Handler
    {
        // IWriter is used so we don't depend directly on Console
        // This allows flexibility (ConsoleWriter, FileWriter, etc.)
        private IWriter writer;

        // Dependency Injection: writer is passed from outside
        public Handler(IWriter writer)
        {
            this.writer = writer;
        }

        // This method is an EVENT HANDLER
        // It matches the delegate signature:
        // (object sender, NameChangeEventArgs args)
        //
        // It is executed automatically when Dispatcher.NameChange is triggered
        public void OnDispatcherNameChange(object sender, NameChangeEventArgs args)
        {
            // Writes a message when the event occurs
            this.writer.WriteLine($"Dispatcher's name changed to {args.Name}.");
        }
    }
}