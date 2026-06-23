namespace DependencyInversion.PrimitiveCalculatorApp.Interfaces
{
    // Input abstraction (decouples from Console)
    // This interface defines a contract for reading input, allowing for different implementations (e.g., console, file, network).
    public interface IReader
    {
        string ReadLine();
    }
}