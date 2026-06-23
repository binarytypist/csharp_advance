
using System;
using WorkForce.JobManagementSystem.Interfaces;

namespace WorkForce.JobManagementSystem.IO
{
    // Concrete implementation of IReader
    // This class reads input from the console

    // Why do we use this class?
    // - It hides Console.ReadLine() behind an abstraction
    // - Engine does NOT depend on Console directly
    // - Makes system flexible and testable

    public class ConsoleReader : IReader
    {
        // Reads a line from console input
        public string ReadLine() => Console.ReadLine();
    }
}