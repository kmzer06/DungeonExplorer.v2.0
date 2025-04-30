using System;

namespace DungeonExplorer
{
    public class Player : Creature
    {
        private Weapon? equippedWeapon;
        public Inventory Inventory { get; } = new();
        public Player(string name, int health = 100) : base(name, health) { }
        public override void Attack(Creature target)
        {
            var damage = equippedWeapon?.Damage ?? 1;
            Console.WriteLine($"{Name} attacks {target.Name} for {damage} damage.");
            target.TakeDamage(damage);
        }
        public void EquipWeapon(Weapon weapon) => equippedWeapon = weapon;
        public void Heal(int amount)
        {
            if (amount < 0)
                throw new ArgumentException("Heal amount cannot be negative.");
            Health += amount;
            Console.WriteLine($"{Name} heals {amount}. Health now {Health}.");
        }
        public void UseItem(string itemName)
        {
            var item = Inventory.Get(itemName);
            if (item is null)
            {
                Console.WriteLine($"You don't have a {itemName}.");
                return;
            }
            item.Use(this);
            Inventory.Remove(itemName);
        }
    }
}