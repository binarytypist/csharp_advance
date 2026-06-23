using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSwapMethodString
{
    // Generic class Box<T>
    // This class can store a list of any type (string, int, double, etc.)
    public class Box<T>
    {
        // List that stores all elements of type T
        public List<T> Info { get; set; }

        // Constructor
        // Creates a new copy of the list passed as input
        public Box(List<T> info)
        {
            Info = new List<T>(info);
        }

        // Swap method
        // Swaps two elements in the list by their indexes
        public void Swap(int idx1, int idx2)
        {
            // Tuple swap: exchanges values in one step
            (Info[idx1], Info[idx2]) = (Info[idx2], Info[idx1]);
        }

        // Converts the object to a readable string format
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            // Loop through all elements in the list
            foreach (var item in Info)
            {
                // item.GetType() shows runtime type (System.String, System.Int32, etc.)
                builder.AppendLine($"{item.GetType()}: {item}");
            }

            // Remove last empty line before returning
            return builder.ToString().Trim();
        }
    }
}