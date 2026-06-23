namespace GenericTuple
{
    // A custom generic Tuple class
    // Tuple is used to store 2 related values together in one object
    // Example: (string, int) like "Name -> Age"
    // Why important:
    //  Helps group data without creating a full class
    //  Useful for temporary data structures
    //  Used in many algorithms and data processing tasks
    public class Tuple<T1, T2>
    {
        // Constructor initializes both values
        public Tuple(T1 item1, T2 item2)
        {
            Item1 = item1;
            Item2 = item2;
        }

        // First value (any type T1)
        public T1 Item1 { get; set; }

        // Second value (any type T2)
        public T2 Item2 { get; set; }

        // Converts tuple to readable string format
        public override string ToString()
        {
            return $"{Item1} -> {Item2}";
        }
    }
}