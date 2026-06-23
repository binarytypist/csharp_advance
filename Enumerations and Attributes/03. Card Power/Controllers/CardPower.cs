
using System;
using CardPowerExplorer.Enums;
using CardPowerExplorer.Models;

namespace CardPowerExplorer.Controllers
{
     // This class is responsible for creating a card and printing its power
    public class CardPower
    {
        // Entry method for this controller
        public void Run()
        {
            // Create a Card object from console input
            var card = GetCardFromConsole();

            // Print the card (Card.ToString() is used internally)
            Console.WriteLine(card);
        }

        // Static method that reads input and creates a Card object
        public static Card GetCardFromConsole()
        {
            // Read the first line: Rank (e.g. "Ace", "King")
            var cardPower = Console.ReadLine();

            // Read the second line: Suit (e.g. "Spades", "Hearts")
            var cardSuit = Console.ReadLine();

            // Convert string input into Rank enum
            // Example: "Ace" -> Rank.Ace
            var power = (Rank)Enum.Parse(typeof(Rank), cardPower);

            // Convert string input into Suit enum
            // Example: "Spades" -> Suit.Spades
            var suit = (Suit)Enum.Parse(typeof(Suit), cardSuit);

            // Create and return a new Card object using parsed values
            return new Card(power, suit);
        }
    }
}