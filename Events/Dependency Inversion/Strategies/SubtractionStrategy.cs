namespace DependencyInversion.PrimitiveCalculatorApp.Strategies
{
    using DependencyInversion.PrimitiveCalculatorApp.Interfaces;

    // Subtracts two numbers
    public class SubtractionStrategy : IStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand - secondOperand;
        }
    }
}