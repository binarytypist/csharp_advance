using CardPowerExplorer.Controllers;
using CardPowerExplorer.Models;
using System;
using System.Reflection;


// This project is a console-based card game system designed to demonstrate advanced C# concepts such as OOP principles, SOLID architecture,
// enums, attributes, and reflection. The system simulates a deck of cards and provides multiple functionalities like card comparison, deck generation,
// custom attribute inspection, and a simple card game between two players.

// High - Level Architecture
// The application is structured using a layered and modular design:
// Controllers => Handle business actions and user interaction
// Models => Represent core domain objects like Card
// Enums => Define fixed sets of values like Rank and Suit
// Attributes => Provide metadata using custom attributes
// StartUp => Entry point that orchestrates all modules

//Each module is independent and communicates through well-defined boundarie

// This project strongly applies core OOP principles:
// Encapsulation
// The Card class encapsulates internal state:
// Rank
// Suit
// Power calculation
// The internal logic for computing card power is hidden from external classes.

// Abstraction
// Interfaces and system boundaries abstract complexity:
// Controllers hide internal logic
// Engine methods hide parsing and processing details

// Inheritance
// Custom attributes inherit from the base Attribute class:
// public class TypeAttribute : Attribute
// This allows us to extend metadata capabilities in C#.

// Polymorphism is used in multiple places:
// IComparable<Card> allows card comparison behavior
// ToString() is overridden to provide custom output formatting
// Reflection processes attributes without knowing their concrete type

// SOLID Principles: 
// Each class has exactly one responsibility:
// Card → represents data + comparison logic
// CardPower → creates and prints a card
// CardGame → handles game logic
// DeckOfCards → prints full deck
// CustomEnumAttribute → handles reflection logic


// O — Open/Closed Principle (OCP)
// The system is open for extension but closed for modification:

// New card types or logic can be added without changing existing classes
// New attributes can be introduced without modifying existing reflection logic
// Example: 
// [Type(...)]

// We can extend metadata without changing how attributes are read.

// L — Liskov Substitution Principle (LSP)
// Derived types can replace base types:
// TypeAttribute replaces Attribute safely
// Card can be used wherever IComparable<Card> is expected

// I — Interface Segregation Principle (ISP)
//We use small focused interfaces:
//IComparable<Card> only defines comparison behavior
//No class is forced to implement unnecessary methods

// D — Dependency Inversion Principle (DIP)
// High-level modules depend on abstractions:
// CardGame depends on Card, not concrete logic inside comparison
// Reflection logic depends on Attribute, not concrete TypeAttribute


// Enums
// Used to represent fixed values:
// Rank(2 → Ace)
// Suit(Clubs → Spades)
// They improve type safety and remove magic numbers.


// Attributes
// Custom metadata is attached to enums:
// [Type("Enumeration", "Rank", "...")]
// This allows runtime information inspection.

// Reflection
// Used in CustomEnumAttribute:
// Reads metadata at runtime
// Displays attribute information dynamically

// IComparable
// Used in Card class:
// Enables comparison between cards
// Used in sorting and game logic

// Business Logic Flow
// User inputs card data
// Enums convert strings into structured values
// Card object calculates power
// Game logic compares cards
// Reflection reads metadata from enums
// Output is printed dynamically

// It simulates a mini domain-driven system for a card game engine, designed with maintainability, extensibility, and separation of concerns in mind.
namespace CardPowerExplorer
{


    // Entry point of the application
    // The StartUp class orchestrates the execution of all functionalities in the system.
    public class StartUp
    {
        // Program starts here
        public static void Main()
        {
            // ======================================================
            // 1. CARD POWER (Problem 3 + 4)
            // ======================================================
            // INPUT:
            // Ace
            // Spades
            //
            // OUTPUT:
            // Card name: Ace of Spades; Card power: 53
            new CardPower().Run();

            // ======================================================
            // 2. CARD COMPARE (Problem 5)
            // ======================================================
            // INPUT:
            // Ace
            // Spades
            // King
            // Hearts
            //
            // OUTPUT:
            // Card name: Ace of Spades; Card power: 53
            // (or King of Hearts depending on comparison)
            new CardCompareTo().Run();

            // ======================================================
            // 3. CUSTOM ENUM ATTRIBUTE (Problem 6)
            // ======================================================
            // INPUT:
            // Rank
            //
            // OUTPUT:
            // Type = Enumeration, Description = Provides rank constants for a Card class.
            new CustomEnumAttribute().Run();

            // ======================================================
            // 4. DECK OF CARDS (Problem 7)
            // ======================================================
            // INPUT:
            // (any text, not used)
            //
            // OUTPUT:
            // Ace of Clubs
            // Two of Clubs
            // ...
            // King of Spades
            new DeckOfCards().Run();

            // ======================================================
            // 5. CARD GAME (Problem 8)
            // ======================================================
            // INPUT:
            // Peter
            // John
            //
            // Ace of Spades
            // King of Hearts
            // Ten of Clubs
            // Two of Diamonds
            // Three of Spades
            //
            // Queen of Hearts
            // Jack of Spades
            // Nine of Clubs
            // Eight of Diamonds
            // Seven of Hearts
            //
            // OUTPUT:
            // Peter wins with Ace of Spades.
            new CardGame().Run();
        }
    }
}