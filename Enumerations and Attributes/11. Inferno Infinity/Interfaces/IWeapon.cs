namespace InfernoInfinity.Interfaces
{
    using Enums;

    // Defines behavior of all weapons
    public interface IWeapon
    {
        // Weapon name (Excalibur, etc.)
        string Name { get; }

        // Damage range
        int MaxDamage { get; }
        int MinDamage { get; }

        // Weapon rarity (Common, Rare, Epic)
        WeaponRarity Rarity { get; }

        // Array of gem sockets
        IGem[] GemSockets { get; }

        // Adds gem to socket
        void AddGem(IGem gem, int socketIndex);

        // Removes gem from socket
        void RemoveGem(int socketIndex);
    }
}