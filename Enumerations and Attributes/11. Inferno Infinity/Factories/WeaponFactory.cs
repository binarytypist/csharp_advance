namespace InfernoInfinity.Factories
{
    using System;
    using Enums;
    using Interfaces;
    using Models.Weapons;

    // Factory responsible for creating weapons
    public partial class WeaponFactory
    {
        internal IWeapon CreateWeapon(string weaponKind, string weaponName, string weaponRarity)
        {
            // Convert string rarity to enum
            WeaponRarity rarity;

            var isRarityValid = Enum.TryParse(weaponRarity, out rarity);

            // If invalid rarity → no weapon created
            if (!isRarityValid)
            {
                return null;
            }

            // Create correct weapon type
            switch (weaponKind)
            {
                case "Axe":
                    return new Axe(weaponName, rarity);

                case "Sword":
                    return new Sword(weaponName, rarity);

                case "Knife":
                    return new Knife(weaponName, rarity);

                default:
                    return null;
            }
        }
    }
}