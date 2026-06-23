using System;

namespace CardPowerExplorer.Attributes
{
    // This attribute can be applied to classes and enums only
    // It is used to store extra metadata (Type, Category, Description)
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Enum)]
    public class TypeAttribute : Attribute
    {
        // Constructor is called when the attribute is used like:
        // [Type("Enumeration", "Rank", "Description here")]
        public TypeAttribute(string type, string category, string description)
        {
            // Stores the type of the element (e.g., "Enumeration")
            this.Type = type;

            // Stores the category (e.g., "Rank" or "Suit")
            this.Category = category;

            // Stores a human-readable description of the enum/class
            this.Description = description;
        }

        // Property holding the type information
        public string Type { get; set; }

        // Property holding the category information
        public string Category { get; set; }

        // Property holding the description text
        public string Description { get; set; }

        // Controls how the attribute is printed when converted to string
        public override string ToString()
        {
            return $"Type = {this.Type}, Description = {this.Description}";
        }
    }
}