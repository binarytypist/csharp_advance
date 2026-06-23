
using System.Collections.Generic;
using DependencyInversion.PrimitiveCalculatorApp.Interfaces;
using DependencyInversion.PrimitiveCalculatorApp.Strategies;

namespace DependencyInversion.PrimitiveCalculatorApp.Controllers
{
    // Engine controls the application logic (calculation loop)
    // It processes commands until "End" and manages the current calculation strategy based on user input
    // The Engine is the central controller of the application, orchestrating the interactions between the user input,
    // the calculation strategies, and the output based on user commands.
    // The Engine class is responsible for reading user input, determining the appropriate calculation strategy based on the commands,
    // performing calculations using the PrimitiveCalculator, and outputting the results. It also manages the mapping of operators to their corresponding strategies.

    public class Engine
    {
        //  Fields to hold the main objects of the application
        // "private" means these variables can only be accessed within this class
        //  "IReader" and "IWriter" are abstractions for input and output, allowing us to easily switch between different input/output mechanisms
        // (e.g., console, file) without changing the core logic of the Engine
        //  The Engine does not need to know how the input and output are done, it just uses the reader and writer interfaces to interact with the user.
        //  This design allows for greater flexibility and testability of the code, as we can easily mock the IReader and IWriter interfaces in unit tests.
        private IReader reader;
        //  "writer" is used to output results from the calculations     
        private IWriter writer;
        //  "IDictionary<char, IStrategy>" is used to map operator characters (e.g., '+', '-', '*', '/') to their corresponding calculation strategies.
        //  This allows the Engine to easily switch between different calculation strategies based on user input without modifying the core logic of the Engine.
        private IDictionary<char, IStrategy> strategyMap;
        //  "IPrimitiveCalculator" is the main calculator object that performs calculations based on the current strategy.
        // The Engine interacts with the PrimitiveCalculator to perform calculations based on user commands, and it manages the current strategy by changing it according to the user's input.
        private IPrimitiveCalculator calculator;
        // Constructor for Engine, using Dependency Injection to receive the calculator, reader, and writer from outside
        // This allows for greater flexibility and testability, as we can easily swap out different implementations of IPrimitiveCalculator, IReader, and IWriter
        // (e.g., ConsolePrimitiveCalculator, FilePrimitiveCalculator, ConsoleReader, FileReader, ConsoleWriter, FileWriter) without changing the Engine's code.

        // The constructor initializes the calculator, reader, writer, and strategyMap fields. It also registers the default operations (addition, subtraction,
        // multiplication, division) in the strategyMap.

        public Engine(IPrimitiveCalculator calculator, IReader reader, IWriter writer)
        {
            this.calculator = calculator;
            // The reader is injected into the Engine, allowing it to read user input without being tightly coupled to a specific input mechanism (e.g., console, file).
            // This design adheres to the Dependency Inversion Principle, as the Engine depends on abstractions (IReader) rather than concrete implementations.
            // The Engine does not need to know how the input is done, it just uses the reader interface to read commands from the user.
            // This design allows for greater flexibility and testability of the code, as we can easily mock the IReader interface in unit tests to simulate
            // user input without relying on actual console input.
            this.reader = reader;
            // The strategyMap is initialized as a new Dictionary that maps characters to IStrategy implementations.
            // The default operations are registered in the strategyMap, associating each operator character with its corresponding strategy implementation.
            // For example, the '+' character is associated with the AdditionStrategy, which implements the IStrategy interface and defines how to perform addition.
            this.writer = writer;
            // The writer is injected into the Engine, allowing it to output results without being tightly coupled to a specific output mechanism (e.g., console, file).
            // This design adheres to the Dependency Inversion Principle, as the Engine depends on abstractions (IWriter) rather than concrete implementations.
            // The Engine does not need to know how the output is done, it just uses the writer interface to output results to the user.
            this.strategyMap = new Dictionary<char, IStrategy>();

            // Register default operations
            // The strategyMap is a dictionary that maps operator characters (e.g., '+', '-', '*', '/') to their corresponding calculation strategies
            // (e.g., AdditionStrategy, SubtractionStrategy, MultiplicationStrategy, DivisionStrategy).
            // This allows the Engine to easily switch between different calculation strategies based on user input without modifying the core logic of the Engine.
            // The strategyMap is initialized with the default operations for addition, subtraction, multiplication, and division. 
            this.strategyMap['+'] = new AdditionStrategy();
            this.strategyMap['-'] = new SubtractionStrategy();
            this.strategyMap['*'] = new MultiplicationStrategy();
            this.strategyMap['/'] = new DivisionStrategy();
        }

        // Main method to run the application
        // It processes commands until "End" is received. It reads user input, determines the appropriate calculation strategy based on the commands,
        // performs calculations using the PrimitiveCalculator, and outputs the results. It also manages the mapping of operators to their corresponding strategies.
        // The Run method is the main loop of the application, where it continuously reads user input commands until the "End" command is received.
        // For each command, it checks if the command is to change the mode (i.e., change the calculation strategy) or to perform a calculation.
        // If the command is to change the mode, it updates the current strategy of the calculator using the strategyMap to find the corresponding strategy for the given operator and 
        // it parses the operands from the command, performs the calculation using the current strategy of the calculator and outputs the result using the writer. 
        public void Run()
        {
            // Read the first command from the user input, splitting it into parts (e.g., operator and operands)
            // The command is expected to be in the format: "mode +", "mode -", "mode *", "mode /" for changing the mode, or "a b" for performing a calculation with the current mode.
            // The command is read using the injected IReader, allowing for flexibility in how the input is handled (e.g., console, file).
            var command = this.reader.ReadLine().Split();

            while (command[0] != "End")
            {
                // Change mode (strategy switch)
                if (command[0] == "mode")
                {
                    // If the command is to change the mode, it updates the current strategy of the calculator using the strategyMap to find the
                    // corresponding strategy for the given operator.

                    // The operator is expected to be the second part of the command (e.g., "+", "-", "*", "/"), and it is used to look up the corresponding
                    // strategy in the strategyMap.
                    char op = command[1][0];
                    // The ChangeStrategy method of the calculator is called with the new strategy obtained from the strategyMap, allowing the calculator
                    // to switch to the new calculation strategy at runtime.
                    this.calculator.ChangeStrategy(this.strategyMap[op]);
                }
                else
                {
                    // If the command is not to change the mode, it is expected to be a calculation command with two operands (e.g., "3 5").
                    // The operands are parsed from the command, and the PerformCalculation method of the calculator is called to perform the 
                    // calculation using the current strategy of the calculator. The result is then output using the writer.
                    int a = int.Parse(command[0]);
                    int b = int.Parse(command[1]);

                    // The PerformCalculation method of the calculator is called with the parsed operands, and it performs the calculation using
                    // he current strategy that is set in the calculator.
                    int result = this.calculator.PerformCalculation(a, b);

                    // The result of the calculation is output using the injected IWriter, allowing for flexibility in how the output is handled (e.g., console, file).
                    this.writer.WriteLine(result.ToString());
                }

                // Read the next command from the user input for the next iteration of the loop
                // The command is read using the injected IReader, allowing for flexibility in how the input is handled (e.g., console, file).
                command = this.reader.ReadLine().Split();
            }
        }
    }
}