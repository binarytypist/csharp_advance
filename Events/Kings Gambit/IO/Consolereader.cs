namespace KingsGambit.EventDrivenSimulation.IO
{
    using System;
    using KingsGambit.EventDrivenSimulation.Interfaces;

    // Reads input from console (abstraction layer)
    public class ConsoleReader : IReader
    {
        public string ReadLine() => Console.ReadLine();
    }
}