using CardPowerExplorer.Attributes;

namespace CardPowerExplorer.Enums
{ 

    // Custom attribute applied to this enum
    // It stores metadata about the enum (not used in game logic directly)
    //
    // Type      = "Enumeration"
    // Category  = "Rank"
    // Description = explanation of what this enum represents
    [Type("Enumeration", "Rank", "Provides rank constants for a Card class.")]

    // Enum representing card ranks in a deck of playing cards
    // Each rank is assigned an explicit numeric value (card strength)
    public enum Rank
    {
        // Numeric values define power of each card
        // Higher value = stronger card in comparisons

        Two = 2,        // weakest rank
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13,
        Ace = 14        // strongest rank
    }
}