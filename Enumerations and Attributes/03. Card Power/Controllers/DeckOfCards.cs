using System;
using System.Linq;
using CardPowerExplorer.Enums;

namespace CardPowerExplorer.Controllers
{
    // Import basic system functionality (Console, Enum, etc.)
    // This class prints a full deck of cards grouped by suit
    public class DeckOfCards
    {
        // Entry method for this controller
        public void Run()
        {
            // Reads input but does NOT use it (often just part of the exercise format)
            Console.ReadLine();

            // Get all names of the Rank enum as strings
            // Example: ["Ace", "Two", "Three", ..., "King"]
            var ranks = Enum.GetNames(typeof(Rank));

            // Print all cards for each suit
            this.PrintCardsBySuit(ranks, Suit.Clubs);
            this.PrintCardsBySuit(ranks, Suit.Hearts);
            this.PrintCardsBySuit(ranks, Suit.Diamonds);
            this.PrintCardsBySuit(ranks, Suit.Spades);
        }

        // Prints all cards for a specific suit
        private void PrintCardsBySuit(string[] ranks, Suit suit)
        {
            // Prints the first card (Ace of suit) separately
            Console.WriteLine($"{Rank.Ace} of {suit}");

            // Prints the rest of the cards for that suit
            Console.WriteLine(
                string.Join(
                    Environment.NewLine,

                    // Skip the last rank (King) due to Take(ranks.Length - 1)
                    ranks
                        .Take(ranks.Length - 1)

                        // Convert each rank into "Rank of Suit"
                        .Select(r => $"{r} of {suit}")
                )
            );
        }
    }
}