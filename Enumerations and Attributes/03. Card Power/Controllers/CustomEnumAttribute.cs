using System;
using CardPowerExplorer.Enums;

namespace CardPowerExplorer.Controllers
{
    // This class demonstrates reading custom attributes from enums using reflection
    public class CustomEnumAttribute
    {
        // Entry point method for this controller
        public void Run()
        {
            // Read input from console
            // Expected values: "Rank" or "Suit"
            var targetEnum = Console.ReadLine();

            // Decide which enum type to inspect using reflection
            var enumType = targetEnum == "Rank"
                ? typeof(Rank)   // if user types Rank → inspect Rank enum
                : typeof(Suit);  // otherwise → inspect Suit enum

            // Get all custom attributes applied on the enum type
            // false = do NOT search inheritance chain
            var attributes = enumType.GetCustomAttributes(false);

            // Print all attributes on separate lines
            Console.WriteLine(string.Join(Environment.NewLine, attributes));
        }
    }
}