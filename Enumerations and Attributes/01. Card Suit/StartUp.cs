using System;

namespace CardSuitExplorer
{

    // This is a simple C# console application designed to demonstrate the use of enums and how to iterate over them using the built-in Enum class in .NET.
    // The main goal of the program is to display all possible card suits along with their corresponding ordinal values in a structured format.
    // Import the System namespace so we can use Console and Enum.

    
    public class StartUp
    {
        // Program entry point.
        public static void Main()
        {
            // Read a line of text from the console.
            // Example input: "Card Suits"
            var command = Console.ReadLine();

            // Pass the entered text to the method that prints the suits.
            ProcessCommand(command);
        }

        // Method responsible for displaying all card suits.
        private static void ProcessCommand(string command)
        {
            // Print the command followed by a colon.
            // Example output: "Card Suits:"
            Console.WriteLine($"{command}:");

            // Get all values from the CardSuits enum.
            // Result: Clubs, Diamonds, Hearts, Spades
            var suits = Enum.GetValues(typeof(CardSuits));

            // Loop through each enum value.
            foreach (var suit in suits)
            {
                // Print:
                // - The underlying integer value of the enum.
                // - The enum name.
                //
                // Example:
                // Ordinal value: 0; Name value: Clubs
                Console.WriteLine(
                    $"Ordinal value: {(int)suit}; Name value: {suit}");
            }
        }
    }
}