
using DependencyInversion.PrimitiveCalculatorApp.Interfaces;
using DependencyInversion.PrimitiveCalculatorApp.Strategies;

namespace DependencyInversion.PrimitiveCalculatorApp.Models
{

    // PrimitiveCalculator is the context class in the Strategy Pattern
    // This class maintains a reference to the current strategy (calculationStrategy) and delegates the calculation to it.
    // The PrimitiveCalculator class implements the IPrimitiveCalculator interface, which means it must provide implementations for the ChangeStrategy and PerformCalculation methods.

    public class PrimitiveCalculator : IPrimitiveCalculator
    {

        // Reference to the current strategy (e.g., addition, subtraction, multiplication, division)
        // The calculationStrategy field holds the current strategy that the calculator will use to perform calculations.
        // This allows the calculator to change its behavior at runtime by switching strategies.
        private IStrategy calculationStrategy;

        // Default strategy is addition
        // The default constructor initializes the PrimitiveCalculator with the AdditionStrategy as the default calculation strategy.
        // This means that if you create an instance of PrimitiveCalculator without specifying a strategy, it will start with addition as its behavior.
        // This design promotes flexibility and adheres to the Open/Closed Principle, as new strategies can be added without modifying the PrimitiveCalculator class.
        public PrimitiveCalculator()
            : this(new AdditionStrategy())
        {
            // This default constructor initializes the PrimitiveCalculator with the AdditionStrategy as the default calculation strategy.
            // This means that if you create an instance of PrimitiveCalculator without specifying a strategy, it will start with addition as its behavior.    
        }

        public PrimitiveCalculator(IStrategy strategy)
        {
            // Constructor allows setting initial strategy (default is addition)
            // This constructor allows for dependency injection of the initial strategy. By default, it uses the AdditionStrategy, but you can also pass in any other
            // strategy (e.g., SubtractionStrategy, MultiplicationStrategy, DivisionStrategy) when creating an instance of PrimitiveCalculator.
            // This promotes flexibility and adheres to the Open/Closed Principle, as new strategies can be added without modifying the PrimitiveCalculator class.
            // For example, if you want to create a calculator that starts with multiplication, you can call this constructor with a new instance of MultiplicationStrategy, and the calculator will start
            // performing multiplication instead of addition.
            this.calculationStrategy = strategy;
        }

        // Change behavior at runtime
        public void ChangeStrategy(IStrategy strategy)
        {
            // This method allows changing the current strategy at runtime. By passing a new strategy object (e.g., SubtractionStrategy, MultiplicationStrategy, DivisionStrategy), 
            // the behavior of the calculator can be modified without changing the PrimitiveCalculator class itself. This promotes flexibility and adheres to the Open/Closed Principle.
            // For example, if you want to switch from addition to multiplication, you can call this method with a new instance of MultiplicationStrategy, and the calculator will start
            // performing multiplication instead of addition.
            this.calculationStrategy = strategy;
        }

        // Delegate calculation to current strategy
        // This method performs the calculation by delegating to the current strategy's Calculate method.
        // It takes two operands as input and returns the result of the calculation based on the current strategy.
        // For example, if the current strategy is AdditionStrategy, it will return the sum of the two operands. If the current strategy is MultiplicationStrategy,
        // it will return the product of the two operands, and so on.
        // This design allows for flexibility and adherence to the Open/Closed Principle, as new strategies can be added without modifying the PrimitiveCalculator class.
        public int PerformCalculation(int firstOperand, int secondOperand)
        {
            return this.calculationStrategy.Calculate(firstOperand, secondOperand);
        }
    }
}