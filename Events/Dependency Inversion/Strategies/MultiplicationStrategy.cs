namespace DependencyInversion.PrimitiveCalculatorApp.Strategies
{
    using DependencyInversion.PrimitiveCalculatorApp.Interfaces;

    // Multiplies two numbers
    public class MultiplicationStrategy : IStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
            => firstOperand * secondOperand;
    }
}