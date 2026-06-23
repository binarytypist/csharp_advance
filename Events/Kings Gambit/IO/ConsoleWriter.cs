namespace KingsGambit.EventDrivenSimulation.IO
{
    using System;
    using KingsGambit.EventDrivenSimulation.Interfaces;

    // Writes output to console (abstraction layer)
    public class ConsoleWriter : IWroiter
    {
        public void WriteLine(string line) => Console.WriteLine(line);
    }
}