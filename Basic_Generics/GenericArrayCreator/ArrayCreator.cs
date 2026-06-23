using System;

namespace GenericArrayCreator
{
    // Generic helper class that creates arrays of any type (T)
    public class ArrayCreator
    {
        // Static generic method
        // T can be int, string, double, etc.
        // length -> size of array
        // item -> value to fill the array with
        public static T[] Create<T>(int length, T item)
        {
            // Create an array of type T with given size
            T[] array = new T[length];

            // Fill all positions in the array with the same item
            Array.Fill(array, item, 0, length);

            // Return the created and filled array
            return array;
        }
    }
}