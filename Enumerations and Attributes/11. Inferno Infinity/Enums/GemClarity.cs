namespace InfernoInfinity.Enums
{
    // Represents the quality/clarity of a gem
    // Higher value = stronger stat bonus multiplier
    public enum GemClarity
    {
        // Weakest gem quality → lowest bonus multiplier
        Chipped = 1,

        // Normal/basic gem quality
        Regular = 2,

        // High-quality gem
        Perfect = 5,

        // Best possible gem quality → highest bonus multiplier
        Flawless = 10
    }
}