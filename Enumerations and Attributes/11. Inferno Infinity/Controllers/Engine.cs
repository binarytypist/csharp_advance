namespace InfernoInfinity.Controllers
{
    // LINQ used for Skip()
    using System.Linq;

    // Input/Output abstraction classes
    using IO;

    // Factories for creating weapons and gems
    using Factories;

    // This is the main engine that controls the whole program flow
    public class Engine
    {
        // Manages all weapons (create, add gem, remove gem, print)
        private WeaponManager manager;

        // Factory responsible for creating Gem objects
        private GemFactory gemFactory;

        // Handles input reading (console abstraction)
        private InputReader reader;

        // Handles output writing (console abstraction)
        private OutputWriter writer;

        // Constructor initializes all dependencies
        public Engine()
        {
            this.manager = new WeaponManager();
            this.gemFactory = new GemFactory();
            this.reader = new InputReader();
            this.writer = new OutputWriter();
        }

        // Main program loop
        public void Run()
        {
            // Read first command and split by ';'
            var command = this.reader.ReadLine().Split(';');

            // Continue until END command is received
            while (command[0] != "END")
            {
                // Decide action based on first word of command
                switch (command[0])
                {
                    case "Create":
                        // Handle weapon creation
                        this.ParseCommandForCreatingWeapon(command.Skip(1).ToArray());
                        break;

                    case "Add":
                        // Handle adding gem to weapon
                        this.ParseCommandForAddingGemToWeapon(command.Skip(1).ToArray());
                        break;

                    case "Remove":
                        // Handle removing gem from weapon
                        this.ParseCommandForRemovingGemFromWeapon(command.Skip(1).ToArray());
                        break;

                    case "Print":
                        // (Not implemented here, handled at end via manager print)
                        break;

                    default:
                        // Ignore invalid commands
                        break;
                }

                // Read next command
                command = this.reader.ReadLine().Split(';');
            }

            // After END → print all weapons
            this.writer.WriteLine(this.manager.GetAllWeapons());
        }

        // Handles weapon creation command
        private void ParseCommandForCreatingWeapon(string[] cmd)
        {
            // cmd[0] = "Rare Sword"
            // cmd[1] = "Excalibur"

            var weaponName = cmd[1];

            // Split rarity + weapon type
            var weaponType = cmd[0].Split();

            var weaponKind = weaponType[1];     // Sword
            var weaponRarity = weaponType[0];   // Rare

            // Create weapon through manager
            this.manager.CreateWeapon(weaponKind, weaponName, weaponRarity);
        }

        // Handles adding gem to weapon
        private void ParseCommandForAddingGemToWeapon(string[] cmd)
        {
            // cmd[0] = weapon name
            // cmd[1] = socket index
            // cmd[2] = "Ruby 5"

            var weaponName = cmd[0];
            var socketIndex = int.Parse(cmd[1]);

            // Split gem type and level
            var gemType = cmd[2].Split();

            // Create gem using factory
            var gem = this.gemFactory.CreateGem(gemType[1], gemType[0]);

            // If gem is invalid → stop execution
            if (gem == null)
            {
                return;
            }

            // Add gem to weapon
            this.manager.AddGemToWeapon(weaponName, socketIndex, gem);
        }

        // Handles removing gem from weapon
        private void ParseCommandForRemovingGemFromWeapon(string[] cmd)
        {
            var weaponName = cmd[0];
            var socketIndex = int.Parse(cmd[1]);

            // Remove gem from weapon socket
            this.manager.RemoveGemFromWeapon(weaponName, socketIndex);
        }
    }
}