using CustomClassAttributeSystem.Attributes;
using System;
using System.Linq;

namespace CustomClassAttributeSystem
{

    // This project demonstrates the use of custom attributes in C# combined with reflection to store and retrieve metadata at runtime.
    // The main idea is to attach additional information to a class and then access that information dynamically based on user input.
    
    // The system consists of:
    // A custom attribute(InfoAttribute) that stores metadata
    // A StartUp class where the attribute is applied
    // A runtime reflection mechanism that reads attribute data
    // The program reads commands from the console and displays specific metadata fields from the attribute.

    
    // Custom attribute applied to this class
    // It stores metadata about the class (Author, Revision, Description, Reviewers)
    [Info(
        "Pesho",     // Author
        3,           // Revision number
        "we are learning programming", // Description
        "Pesho",     // Reviewer 1
        "Svetlio"    // Reviewer 2
    )]

    // Entry class of the program
    public class StartUp
    {
        // Program starts here
        public static void Main()
        {
            // ==========================================
            // 1. READ ATTRIBUTE FROM CLASS USING REFLECTION
            // ==========================================

            //      Input-

            //      Author
            //      Revision
            //      Description
            //      Reviewers
            //      END

            // Get custom attributes applied to StartUp class
            // Take the first attribute and cast it to InfoAttribute
            var attr = (InfoAttribute)typeof(StartUp)
                .GetCustomAttributes(false)
                .First();

            // ==========================================
            // 2. READ USER COMMANDS
            // ==========================================

            var command = Console.ReadLine();

            // Keep reading commands until "END"
            while (command != "END")
            {
                // Decide what property of the attribute to display
                switch (command)
                {
                    case "Author":
                        // Print author from attribute
                        Console.WriteLine($"Author: {attr.Author}");
                        break;

                    case "Revision":
                        // Print revision number
                        Console.WriteLine($"Revision: {attr.Revision}");
                        break;

                    case "Description":
                        // Print class description
                        Console.WriteLine($"Class description: {attr.Description}");
                        break;

                    case "Reviewers":
                        // Print all reviewers as comma-separated list
                        Console.WriteLine($"Reviewers: {string.Join(", ", attr.Reviewers)}");
                        break;
                }

                // Read next command
                command = Console.ReadLine();
            }
        }
    }
}