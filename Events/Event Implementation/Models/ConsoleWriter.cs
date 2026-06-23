
using System;
using CSharpFundamentals.EventImplementation.Interfaces;

namespace CSharpFundamentals.EventImplementation.Models
{
    // ConsoleWriter is a class that implements the IWriter interface.
    // Its responsibility is to output text to the console.
    //
    // Why use an interface?
    // - The program depends on IWriter instead of Console directly.
    // - We can easily replace ConsoleWriter with another writer
    //   (e.g. FileWriter, DatabaseWriter, TestWriter).
    // - This follows the Dependency Inversion principle.

    public class ConsoleWriter : IWriter
    {
        // Implementation of the WriteLine method required by IWriter.
        // Receives a string and prints it to the console.
        public void WriteLine(string line) => Console.WriteLine(line);
    }
}