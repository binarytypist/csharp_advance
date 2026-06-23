namespace DependencyInversion.PrimitiveCalculatorApp.Interfaces
{
    //  Output abstraction (decouples from Console)
    // This interface defines a contract for writing output, allowing for different implementations (e.g., console, file, network).
    //  The IWriter interface has a single method, WriteLine(string line), which takes a string as input and outputs it. The actual implementation
    //  of how the output is handled (e.g., writing to the console, writing to a file) is determined by the class that implements this interface.
    public interface IWriter
    {
        void WriteLine(string line);
    }
}