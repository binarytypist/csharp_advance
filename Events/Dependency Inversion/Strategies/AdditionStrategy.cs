using DependencyInversion.PrimitiveCalculatorApp.Interfaces;

namespace DependencyInversion.PrimitiveCalculatorApp.Strategies
{

    // Adds two numbers
    // This class implements the IStrategy interface, providing a specific implementation for addition.
    // The IStrategy interface defines a contract for different calculation strategies, and the AdditionStrategy class provides the logic for performing addition.
    // By implementing the IStrategy interface, the AdditionStrategy can be used interchangeably with other strategies (e.g., SubtractionStrategy, MultiplicationStrategy) 
    // in the context of the IPrimitiveCalculator, allowing for flexible and extensible design.
    // The Calculate method takes two integer operands and returns their sum as an integer. This method is called by the IPrimitiveCalculator when the addition strategy is selected.
    // The AdditionStrategy class encapsulates the logic for performing addition, adhering to the Single Responsibility Principle by focusing solely on the addition operation.
    public class AdditionStrategy : IStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand + secondOperand;
        }
    }
}