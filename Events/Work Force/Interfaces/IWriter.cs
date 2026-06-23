namespace WorkForce.JobManagementSystem.Interfaces
{
    // Abstraction for output system
    // Instead of directly using Console.WriteLine(),
    // the system depends on this interface

    // Why is this important?
    // - Decouples output logic from application logic
    // - Makes system testable (mock output writer)
    // - Allows different output targets (console, file, database, etc.)

    public interface IWriter
    {
        // Writes a line of text to any output destination
        void WriteLine(string line);
    }
}