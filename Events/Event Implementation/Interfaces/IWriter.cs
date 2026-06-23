namespace CSharpFundamentals.EventImplementation.Interfaces
{
    // IWriter is an interface (a contract)
    // It defines WHAT a writer must do, but NOT HOW it does it

    // Why use an interface?
    // - Decouples code (no dependency on Console directly)
    // - Allows multiple implementations (ConsoleWriter, FileWriter, MockWriter)
    // - Makes code easier to test and extend

    public interface IWriter
    {
        // Any class that implements IWriter MUST implement WriteLine
        void WriteLine(string line);
    }
}