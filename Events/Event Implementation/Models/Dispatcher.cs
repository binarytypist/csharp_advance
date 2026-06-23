

namespace CSharpFundamentals.EventImplementation.Models
{
    // A delegate defines the "shape" of the event handler method.
    // Any method that matches this signature can handle the event.
    // (object sender, NameChangeEventArgs args)
    public delegate void NameChangeEventHandler(object sender, NameChangeEventArgs args);

    // Dispatcher class is responsible for holding a name and notifying others when it changes.
    // This is the "publisher" in event-driven programming.
    public class Dispatcher
    {
        // Event based on the delegate.
        // Other classes can subscribe to this event.
        public event NameChangeEventHandler NameChange;

        // Backing field for the Name property
        private string name;

        // Property that triggers the event when the value changes
        public string Name
        {
            get
            {
                return this.name; // return current stored name
            }

            set
            {
                this.name = value; // update internal value

                // Raise the event whenever Name is changed
                this.OnNameChange(new NameChangeEventArgs(value));
            }
        }

        // Method responsible for raising (firing) the event
        public void OnNameChange(NameChangeEventArgs args)
        {
            // Check if there are any subscribers before raising the event
            if (args != null)
            {
                // Invoke all methods subscribed to NameChange event
                this.NameChange(this, args);
            }
        }
    }
}