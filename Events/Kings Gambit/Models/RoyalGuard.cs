namespace KingsGambit.EventDrivenSimulation.Models
{
    using System;
    using KingsGambit.EventDrivenSimulation.Interfaces;

    // Strong soldier type
    public class RoyalGuard : Soldier
    {
       // Constructor for RoyalGuard, calling the base constructor to initialize name and writer 
        public RoyalGuard(string name, IWroiter writer)
            : base(name, writer)
        {
            // No additional properties needed for RoyalGuard, so we just call the base constructor
        }

        // Reaction when king is attacked
        // RoyalGuard defends the king when attacked
        // This method is called by the King event system when the King is attacked
        // override" means we are providing a specific implementation for the abstract method defined in Soldier
        // Each soldier type reacts differently to the same event (polymorphism)
        // RoyalGuard is a specific type of Soldier with its own behavior when the King is attacked
        public override void KingUnderAttack(object sender, EventArgs e)
        {
            // RoyalGuard defends the king when attacked
            // This method is called by the King event system when the King is attacked
            this.Writer.WriteLine($"Royal Guard {this.Name} is defending!");
        }
    }
}