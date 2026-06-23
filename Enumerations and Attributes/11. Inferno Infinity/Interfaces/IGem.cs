namespace InfernoInfinity.Interfaces
{
    using Enums;

    // Defines what every Gem must have
    public interface IGem
    {
        // Gem quality (e.g. Chipped, Regular, Perfect)
        GemClarity Clarity { get; }

        // Bonus stats provided by gem
        int AgilityBonus { get; }
        int StrengthBonus { get; }
        int VitalityBonus { get; }
    }
}