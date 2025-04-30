using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class GameMap
    {
        private readonly Dictionary<int, Room> rooms = new();
        private readonly Dictionary<int, Dictionary<string, int>> connections = new();

        public void AddRoom(Room room)
        {
            rooms[room.Id] = room;
            connections[room.Id] = new(StringComparer.OrdinalIgnoreCase);
        }
        public void ConnectRooms(int fromId, string dir, int toId)
        {
            if (!rooms.ContainsKey(fromId) || !rooms.ContainsKey(toId))
                throw new ArgumentException("Invalid room ID for connection.");
            connections[fromId][dir] = toId;
        }
        public Room? GetAdjacentRoom(Room current, string direction)
            => connections[current.Id].TryGetValue(direction, out var nextId) ? rooms[nextId] : null;
        public IEnumerable<Room> Rooms => rooms.Values;
    }
}