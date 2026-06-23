using System;
using Traffic_Lights.Enums;

namespace Traffic_Lights.Models
{
    
    // This class represents a single traffic light
    // It can change its state: Red → Green → Yellow → Red
    public class TrafficLight
    {
        // Stores how many possible light states exist (3: Red, Green, Yellow)
        private readonly int lightsCount;

        // Constructor receives initial light state
        public TrafficLight(LightColor light)
        {
            // Set initial light color
            this.Light = light;

            // Get total number of enum values (3)
            this.lightsCount = Enum.GetNames(typeof(LightColor)).Length;
        }

        // Current state of the traffic light
        // Private set → only this class can change it
        public LightColor Light { get; private set; }

        // Changes light to next state in cycle
        public void ChangeLight()
        {
            // Convert enum to integer
            // Red = 0, Green = 1, Yellow = 2
            var nextValue = (int)this.Light + 1;

            // If we go past last value (Yellow)
            // reset back to 0 (Red)
            if (nextValue == this.lightsCount)
            {
                nextValue = 0;
            }

            // Convert integer back to enum
            var nextLight = (LightColor)nextValue;

            // Update current light
            this.Light = nextLight;
        }
    }
}