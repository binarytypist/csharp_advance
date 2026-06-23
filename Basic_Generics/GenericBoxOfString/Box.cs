namespace GenericBoxOfString
{
    // Generic class Box<T>
    // T is a type placeholder (can be int, string, double, etc.)
    // This allows the same class to work with different data types safely
    public class Box<T>
    {
        // Property that stores the value of type T
        public T Value { get; set; }

        // Constructor
        // Runs when we create a new Box<T>
        // Example: new Box<int>(5) or new Box<string>("Hello")
        public Box(T value)
        {
            Value = value;
        }

        // Overrides default ToString() method
        // Controls how the object is printed in Console.WriteLine
        public override string ToString()
        {
            // Value.GetType() returns the real runtime type (e.g. System.Int32, System.String)
            // This helps us see what type T became when the object was created
            return $"{Value.GetType()}: {Value}";
        }
    }
}