namespace InfernoInfinity.Factories
{
    using System;
    using Enums;
    using Interfaces;
    using Models.Gems;

    // Factory responsible for creating IGem objects
    public class GemFactory
    {
        public IGem CreateGem(string kind, string clarity)
        {
            // Convert string clarity into enum (e.g. "Chipped", "Perfect")
            GemClarity gemClarity;

            // Try to parse string into valid enum value
            var isGemValid = Enum.TryParse(clarity, out gemClarity);

            // If invalid clarity → return null (invalid gem)
            if (!isGemValid)
            {
                return null;
            }

            // Create correct gem type based on kind
            switch (kind)
            {
                case "Ruby":
                    return new Ruby(gemClarity);

                case "Emerald":
                    return new Emerald(gemClarity);

                case "Amethyst":
                    return new Amethyst(gemClarity);

                // Unknown gem type → invalid
                default:
                    return null;
            }
        }
    }
}