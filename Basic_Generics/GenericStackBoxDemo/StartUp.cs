using System;

namespace GenericStackBoxDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Create a generic Box<int> object
            // Internally it uses a Stack<int>
            Box<int> box = new Box<int>();

            // Add elements to the stack (Last In First Out)
            box.Add(1); // stack: 1
            box.Add(2); // stack: 1, 2
            box.Add(3); // stack: 1, 2, 3

            // Remove top element (LIFO)
            // Output: 3
            Console.WriteLine(box.Remove());

            // Add more elements
            box.Add(4); // stack: 1, 2, 4
            box.Add(5); // stack: 1, 2, 4, 5

            // Remove top element again
            // Output: 5
            Console.WriteLine(box.Remove());
        }
    }
}