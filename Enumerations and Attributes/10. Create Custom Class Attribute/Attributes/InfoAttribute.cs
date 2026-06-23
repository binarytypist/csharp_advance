
using System;
using System.Collections.Generic;

namespace CustomClassAttributeSystem.Attributes
{
   
    // This attribute can ONLY be applied to classes
    [AttributeUsage(AttributeTargets.Class)]

    // Custom attribute class used to store metadata about a class
    public class InfoAttribute : Attribute
    {
        // Constructor is called when attribute is used like:
        // [Info("Pesho", 3, "description", "reviewer1", "reviewer2")]
        public InfoAttribute(
            string author,
            int revision,
            string description,
            params string[] reviewers) // params allows multiple reviewer values
        {
            // Store author name
            this.Author = author;

            // Store revision number
            this.Revision = revision;

            // Store description text
            this.Description = description;

            // Convert reviewer array into List<string>
            this.Reviewers = new List<string>(reviewers);
        }

        // Property storing author name (read-only outside class)
        public string Author { get; private set; }

        // Property storing revision number
        public int Revision { get; private set; }

        // Property storing description text
        public string Description { get; private set; }

        // Property storing list of reviewers
        public List<string> Reviewers { get; private set; }
    }
}