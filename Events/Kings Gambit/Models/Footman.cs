
using KingsGambit.EventDrivenSimulation.Interfaces;
using System;

namespace KingsGambit.EventDrivenSimulation.Models
{

    // Weak soldier type
    // Footman panics instead of defending when the King is attacked
    // Inherits from Soldier, so it must implement the KingUnderAttack method
    // "public" means this class can be accessed from anywhere in the program
    // class" means we are defining a new type (Footman) that can have properties and methods
    // "Footman : Soldier" means Footman is a subclass of Soldier, inheriting its properties and methods
    // Footman is a specific type of Soldier with its own behavior when the King is attacked
    public class Footman : Soldier
    {
        public Footman(string name, IWroiter writer)
            : base(name, writer)
        {
            // Footman constructor
            // No additional properties needed for Footman, so we just
            // call the base constructor to initialize name and writer
        }

        // Reaction when king is attacked
        // Footman panics instead of defending
        // This method is called by the King event system when the King is attacked
        // override" means we are providing a specific implementation for the abstract method defined in Soldier
        // Each soldier type reacts differently to the same event (polymorphism)
        public override void KingUnderAttack(object sender, EventArgs e)
        {
            this.Writer.WriteLine($"Footman {this.Name} is panicking!");
        }
    }
}