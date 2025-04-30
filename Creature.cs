using System;

namespace DungeonExplorer
{
    public abstract class Creature : IDamageable
    {
        public string Name { get; protected set; }
        public int Health { get; protected set; }
        public bool IsAlive => Health > 0;

        protected Creature(string name, int health)
        {
            Name = name;
            Health = health;
        }

        public void TakeDamage(int amount)
        {
            if (amount < 0)
                throw new ArgumentException("Damage amount cannot be negative.");
            Health = Math.Max(Health - amount, 0);
            Console.WriteLine($"{Name} takes {amount} damage. Remaining health: {Health}");
        }

        public abstract void Attack(Creature target);
    }
}