using _03.Dependency_Inversion.IO;
using DependencyInversion.PrimitiveCalculatorApp.Controllers;
using DependencyInversion.PrimitiveCalculatorApp.IO;
using DependencyInversion.PrimitiveCalculatorApp.Models;

namespace DependencyInversion.PrimitiveCalculatorApp
{
  

    // Program entry point
    public class StartUp
    {
        public static void Main()
        {
            var reader = new ConsoleReader();              // input source
            var writer = new ConsoleWriter();              // output source
            var calculator = new PrimitiveCalculator();    // core logic

            new Engine(calculator, reader, writer).Run();  // start program
        }
    }
}


// For this Dependency Inversion Calculator project, the input consists of:

//  mode <operator > → changes the calculation strategy
//  <number1> <number2> → performs calculation using the current strategy
//  End → stops the program
//  Example Input 1
//  5 3
//  mode -
//  10 4
//  mode *
//  6 7
//  mode /
//  20 5
//  End
//  Step-by-step
//  Default mode = + (Addition)

//  5 3      => 5 + 3 = 8
//  mode -   => switch to Subtraction
//  10 4     => 10 - 4 = 6
//  mode *   => switch to Multiplication
//  6 7      => 6 * 7 = 42
//  mode /   => switch to Division
// 20 5     => 20 / 5 = 4
//  Output
//  8
//  6
//  42
//  4
//  Example Input 2
//  mode *
//  3 5
//  2 8
//  mode +
//  10 20
//  End
//  Output
//  15
//  16
//  30
//  Example Input 3
//  100 50
//  50 25
//  End

//  Since the default strategy is AdditionStrategy, the output is:

//  150
//  75
//  Supported Commands
//  mode +   -> Addition
//  mode -   -> Subtraction
//  mode *   -> Multiplication
//  mode /   -> Division
//  End      -> Stop program
//  Architecture Flow
//  Input
//    ↓
//  Engine
//    ↓
//  PrimitiveCalculator
//    ↓
//  Current Strategy
//  (+, -, *, /)
//  ↓
//  Result
//  ↓
//  ConsoleWriter
//   ↓
//  Output

// This project demonstrates:

//  Dependency Inversion Principle(DIP)
//  Strategy Pattern
//  Dependency Injection
//  Switching behavior at runtime without changing the calculator code.