using System;

namespace GenericThreeupleTuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            // =========================
            // INPUT 1
            // =========================
            // Example:
            // John Smith London UK
            // OR
            // John Smith London New York

            string[] line = Console.ReadLine().Split();

            // If city has 2 words, combine them (e.g., "New York")
            string town = line.Length == 5
                ? $"{line[3]} {line[4]}"
                : line[3];

            // Create first Threeuple:
            // (Full Name, Beer Brand, Town)
            Threeuple<string, string, string> firstTuple =
                new Threeuple<string, string, string>(
                    $"{line[0]} {line[1]}",
                    $"{line[2]}",
                    town);

            Console.WriteLine(firstTuple);

            // =========================
            // INPUT 2
            // =========================
            // Example:
            // Name 100 drunk / not

            line = Console.ReadLine().Split();

            // Create second Threeuple:
            // (Name, Liters of Beer, IsDrunk)
            Threeuple<string, int, bool> secondTuple =
                new Threeuple<string, int, bool>(
                    line[0],
                    int.Parse(line[1]),
                    line[2] == "drunk" ? true : false);

            Console.WriteLine(secondTuple);

            // =========================
            // INPUT 3
            // =========================
            // Example:
            // Name 12.5 BankName

            line = Console.ReadLine().Split();

            // Create third Threeuple:
            // (Name, Account Balance, Bank Name)
            Threeuple<string, double, string> thirdTuple =
                new Threeuple<string, double, string>(
                    line[0],
                    double.Parse(line[1]),
                    line[2]);

            Console.WriteLine(thirdTuple);
        }
    }
}