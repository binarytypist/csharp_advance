namespace KingsGambit.EventDrivenSimulation.Models
{
    using System;
    using KingsGambit.EventDrivenSimulation.Interfaces;

    // Abstract base class for all soldiers in the system
    // "Abstract" means you CANNOT create Soldier directly
    // It is only used as a blueprint for specific soldier types (RoyalGuard, Footman)

    public abstract class Soldier : IPerson
    {
        // Constructor is used to initialize shared properties for all soldiers
        public Soldier(string name, IWroiter writer)
        {
            this.Name = name;       // each soldier has a name
            this.Writer = writer;   // shared output mechanism (Console/File abstraction)
        }

        // Read-only property for soldier name
        public string Name { get; private set; }

        // Protected means:
        // - accessible inside this class
        // - accessible in derived classes (RoyalGuard, Footman)
        protected IWroiter Writer { get; private set; }

        // Abstract method = MUST be implemented by all derived classes
        // This method is called when the King is under attack
        // Each soldier reacts differently (polymorphism)
        public abstract void KingUnderAttack(object sender, EventArgs e);
    }
}