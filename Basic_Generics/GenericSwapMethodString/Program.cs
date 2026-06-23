using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodString
{
    public class Program
    {
        static void Main(string[] args)
        {
            // INPUT:
            // First line: n (number of strings)
            // Next n lines: strings to store in the list
            // Last line: two indexes (idx1 idx2) separated by space

            // Example Input:
            // 3
            // apple
            // banana
            // cherry
            // 0 2

            int n = int.Parse(Console.ReadLine()); // read number of strings

            // Create Box<string> with empty list
            Box<string> boxes = new Box<string>(new List<string>());

            // Read n strings and add them to the list
            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine(); // read string
                boxes.Info.Add(line); // store in list
            }

            // Read two indexes to swap
            int[] indexes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            // Swap elements at given positions
            boxes.Swap(indexes[0], indexes[1]);

            // OUTPUT:
            // Prints list after swapping elements
            Console.WriteLine(boxes);
        }
    }
}