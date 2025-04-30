// Program.cs (using top-level statements)
using DungeonExplorer;
using System.Linq;

// Setup map and player
var map = new GameMap();
var room1 = new Room(1, "You are in a dimly lit cave.");
var room2 = new Room(2, "You enter a narrow corridor.");
var room3 = new Room(3, "You've found a large chamber!");

room1.Monsters.Add(new Goblin());
room1.Items.Add(new Weapon("Rusty Sword", 3));

room2.Monsters.Add(new Dragon());
room2.Items.Add(new Potion("Small Health Potion", 20));

room3.Items.Add(new Weapon("Steel Sword", 10));
room3.Items.Add(new Potion("Large Health Potion", 50));

map.AddRoom(room1);
map.AddRoom(room2);
map.AddRoom(room3);

map.ConnectRooms(1, "north", 2);
map.ConnectRooms(2, "south", 1);
map.ConnectRooms(2, "east", 3);
map.ConnectRooms(3, "west", 2);

var player = new Player("Hero");

// Start game
new Game(player, map).Start();
Console.WriteLine("Game Over! Thanks for playing.");
Console.ReadKey();

// Note: The above code assumes the existence of classes like Player, GameMap, Room, Monster, etc.
// and their respective methods and properties as defined in the original code snippets.