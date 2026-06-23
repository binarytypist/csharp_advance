
using System;
using KingsGambit.EventDrivenSimulation.Interfaces;

namespace KingsGambit.EventDrivenSimulation.Models
{

    // Central event publisher
    // The King is the main character in the simulation, and he triggers events when attacked.
    // "public" means this class can be accessed from anywhere in the program
    // "class" means we are defining a new type (King) that can have properties and methods
    
    // The King class implements the IPerson interface, which means it must have a Name property.
    
    public class King : IPerson
    {
        // Event triggered when king is attacked
        // "public" means this event can be subscribed to from anywhere in the program

        // "event" keyword indicates that this is an event, which is a special type of delegate that
        // can only be invoked from within the class that declares it (in this case, the King class).
        // "EventHandler" is a predefined delegate type in .NET that represents a method that will handle an event.
        // The signature of the EventHandler delegate is: void Handler(object sender, EventArgs e)
        // This means that any method that matches this signature can subscribe to the UnderAttack event and will be called when the event is raised.
        // The UnderAttack event will be raised by the King class when the OnUnderAttack method is called, which simulates the king being attacked.
        // Soldiers (subscribers) will subscribe their KingUnderAttack methods to this event, so when the event is raised, all subscribed soldiers will react accordingly.
        // The event system allows for loose coupling between the King and his soldiers, as the King does not need to know about the soldiers or how they react to being attacked.
        // He simply raises the event, and any subscribed soldiers will handle it in their own way.
        public event EventHandler UnderAttack;

        private IWroiter writer;

        //  Constructor for King, using Dependency Injection to receive the writer from outside
        // This allows for greater flexibility and testability, as we can easily swap out different implementations of IWroiter
        // (e.g., ConsoleWriter, FileWriter) without changing the King's code.
        // The constructor initializes the Name property and the writer field, which will be used to output messages when the king is attacked.
        public King(string name, IWroiter writer)
        {

            // Initialize the Name property with the provided name parameter
            // Initialize the writer field with the provided writer parameter
            // The Name property is read-only (private set), so it can only be set in the constructor and not modified afterwards.
            this.Name = name;
            this.writer = writer;
        }

        // Read-only property for the king's name, as required by the IPerson interface
        // The Name property is read-only (private set), so it can only be set in the constructor and not modified afterwards.
        // This ensures that the king's name remains constant throughout the simulation, as it should not change once the king is created.
        public string Name { get; private set; }

        // Called by Engine when attack command happens
        // This method simulates the king being attacked and raises the UnderAttack event to notify all subscribed soldiers.
        // When this method is called, it first writes a message indicating that the king is under attack, and then it raises the UnderAttack event.
        // The UnderAttack event will trigger all subscribed soldiers to react according to their own implementation of the KingUnderAttack method.
        //  The event system allows for loose coupling between the King and his soldiers, as the King does not need to know about the soldiers or how they react to being attacked.
        public void OnUnderAttack()
        {
            //  Output message indicating that the king is under attack
            // This message is written using the injected IWroiter, which allows for flexibility in how the output is handled (e.g., console, file).
            // The message includes the king's name to provide context for the attack.
            // This message is important for the simulation, as it indicates the event that triggers the soldiers' reactions.
            this.writer.WriteLine($"King {this.Name} is under attack!");

            // Notify all subscribed soldiers
            // This line raises the UnderAttack event, which will call all methods that are subscribed to this event (i.e., the KingUnderAttack methods of the soldiers).
            // The event is raised with "this" as the sender (the King object) and "new EventArgs()" as the event data (which is empty in this case, but could be extended
            // to include more information about the attack if needed).
            this.UnderAttack?.Invoke(this, new EventArgs());
        }
    }
}