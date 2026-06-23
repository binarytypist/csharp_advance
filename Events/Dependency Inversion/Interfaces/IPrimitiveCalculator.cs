namespace DependencyInversion.PrimitiveCalculatorApp.Interfaces
{
    // Calculator abstraction using Strategy Pattern
    // This interface defines the contract for a primitive calculator that can change its calculation strategy at runtime.
    // The IPrimitiveCalculator interface has two methods:
    //  1. ChangeStrategy(IStrategy strategy): This method allows changing the current calculation strategy by accepting an IStrategy implementation. This enables the calculator to perform different operations
    //  (e.g., addition, subtraction, multiplication, division) without modifying its own code.
    //  2. PerformCalculation(int firstOperand, int secondOperand): This method performs the calculation using the current strategy and returns the result as an integer. The actual operation performed depends
    //  on the strategy that is currently set.
    public interface IPrimitiveCalculator
    {
        void ChangeStrategy(IStrategy strategy);
        int PerformCalculation(int firstOperand, int secondOperand);
    }
}