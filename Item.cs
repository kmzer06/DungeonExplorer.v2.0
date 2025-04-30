using System;

namespace DungeonExplorer
{
    public abstract class Item : ICollectible
    {
        public string Name { get; protected set; }
        protected Item(string name) => Name = name;
        public abstract void Use(Player player);
    }

    public class Weapon : Item
    {
        public int Damage { get; private set; }
        public Weapon(string name, int damage) : base(name) => Damage = damage;
        public override void Use(Player player)
        {
            player.EquipWeapon(this);
            Console.WriteLine($"{player.Name} equips {Name}, damage now {Damage}.");
        }
    }

    public class Potion : Item
    {
        public int HealAmount { get; private set; }
        public Potion(string name, int healAmount) : base(name) => HealAmount = healAmount;
        public override void Use(Player player)
        {
            player.Heal(HealAmount);
            Console.WriteLine($"{player.Name} uses {Name} and heals {HealAmount} health.");
        }
    }
}