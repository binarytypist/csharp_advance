using System;

namespace GenericBoxOfString
{
    public class Program
    {
        static void Main(string[] args)
        {
            // INPUT:
            // First line: n (number of strings)
            // Next n lines: strings to be stored in Box<string>

            // Example Input:
            // 3
            // hello
            // world
            // csharp

            int n = int.Parse(Console.ReadLine()); // Read how many strings will follow

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine(); // Read each string input line

                Box<string> box = new Box<string>(line); // Store string inside generic Box<string>

                Console.WriteLine(box); // Print box (calls ToString())
            }

            // OUTPUT (for example input above):
            // System.String: hello
            // System.String: world
            // System.String: csharp
        }
    }
}