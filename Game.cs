using System;
using System.Linq;

namespace DungeonExplorer
{
    public class Game
    {
        private readonly Player player;
        private readonly GameMap map;
        private Room current;
        public Game(Player player, GameMap map)
            => (this.player, this.map, current) = (player, map, map.Rooms.First());
        public void Start()
        {
            Console.WriteLine("Welcome to Dungeon Explorer! Would you like to move, look, inventory, pickup, use, attack, or exit?");
            while (player.IsAlive)
            {
                Console.Write("\n> ");
                var input = Console.ReadLine()?.Trim().Split(' ');
                if (input is null || input.Length == 0) continue;
                var cmd = input[0].ToLower();
                var arg = input.Length > 1 ? string.Join(' ', input.Skip(1)) : string.Empty;
                try
                {
                    switch (cmd)
                    {
                        case "move": Move(arg); break;
                        case "look": current.Describe(); break;
                        case "inventory": player.Inventory.ListItems(); break;
                        case "pickup": Pickup(arg); break;
                        case "use": player.UseItem(arg); break;
                        case "attack": Attack(arg); break;
                        case "exit": Console.WriteLine("Thanks for playing!"); return;
                        default: Console.WriteLine("Unknown command."); break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            Console.WriteLine("You have died. Game over.");
        }
        private void Move(string direction)
        {
            if (string.IsNullOrWhiteSpace(direction))
            { Console.WriteLine("Specify a direction to move."); return; }
            var next = map.GetAdjacentRoom(current, direction);
            if (next is null)
                Console.WriteLine("You can't move that way.");
            else
            {
                current = next;
                current.Describe();
            }
        }
        private void Pickup(string itemName)
        {
            if (string.IsNullOrWhiteSpace(itemName))
            { Console.WriteLine("Specify an item to pick up."); return; }
            var item = current.GetItem(itemName);
            if (item is null)
                Console.WriteLine($"No item named {itemName} here.");
            else
            {
                player.Inventory.Add(item);
                current.Items.Remove(item);
            }
        }
        private void Attack(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            { Console.WriteLine("Specify a monster to attack."); return; }
            var monster = current.GetMonster(name);
            if (monster is null)
                Console.WriteLine($"No monster named {name} here.");
            else
            {
                player.Attack(monster);
                if (!monster.IsAlive)
                {
                    Console.WriteLine($"{monster.Name} has been defeated!");
                    current.Monsters.Remove(monster);
                    return;
                }
                monster.Attack(player);
            }
        }
    }
}