using System;
using System.Collections.Generic;

namespace GenericCountMethodString
{
    public class Program
    {
        static void Main(string[] args)
        {
            // INPUT:
            // First line: n (number of strings)
            // Next n lines: strings to be added into the list
            // Last line: a string used for comparison

            // Example Input:
            // 3
            // apple
            // banana
            // cherry
            // banana

            int n = int.Parse(Console.ReadLine()); // read number of strings

            // Create a Box<string> with an empty list
            Box<string> boxes = new Box<string>(new List<string>());

            // Read n strings and store them in the list
            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine(); // read string input
                boxes.Info.Add(line); // add to list
            }

            // Read element to compare against
            string element = Console.ReadLine();

            // Count how many strings are lexicographically greater than "element"
            int result = boxes.CountGreaterValues(element);

            // OUTPUT:
            // Prints how many strings are "greater" in dictionary order
            // Example output: 2

            Console.WriteLine(result);
        }
    }
}