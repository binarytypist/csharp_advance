using System;

namespace GenericArrayCreator
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            // Create an array of strings using the generic method
            // Length = 5, every element = "Pesho"
            string[] strings = ArrayCreator.Create(5, "Pesho");

            // Create an array of integers using the same generic method
            // Length = 10, every element = 33
            int[] integers = ArrayCreator.Create(10, 33);

            // Output results (optional check)
            Console.WriteLine(string.Join(" ", strings));
            Console.WriteLine(string.Join(" ", integers));
        }
    }
}