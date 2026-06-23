using System;

// A generic is a feature in C# that allows you to write one class, method, or interface that works with different data types safely.
// or A reusable template that works with any data type while keeping the code type-safe.



// Generics in C# (Memory Explanation)
// 1. Generics allow one class or method to work with multiple types safely.
// Example:

// Box<int>
// Box<string>
// Box<double>

// 2. At compile time, generics are just a blueprint:
// Box<T>

// 3. At runtime (CLR):
// Reference types (string, object):
// CLR uses one shared implementation in memory
// No duplicated code

// Value types (int, double, struct):
// CLR creates specialized versions for each type
// Better performance and direct memory usage

// 4. Memory behavior:
// Reference types → shared generic implementation
// Value types → type-specific implementation

// 5. Before generics:
// class Box
// {
//    object value;
// }

// Problems:
// boxing/unboxing
// casting required
// slower performance
// unsafe runtime errors

// 6. With generics:
class Box<T>
{
    T value;
}

// Benefits:
// no boxing/unboxing
// type-safe at compile time
// faster performance
// less memory usage

// 7. Example:

// Without generics:
// object x = 5;
// int y = (int)x;

// With generics:
// Box<int> box = new Box<int>(5);

// 8. Summary:
// Generics = reusable blueprint
// Reference types = shared implementation
// Value types = optimized implementation
// Improves performance and memory usage




// Why use generics?
// Without generics:
// You need separate classes for int, string, etc.

// class BoxInt
// {
//    int value;
// }

// class BoxString
// {
//    string value;
// }

// With generics:
// One class works for everything
// class Box<T>
// {
//    T value;
// }

namespace GenericBoxOfInteger
{
    // gerneic class Box that can hold any type of data


    public class Program
    {
        static void Main(string[] args)
        {
            // This program demonstrates the use of a generic class Box<T> to store integers.
            // It reads a number of integers from the console, creates a Box<int> for each integer, and prints the box.
            // The Box<T> class is defined in a separate file (Box.cs) and is a generic class that can hold any type of data.
            // The Box<T> class has a property Value of type T and overrides the ToString() method to return a string representation of the box.
            //  Input:  10 20 30 40 50
            // 

            // Read how many integers we will process
            int n = int.Parse(Console.ReadLine());

            // Loop through all inputs
            for (int i = 0; i < n; i++)
            {
                // Read integer from console
                int number = int.Parse(Console.ReadLine());

                // Create a generic Box that stores the integer
                Box<int> box = new Box<int>(number);

                // Print the box (calls Box.ToString())
                Console.WriteLine(box);
            }
        }
    }
}