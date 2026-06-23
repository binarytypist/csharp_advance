using System;
using System.Collections.Generic;

namespace GenericCountMethodDouble
{
    public class Program
    {
        static void Main(string[] args)
        {
            // INPUT:
            // First line: n (how many double numbers will be read)
            // Next n lines: double numbers
            // Last line: a comparison number (double)

            // Example Input:
            // 3
            // 1.5
            // 2.7
            // 5.1
            // 2.0

            int n = int.Parse(Console.ReadLine()); // read how many numbers

            // Create a Box<double> object with an empty list
            Box<double> boxes = new Box<double>(new List<double>());

            // Read n double values and add them to the list
            for (int i = 0; i < n; i++)
            {
                double number = double.Parse(Console.ReadLine()); // read number
                boxes.Info.Add(number); // store in list
            }

            // Read value to compare against
            double element = double.Parse(Console.ReadLine());

            // Count how many numbers are greater than the given element
            double result = boxes.CountGreaterValues(element);

            // OUTPUT:
            // prints how many numbers are greater than "element"
            // Example output: 2

            Console.WriteLine(result);
        }
    }
}