using System;
using System.Collections.Generic;

namespace GenericCountMethodString
{
    // Generic class Box<T>
    // Constraint: T must implement IComparable<T>
    // This allows comparison between values using CompareTo()
    public class Box<T> where T : IComparable<T>
    {
        // List that stores all values of type T
        public List<T> Info { get; set; }

        // Constructor
        // Receives a list and creates a new copy of it
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
                // Compare current item with given value
                // CompareTo returns:
                // > 0  → item is greater than value
                // = 0  → equal
                // < 0  → item is smaller
                if (item.CompareTo(value) > 0)
                {
                    counter++; // increase counter if item is greater
                }
            }

            // Return total count of elements greater than value
            return counter;
        }
    }
}