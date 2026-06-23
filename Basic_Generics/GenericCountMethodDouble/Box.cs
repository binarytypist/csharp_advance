using System;
using System.Collections.Generic;

namespace GenericCountMethodDouble
{
    // Generic class Box<T>
    // Constraint: T must implement IComparable<T>
    // This is required so we can compare values using CompareTo()
    public class Box<T> where T : IComparable<T>
    {
        // Property that stores a list of values of type T
        public List<T> Info { get; set; }

        // Constructor
        // Takes a list of T and creates a copy of it
        public Box(List<T> info)
        {
            Info = new List<T>(info);
        }

        // Method that counts how many elements are greater than a given value
        public int CountGreaterValues(T value)
        {
            int counter = 0;

            // Loop through all elements in the list
            foreach (var item in Info)
            {
                // Compare current item with input value
                // CompareTo returns:
                // > 0  => item is greater than value
                // = 0  => equal
                // < 0  => smaller
                if (item.CompareTo(value) > 0)
                {
                    counter++; // increase count if item is greater
                }
            }

            // Return total count of elements greater than value
            return counter;
        }
    }
}