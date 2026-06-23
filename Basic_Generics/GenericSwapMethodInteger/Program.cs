using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodInteger
{
    public class Program
    {
        static void Main(string[] args)
        {
            // INPUT:
            // First line: n (how many integers will be read)
            // Next n lines: integers
            // Last line: two indexes separated by space (idx1 idx2)

            // Example Input:
            // 3
            // 10
            // 20
            // 30
            // 0 2

            int n = int.Parse(Console.ReadLine()); // read count of numbers

            // Create a Box<int> object with empty list
            Box<int> boxes = new Box<int>(new List<int>());

            // Read n integers and store them in the list
            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine()); // read integer
                boxes.Info.Add(number); // add to list
            }

            // Read two indexes (positions to swap)
            int[] indexes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            // Swap elements at given indexes
            boxes.Swap(indexes[0], indexes[1]);

            // OUTPUT:
            // Prints list after swapping elements
            Console.WriteLine(boxes);
        }
    }
}