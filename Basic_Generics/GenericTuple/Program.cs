using System;

namespace GenericTuple
{

    // Tuple class is defined in Tuple.cs, this is the main program to test it
    // It reads input, creates Tuple objects, and prints them
    // The program demonstrates how to use the Tuple class with different types of data
    // It shows how to group related data together without creating a full class for it
    // The program handles three different inputs to create three different Tuple objects
    
    public class Program
    {
        static void Main(string[] args)
        {
            // =========================
            // INPUT 1
            // =========================
            // Example:
            // John Smith USA

            string[] line = Console.ReadLine().Split();

            // Create Tuple:
            // (Full Name, Address/City)
            Tuple<string, string> firstTuple =
                new Tuple<string, string>(
                    $"{line[0]} {line[1]}",
                    $"{line[2]}");

            // Print: Item1 -> Item2
            Console.WriteLine(firstTuple);

            // =========================
            // INPUT 2
            // =========================
            // Example:
            // Peter 25

            line = Console.ReadLine().Split();

            // Create Tuple:
            // (Name, Age)
            Tuple<string, int> secondTuple =
                new Tuple<string, int>(
                    line[0],
                    int.Parse(line[1]));

            // Print result
            Console.WriteLine(secondTuple);

            // =========================
            // INPUT 3
            // =========================
            // Example:
            // 10 20.5

            line = Console.ReadLine().Split();

            // Create Tuple:
            // (Integer, Double)
            Tuple<int, double> thirdTuple =
                new Tuple<int, double>(
                    int.Parse(line[0]),
                    double.Parse(line[1]));

            // Print result
            Console.WriteLine(thirdTuple);
        }
    }
}