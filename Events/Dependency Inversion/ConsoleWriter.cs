
using System;
using DependencyInversion.PrimitiveCalculatorApp.Interfaces;

namespace DependencyInversion.PrimitiveCalculatorApp.IO
{

    // Writes output to console (can be replaced easily)
    // This class implements the IWriter interface, which defines a contract for writing output.
    // The ConsoleWriter class is responsible for writing output to the console, and it can be easily replaced with another implementation of IWriter
    // (e.g., FileWriter, NetworkWriter) without changing the code that depends on it.
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string line) => Console.WriteLine(line);
    }
}