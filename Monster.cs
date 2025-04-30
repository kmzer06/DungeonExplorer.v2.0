using System;

namespace DungeonExplorer
{
    public abstract class Monster : Creature
    {
        protected Monster(string name, int health) : base(name, health) { }
        public override abstract void Attack(Creature target);
    }

    public class Goblin : Monster
    {
        public Goblin(string name = "Goblin", int health = 30) : base(name, health) { }
        public override void Attack(Creature target)
        {
            int damage = 5;
            Console.WriteLine($"{Name} swings a club at {target.Name} for {damage} damage.");
            target.TakeDamage(damage);
        }
    }

    public class Dragon : Monster
    {
        public Dragon(string name = "Dragon", int health = 100) : base(name, health) { }
        public override void Attack(Creature target)
        {
            int damage = 20;
            Console.WriteLine($"{Name} breathes fire on {target.Name} for {damage} damage.");
            target.TakeDamage(damage);
        }
    }
}
