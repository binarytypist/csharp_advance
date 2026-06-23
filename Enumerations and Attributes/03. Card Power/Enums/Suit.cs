using CardPowerExplorer.Attributes;

namespace CardPowerExplorer.Enums
{
    // Custom attribute attached to this enum
    // It provides metadata about what this enum represents
    //
    // Type        = "Enumeration"
    // Category    = "Suit"
    // Description = explanation used for reflection
    [Type("Enumeration", "Suit", "Provides suit constants for a Card class.")]

    // Enum representing the 4 suits in a standard deck of cards
    public enum Suit
    {
        // Clubs starts at 0 (base suit)
        Clubs = 0,

        // Diamonds starts at 13 (offset by 13 cards)
        Diamonds = 13,

        // Hearts starts at 26 (two full suits offset)
        Hearts = 26,

        // Spades starts at 39 (three full suits offset)
        Spades = 39
    }
}