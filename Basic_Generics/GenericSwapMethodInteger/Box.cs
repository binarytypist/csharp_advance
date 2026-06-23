using System.Collections.Generic;
using System.Text;

namespace GenericSwapMethodInteger
{
    // Generic class Box<T>
    // This class stores a list of values of type T (int, string, double, etc.)
    public class Box<T>
    {
        // List that holds all elements of type T
        public List<T> Info { get; set; }

        // Constructor
        // Creates a copy of the list passed as a parameter
        public Box(List<T> info)
        {
            Info = new List<T>(info);
        }

        // Swap method
        // Swaps two elements in the list by their indexes
        public void Swap(int idx1, int idx2)
        {
            // Tuple swap (modern C# way)
            // Exchanges values at idx1 and idx2 positions
            (Info[idx1], Info[idx2]) = (Info[idx2], Info[idx1]);
        }

        // Overrides ToString() to control how the object is printed
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            // Loop through each element in the list
            foreach (var item in Info)
            {
                // item.GetType() shows the real runtime type (System.Int32, System.String, etc.)
                builder.AppendLine($"{item.GetType()}: {item}");
            }

            // Trim removes last empty line
            return builder.ToString().Trim();
        }
    }
}