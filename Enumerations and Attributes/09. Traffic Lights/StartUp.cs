using Traffic_Lights.Controllers;

namespace Traffic_Lights
{    // Entry point of the application
    public class StartUp
    {
        // Program starts executing here
        public static void Main()
        {
            // Create an instance of Engine and run the traffic light simulation
            // Engine handles:
            // - reading input
            // - creating traffic lights
            // - running simulation
            new Engine().Run();
        }
    }
}