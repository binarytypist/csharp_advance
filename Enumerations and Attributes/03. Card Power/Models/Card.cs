using System;
using CardPowerExplorer.Enums;


namespace CardPowerExplorer.Models
{
    // Card class represents a single playing card (Rank + Suit)
    // Implements IComparable so cards can be compared by power
    public class Card : IComparable<Card>
    {
        // Private field storing the card's rank (Ace, King, etc.)
        private Rank rank;

        // Private field storing the card's suit (Clubs, Hearts, etc.)
        private Suit suit;

        // Stores calculated power of the card
        private int power;

        // Constructor: creates a Card object
        public Card(Rank rank, Suit suit)
        {
            // Assign rank to field
            this.rank = rank;

            // Assign suit to field
            this.suit = suit;

            // Calculate total power of the card
            // Power = rank value + suit offset
            //
            // Example:
            // Ace of Clubs = 14 + 0 = 14
            // Ace of Diamonds = 14 + 13 = 27
            this.power = (int)this.rank + (int)this.suit;
        }

        // Public getter for rank (read-only outside class)
        public Rank Rank => this.rank;

        // Public getter for suit (read-only outside class)
        public Suit Suit => this.suit;

        // Compare this card with another card
        // Used for sorting and determining stronger card
        public int CompareTo(Card other)
        {
            // Return difference of power values
            //
            // > 0  → this card is stronger
            // < 0  → other card is stronger
            // = 0  → both cards are equal
            return this.power - other.power;
        }

        // String representation of the Card object
        public override string ToString()
        {
            // Example output:
            // Card name: Ace of Spades; Card power: 53
            return $"Card name: {this.rank} of {this.suit}; Card power: {this.power}";
        }
    }
}