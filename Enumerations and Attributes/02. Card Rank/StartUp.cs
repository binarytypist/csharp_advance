using System;

// This application demonstrates how to use C# enums to represent a fixed domain of values and how to iterate over them dynamically
// using reflection-like built-in methods such as Enum.GetValues.
// It is a foundational example of how strongly typed data structures improve clarity and reduce errors in software design.

namespace CardRankExplorer
{
   
    public class StartUp
    {
        // Application entry point.
        public static void Main()
        {
            // Read text from the console.
            // Example input: "Card Ranks"
            var command = Console.ReadLine();

            // Display all card ranks.
            ProcessCommand(command);
        }

        // Prints all ranks from the CardRanks enum.
        private static void ProcessCommand(string command)
        {
            // Print the title.
            Console.WriteLine($"{command}:");

            // Get all values from the CardRanks enum.
            var cardRanks = Enum.GetValues(typeof(CardRanks));

            // Loop through each rank.
            foreach (var rank in cardRanks)
            {
                // Print the numeric value and enum name.
                Console.WriteLine(
                    $"Ordinal value: {(int)rank}; Name value: {rank}");
            }
        }
    }
}