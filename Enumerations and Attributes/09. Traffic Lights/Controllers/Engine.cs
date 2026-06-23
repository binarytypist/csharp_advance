using System;
using System.Collections.Generic;
using System.Text;
using Traffic_Lights.Enums;
using Traffic_Lights.Models;

namespace Traffic_Lights.Controllers
{

   // This class controls the traffic light simulation engine
    // input  2
    // output Yellow
    // input  1
    // output Red

    public class Engine
    {
        // Main execution method
        public void Run()
        {
            // Read traffic lights from input and create devices
            var devices = this.SetTrafficLightsDevicesDevices();

            // Read number of cycles (how many times lights change)
            var numberOfLightChanges = int.Parse(Console.ReadLine());

            // Execute simulation and print result
            Console.WriteLine(this.ChangeLights(devices, numberOfLightChanges));
        }

        // Simulates traffic light changes
        private string ChangeLights(Queue<TrafficLight> devices, int numberOfLightChanges)
        {
            // Efficient string builder for output
            var sb = new StringBuilder();

            // Repeat simulation for given number of cycles
            while (numberOfLightChanges > 0)
            {
                // Loop through each traffic light in queue
                foreach (var device in devices)
                {
                    // Change current light state (Red -> Green -> Yellow -> Red)
                    device.ChangeLight();

                    // Append current light state to output
                    sb.Append($"{device.Light} ");
                }

                // Remove trailing space and move to next line
                sb.Remove(sb.Length - 1, 1)
                  .AppendLine();

                // Decrease cycle count
                numberOfLightChanges--;
            }

            // Return final formatted output
            return sb.ToString().Trim();
        }

        // Creates queue of traffic lights from input
        private Queue<TrafficLight> SetTrafficLightsDevicesDevices()
        {
            // Read input line like: "Red Green Yellow"
            var deviceslightsFromInput = Console.ReadLine().Split();

            // Queue ensures first-in-first-out order
            var devices = new Queue<TrafficLight>();

            // Convert each string into enum + object
            foreach (var lightAsString in deviceslightsFromInput)
            {
                // Convert string to enum value
                LightColor light;

                // Try safe parsing
                var isValid = Enum.TryParse(lightAsString, out light);

                // If valid, create TrafficLight object
                if (isValid)
                {
                    devices.Enqueue(new TrafficLight(light));
                }
            }

            // Return queue of traffic lights
            return devices;
        }
    }
}