
using DependencyInversion.PrimitiveCalculatorApp.Interfaces;

namespace DependencyInversion.PrimitiveCalculatorApp.Strategies
{
   
    // Divides two numbers
    // This class implements the IStrategy interface, providing a specific implementation for division.
    // The Calculate method takes two integers as input and returns the result of dividing the first operand by the second operand.
    // This class can be used as a strategy in the PrimitiveCalculator to perform division operations when the user selects the division mode.
    // The DivisionStrategy class adheres to the Strategy design pattern, allowing for flexible and interchangeable calculation strategies in the PrimitiveCalculator.
    // By implementing the IStrategy interface, the DivisionStrategy can be easily integrated into the PrimitiveCalculator and used alongside other strategies
    // (e.g., AdditionStrategy, SubtractionStrategy, MultiplicationStrategy) without modifying the calculator's code.
    public class DivisionStrategy : IStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
            => firstOperand / secondOperand;
    }
}