using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonExplorer
{
    public class Room
    {
        public int Id { get; }
        public string Description { get; }
        public List<Monster> Monsters { get; } = new();
        public List<Item> Items { get; } = new();
        public Room(int id, string description)
            => (Id, Description) = (id, description);
        public void Describe()
        {
            Console.WriteLine(Description);
            if (Monsters.Any())
                Console.WriteLine($"Monsters here: {string.Join(", ", Monsters.Select(m => m.Name))}");
            if (Items.Any())
                Console.WriteLine($"Items here: {string.Join(", ", Items.Select(i => i.Name))}");
        }
        public Monster? GetMonster(string name)
            => Monsters.FirstOrDefault(m => m.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        public Item? GetItem(string name)
            => Items.FirstOrDefault(i => i.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }
}