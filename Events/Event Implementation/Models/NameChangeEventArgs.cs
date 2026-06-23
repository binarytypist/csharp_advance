using System;

namespace CSharpFundamentals.EventImplementation.Models
{
 
    // NameChangeEventArgs is a custom event data class.
    // It inherits from EventArgs (base class for all event data in C#).

    // Why do we need this?
    // - Events often need to pass extra information.
    // - In this case, we want to send the NEW name when it changes.
    // - This class carries that data to event subscribers.

    public class NameChangeEventArgs : EventArgs
    {
        // Constructor sets the new name value when event is created
        public NameChangeEventArgs(string name)
        {
            this.Name = name;
        }

        // Read-only property:
        // Once set in constructor, it cannot be changed from outside
        public string Name { get; private set; }
    }
}