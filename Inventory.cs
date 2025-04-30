using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonExplorer
{
    public class Inventory
    {
        private readonly List<Item> items = new();
        public void Add(Item item)
        {
            items.Add(item);
            Console.WriteLine($"{item.Name} added to inventory.");
        }
        public bool Remove(string itemName)
        {
            var item = items.FirstOrDefault(i => i.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase));
            if (item is null)
            {
                Console.WriteLine($"No item named {itemName} found in inventory.");
                return false;
            }
            items.Remove(item);
            Console.WriteLine($"{item.Name} removed from inventory.");
            return true;
        }
        public Item? Get(string itemName)
            => items.FirstOrDefault(i => i.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase));
        public IEnumerable<Weapon> GetWeapons()
            => items.OfType<Weapon>();
        public void ListItems()
        {
            if (!items.Any())
            {
                Console.WriteLine("Inventory is empty.");
                return;
            }
            Console.WriteLine("Inventory contains:");
            items.ForEach(i => Console.WriteLine($"- {i.Name}"));
        }
    }
}