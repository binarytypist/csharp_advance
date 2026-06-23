
using System;
using WorkForce.JobManagementSystem.Interfaces;

namespace WorkForce.JobManagementSystem.IO
{
    // Concrete implementation of IWriter
    // This class outputs text to the console

    // Why do we use this class?
    // - It hides Console.WriteLine() behind an abstraction
    // - Engine does NOT depend directly on Console
    // - Makes system flexible (can swap output later)

    public class ConsoleWriter : IWriter
    {
        // Writes a line to the console output
        public void WriteLine(string line) => Console.WriteLine(line);
    }
}