using System.Collections.Generic;

namespace GenericStackBoxDemo
{
    // Generic class Box<T>
    // This class works like a wrapper around a Stack<T>
    // It can store any type (int, string, double, etc.)
    public class Box<T>
    {
        // Internal stack that stores the elements
        private readonly Stack<T> genericStack;

        // Property that returns how many elements are in the stack
        public int Count => this.genericStack.Count;

        // Constructor
        // Initializes the internal stack
        public Box()
        {
            this.genericStack = new Stack<T>();
        }

        // Add method
        // Pushes an element on top of the stack
        public void Add(T element)
        {
            genericStack.Push(element);
        }

        // Remove method
        // Removes and returns the top element of the stack
        public T Remove()
        {
            return genericStack.Pop();
        }
    }
}