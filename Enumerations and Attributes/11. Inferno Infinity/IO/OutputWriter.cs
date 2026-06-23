namespace InfernoInfinity.IO
{
    using System;

    // Simple wrapper around Console.WriteLine()
    public class OutputWriter
    {
        // Writes output to console
        internal void WriteLine(string text) => Console.WriteLine(text);
    }
}