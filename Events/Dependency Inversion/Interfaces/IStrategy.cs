namespace DependencyInversion.PrimitiveCalculatorApp.Interfaces
{
    // Strategy abstraction for calculator operations
    // This interface defines a contract for different calculation strategies (e.g., addition, subtraction, multiplication, division).
    // Each strategy will implement the Calculate method, which takes two integer operands and returns the result of the calculation as an integer.
    // The IStrategy interface allows for the implementation of the Strategy design pattern, enabling the PrimitiveCalculator to switch between
    // different calculation strategies at runtime without modifying its own code.
    public interface IStrategy
    {
        int Calculate(int firstOperand, int secondOperand);
    }
}