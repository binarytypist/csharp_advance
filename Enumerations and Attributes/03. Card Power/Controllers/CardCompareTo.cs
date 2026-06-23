using System;

namespace CardPowerExplorer.Controllers
{
    // Class responsible for comparing two cards
    // and printing the stronger one.
    public class CardCompareTo
    {
        // Main method of this class.
        public void Run()
        {
            // Read the first card from the console.
            // Example:
            // Ace
            // Spades
            var firstCard = CardPower.GetCardFromConsole();

            // Read the second card from the console.
            // Example:
            // King
            // Hearts
            var secondCard = CardPower.GetCardFromConsole();

            // Compare the two cards.
            //
            // CompareTo() returns:
            // > 0  => firstCard is stronger
            // < 0  => secondCard is stronger
            // = 0  => cards are equal
            //
            // The ternary operator (? :) chooses which card to print.
            Console.WriteLine(
                (firstCard.CompareTo(secondCard) > 0)
                    ? firstCard     // Print first card if stronger
                    : secondCard);  // Otherwise print second card
        }
    }
}