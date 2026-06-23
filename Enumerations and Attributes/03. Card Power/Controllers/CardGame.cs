using System;
using System.Collections.Generic;
using System.Linq;
using CardPowerExplorer.Enums;
using CardPowerExplorer.Models;

namespace CardPowerExplorer.Controllers
{
    // This class simulates a simple card game between two players
    public class CardGame
    {
        // Stores the name of the current winning player
        private string winner;

        // Stores the strongest card found so far
        private Card winningCard;

        // Stores all cards already used by both players
        private HashSet<Card> cardsInPlayers;

        // Constructor initializes the HashSet
        public CardGame()
        {
            // Ensures no duplicate cards are used in the game
            this.cardsInPlayers = new HashSet<Card>();
        }

        // Main method that runs the game
        public void Run()
        {
            // Read first player's name
            var firstPlayer = Console.ReadLine();

            // Read second player's name
            var secondPlayer = Console.ReadLine();

            // Read 5 cards for first player
            this.GetCards(firstPlayer);

            // Read 5 cards for second player
            this.GetCards(secondPlayer);

            // Print winner and strongest card
            Console.WriteLine($"{this.winner} wins with {this.winningCard.Rank} of {this.winningCard.Suit}.");
        }

        // Reads 5 cards for a given player
        private void GetCards(string player)
        {
            // Each player must enter exactly 5 cards
            for (int i = 0; i < 5; i++)
            {
                // Read card input line
                // Example: "Ace of Spades"
                var cardDetails = Console.ReadLine().Split();

                // First word is rank (Ace, King, etc.)
                var rankName = cardDetails[0];

                // Third word is suit (Spades, Hearts, etc.)
                var suitName = cardDetails[2];

                // Try converting string to Rank enum
                Rank rank;
                var isRankValid = Enum.TryParse(rankName, out rank);

                // Try converting string to Suit enum
                Suit suit;
                var isSuitkValid = Enum.TryParse(suitName, out suit);

                // If either rank or suit is invalid
                if (!isRankValid || !isSuitkValid)
                {
                    Console.WriteLine("No such card exists.");

                    // repeat this iteration again (do not count invalid input)
                    i--;
                    continue;
                }

                // Create card object
                var card = new Card(rank, suit);

                // Check if card already used by either player
                if (this.cardsInPlayers.Any(c => c.CompareTo(card) == 0))
                {
                    Console.WriteLine("Card is not in the deck.");

                    // repeat this iteration again
                    i--;
                    continue;
                }

                // Add card to used cards list
                this.cardsInPlayers.Add(card);

                // Check if this is the strongest card so far
                this.MaxCardChecker(card, player);
            }
        }

        // Compares current card with best card so far
        private void MaxCardChecker(Card card, string player)
        {
            // If no winning card exists yet, set it
            if (this.winningCard == null)
            {
                this.winningCard = card;
                this.winner = player;
                return;
            }

            // If current card is stronger than the stored winning card
            if (card.CompareTo(this.winningCard) > 0)
            {
                this.winningCard = card;
                this.winner = player;
            }
        }
    }
}