namespace WorkForce.JobManagementSystem.Interfaces
{
    // Abstraction for input source
    // Instead of depending directly on Console.ReadLine(),
    // the system depends on this interface

    // Why is this important?
    // - Decouples input logic from application logic
    // - Allows testing (mock input)
    // - Allows alternative input sources (file, API, etc.)

    public interface IReader
    {
        // Reads a single line of input from any source
        string ReadLine();
    }
}