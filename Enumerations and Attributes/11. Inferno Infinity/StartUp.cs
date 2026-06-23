using InfernoInfinity.Controllers;

// This project, Inferno Infinity, is a console-based system that simulates an RPG-style weapon and gem management engine. The main idea is that users
// an create weapons, add or remove gems from weapon sockets, and then calculate the final weapon stats based on rarity and gem bonuses.

// From an architectural point of view, I designed it using a layered, command-driven structure.At the top, there is an Engine class, which is responsible only
// for reading input commands and routing them.It does not contain any business logic.

// The core logic is handled by a WeaponManager, which stores all weapons and applies operations like creating weapons, adding gems, and removing gems.
// This ensures that all business rules are centralized in one place.

// For object creation, I used the Factory Pattern with a WeaponFactory and GemFactory.This allows me to encapsulate the creation logic and makes the system
// easily extensible if new weapon or gem types are added in the future.

// Used interfaces like IWeapon and IGem to define contracts for the domain models. This ensures loose coupling and makes the system flexible and maintainable.

// Enums such as WeaponRarity and GemClarity are used as controlled value sets that act as multipliers for calculating power, instead of using magic numbers.

// The system is driven by commands like Create, Add, Remove, and Print. These are parsed in the Engine and delegated to the manager layer.

// Overall, this project demonstrates key object-oriented principles like encapsulation, abstraction, separation of concerns,
// and extensibility, along with design patterns like Factory and a clean layered architecture approach.

// The system is structured into distinct layers:

// Presentation Layer
// Engine
// Handles input parsing and command routing
// Application Layer
// WeaponManager
// Contains core business logic and state management
// Domain Layer
// IWeapon, IGem
// Weapon, Gem implementations
// Enums (WeaponRarity, GemClarity)
// Factory Layer
// WeaponFactory
// GemFactory
// Responsible for controlled object instantiation
// IO Layer
// InputReader
// OutputWriter
// Abstracts console dependency

// Execution Flow
// The runtime flow follows a command-driven pipeline:
// Input → Engine → Command Parser → Manager → Factory → Domain Model → Output

// Each command is interpreted as: Action; Target; Parameters


// Domain Modeling Strategy
// Weapons
// Contain base damage values
// Scale using WeaponRarity multiplier
// Hold collection of gem sockets
// Gems
// Provide stat bonuses (Strength, Agility, Vitality)
// Are scaled using GemClarity multiplier

// Enums as Controlled Multipliers
// Enums are not simple labels; they represent business multipliers:

// WeaponRarity → amplifies base weapon stats
// GemClarity → amplifies gem bonuses

// Factories are used to:

// Encapsulate object creation logic
// Avoid direct instantiation in business layer
// Support future extensibility (new weapon/ gem types)


// Command Processing Strategy
// The system uses a string-based command interpreter:
// Supported commands:
// Create
// Add
// Remove
// Print
// END
// Each command is parsed and delegated to the appropriate service.

// Design Constraints
// No direct object creation outside factories
// No business logic inside Engine
// No console dependency inside domain layer
// All interactions must pass through Manager

namespace InfernoInfinity
{
    // Single Responsibility Principle
    // Each class must have one responsibility:
    // Engine → command processing
    // Manager → business logic
    // Factory → object creation
    // Model → data + behavior
    // IO → input/output abstraction

    // Entry point of the application

    // New weapon types or gem types should be added without modifying existing logic, only extending factories.
    // The Engine class will read commands from the console, process them, and delegate to the Manager for business logic.

    // Open/Closed Principle
    // New weapon types or gem types should be added without modifying existing logic, only extending factories.

    // Dependency Inversion
    // High - level modules(Engine) must depend on abstractions(interfaces), not concrete implementations.


    // Example of input commands:
    // Create; Epic Sword; Excalibur
    // Add; Excalibur; 0; Ruby Flawless
    // Add; Excalibur; 1; Emerald Perfect
    // Add; Excalibur; 2; Amethyst Regular
    // Remove; Excalibur; 1 
    // Print
    public class StartUp
    {
        public static void Main()
        {
        // input:
           // Create; Epic Sword; Excalibur
           // Add; Excalibur; 0; Ruby Flawless
           // Add; Excalibur; 1; Emerald Perfect
           // Add; Excalibur; 2; Amethyst Regular
           // Remove; Excalibur; 1
           // Print
           // END
           // output
            // Excalibur: 20 - 30 Damage, +0 Strength, +0 Agility, +0 Vitality


            // Start the game engine
            new Engine().Run();
        }
    }
}


