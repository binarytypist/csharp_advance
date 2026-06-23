using KingsGambit.EventDrivenSimulation.IO;
namespace KingsGambit.EventDrivenSimulation
{
    // Entry point of the application
    public class StartUp
    {
        public static void Main()
        {
            // Create engine with console input/output
            // Engine controls the whole simulation flow

            // Input
            // Arthur
            // Bob Charlie
            // John Peter
            // Attack
            // Kill Bob
            // Attack
            // End

            new Controllers.Engine(new ConsoleReader(), new ConsoleWriter()).Run();
        }


        // Output : 

        // King Arthur is under attack!
        // Royal Guard Bob is defending!
        // Royal Guard Charlie is defending!
        // Footman John is panicking!
        // Footman Peter is panicking!

        // King Arthur is under attack!
        // Royal Guard Charlie is defending!
        // Footman John is panicking!
        // Footman Peter is panicking!
    }
}