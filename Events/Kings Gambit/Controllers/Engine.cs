using KingsGambit.EventDrivenSimulation.Interfaces;
using KingsGambit.EventDrivenSimulation.Models;
using System.Collections.Generic;
using System.Linq;

namespace KingsGambit.EventDrivenSimulation.Controllers
{

    // Engine controls the game logic (simulation loop)
    // It builds the initial kingdom setup and processes commands until "End"
    // It also manages the event system by subscribing/unsubscribing soldiers to the king's UnderAttack event
    // "public" means this class can be accessed from anywhere in the program
    // "class" means we are defining a new type (Engine) that can have properties and methods
    // The Engine is the central controller of the simulation, orchestrating the interactions between the King and his soldiers based on user input commands.
    public class Engine
    {
        // Fields to hold the main objects of the simulation
        // "private" means these variables can only be accessed within this class

        // "King" is the central object that triggers events when attacked
        private King king; 
  
        // "List<Soldier>" holds all soldiers in the kingdom, allowing us to manage their subscriptions to the king's events

        private List<Soldier> soldiers; // all soldiers in the kingdom

        // "IReader" and "IWroiter" are abstractions for input and output, allowing us to easily switch between different input/output mechanisms
        // (e.g., console, file) without changing the core logic of the Engine
        private IReader reader;
        // "writer" is used to output messages from the King and soldiers when events are triggered
        // It is injected into the King and Soldier objects so they can output their reactions to events
        // This allows for loose coupling between the Engine and the output mechanism, adhering to the Dependency Inversion Principle
        // The Engine does not need to know how the output is done, it just provides the writer to the objects that need it
        // This design allows for greater flexibility and testability of the code, as we can easily mock the IReader and IWroiter interfaces in unit tests.
        private IWroiter writer;

        // Constructor for Engine, using Dependency Injection to receive the reader and writer from outside
       public Engine(IReader reader, IWroiter writer)
        {
            // This allows for greater flexibility and testability, as we can easily swap out different implementations of IReader
            // and IWroiter (e.g., ConsoleReader, FileReader, ConsoleWriter, FileWriter) without changing the Engine's code.
            this.reader = reader;
            this.writer = writer;
            // Initialize the soldiers list to manage all soldiers in the kingdom
            // This list will be used to keep track of all soldiers and manage their subscriptions to the king's events.
            this.soldiers = new List<Soldier>();
        }
        // Main method to run the simulation
        // It first builds the initial kingdom setup (creating the king and soldiers) and then processes commands until "End" is received.
        public void Run()
        {
            // Build the initial kingdom setup (king and soldiers) based on user input
            // This method reads the king's name, the names of the royal guards, and the names of the footmen from the input,
            // creates the corresponding objects, and subscribes the soldiers to the king's UnderAttack event.
            this.BuildKingdom();
            // Process commands until "End" is received
            // This method reads commands from the input, such as "Attack" and "Kill", and executes the corresponding actions.
            // When "Attack" is received, it triggers the king's UnderAttack event, causing all subscribed soldiers to react.
            this.ExecuteCommands();   
        }

        // Handles input commands (Attack / Kill / End)
        private void ExecuteCommands()
        {
            var command = this.reader.ReadLine().Split();

            while (command[0] != "End")
            {
                switch (command[0])
                {
                    case "Attack":
                        // King is attacked → triggers event
                        this.king.OnUnderAttack();
                        break;

                    case "Kill":
                        // Remove a soldier from event system
                        this.RemoveDeadSoldier(command[1]);
                        break;
                }

                command = this.reader.ReadLine().Split();
            }
        }

        // Removes soldier from event subscription
        private void RemoveDeadSoldier(string soldierName)
        {
            var soldier = this.soldiers.FirstOrDefault(s => s.Name == soldierName);

            // unsubscribe soldier from king event
            king.UnderAttack -= soldier.KingUnderAttack;

            this.soldiers.Remove(soldier);
        }

        // Builds initial kingdom setup
        private void BuildKingdom()
        {
            var kingName = this.reader.ReadLine();
            this.king = new King(kingName, this.writer);

            // Create Royal Guards and subscribe them to king event
            var royalGuardNames = this.reader.ReadLine().Split();
            foreach (var name in royalGuardNames)
            {
                var royalGuard = new RoyalGuard(name, this.writer);
                this.soldiers.Add(royalGuard);
                this.king.UnderAttack += royalGuard.KingUnderAttack;
            }

            // Create Footmen and subscribe them to king event
            var footmanNames = this.reader.ReadLine().Split();
            foreach (var name in footmanNames)
            {
                var footman = new Footman(name, this.writer);
                this.soldiers.Add(footman);
                this.king.UnderAttack += footman.KingUnderAttack;
            }
        }
    }
}