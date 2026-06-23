namespace GenericThreeupleTuple
{
    // Generic class Threeuple with 3 type parameters
    // T1, T2, T3 allow storing 3 different types in one object
    // Example: string, int, bool
    public class Threeuple<T1, T2, T3>
    {
        // Constructor initializes all 3 values
        public Threeuple(T1 item1, T2 item2, T3 item3)
        {
            Item1 = item1;
            Item2 = item2;
            Item3 = item3;
        }

        // First value (can be any type T1)
        public T1 Item1 { get; set; }

        // Second value (can be any type T2)
        public T2 Item2 { get; set; }

        // Third value (can be any type T3)
        public T3 Item3 { get; set; }

        // Converts object into readable string format
        public override string ToString()
        {
            return $"{Item1} -> {Item2} -> {Item3}";
        }
    }
}