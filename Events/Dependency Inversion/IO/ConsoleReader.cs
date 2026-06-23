using DependencyInversion.PrimitiveCalculatorApp.Interfaces;
using System;

namespace _03.Dependency_Inversion.IO
{

    // ConsoleReader is a class that implements the IReader interface.
    // Its responsibility is to read input from the console.
    // Why use an interface?
    // - The program depends on IReader instead of Console directly.
    // - We can easily replace ConsoleReader with another reader
    //   (e.g. FileReader, TestReader).
    // - This follows the Dependency Inversion principle.
    // "public" means this class can be accessed from anywhere in the program
    // "class" means we are defining a new type (ConsoleReader) that can have properties and methods
    // The ConsoleReader class provides a concrete implementation of the IReader interface, allowing the program
    // to read input from the console while adhering to the Dependency Inversion principle. This design allows for greater flexibility and testability,
    // as we can easily mock the IReader interface in unit tests or swap out the ConsoleReader for another implementation without changing the core logic of the program.

    public class ConsoleReader : IReader
    {
        public string ReadLine() => Console.ReadLine();
    }
}