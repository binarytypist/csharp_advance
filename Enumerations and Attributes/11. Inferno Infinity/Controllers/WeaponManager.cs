namespace InfernoInfinity.Controllers
{
    // Collections for storing weapons list
    using System.Collections.Generic;

    // LINQ for searching weapon by name
    using System.Linq;

    // StringBuilder for efficient string concatenation
    using System.Text;

    // Factory for creating weapon objects
    using Factories;

    // Interface for weapon abstraction
    using Interfaces;

    // This class manages all weapons in the game
    public class WeaponManager
    {
        // List that stores all created weapons
        private IList<IWeapon> weapons;

        // Factory used to create weapons
        private WeaponFactory weaponFactory;

        // Constructor initializes dependencies
        public WeaponManager()
        {
            // Initialize weapon storage list
            this.weapons = new List<IWeapon>();

            // Initialize weapon factory
            this.weaponFactory = new WeaponFactory();
        }

        // Creates a new weapon and adds it to the list
        internal void CreateWeapon(string weaponKind, string weaponName, string weaponRarity)
        {
            // Use factory to create weapon instance
            var weapon = this.weaponFactory.CreateWeapon(weaponKind, weaponName, weaponRarity);

            // Only add weapon if creation succeeded
            if (weapon != null)
            {
                this.weapons.Add(weapon);
            }
        }

        // Returns formatted string of all weapons
        internal string GetAllWeapons()
        {
            // Build output efficiently
            var sb = new StringBuilder();

            // Loop through all weapons
            foreach (var gun in this.weapons)
            {
                // Add weapon details (ToString of weapon)
                sb.AppendLine(gun.ToString());
            }

            // Remove last newline for clean output
            return sb.ToString().TrimEnd();
        }

        // Adds a gem to a specific weapon socket
        internal void AddGemToWeapon(string weaponName, int socketIndex, IGem gem)
            // Find weapon and call AddGem if it exists
            => this.GetWeapen(weaponName)?.AddGem(gem, socketIndex);

        // Removes a gem from a specific weapon socket
        internal void RemoveGemFromWeapon(string weaponName, int socketIndex)
            // Find weapon and call RemoveGem if it exists
            => this.GetWeapen(weaponName)?.RemoveGem(socketIndex);

        // Helper method: finds weapon by name
        private IWeapon GetWeapen(string weaponName)
            // Returns first matching weapon or null if not found
            => this.weapons.FirstOrDefault(w => w.Name == weaponName);
    }
}