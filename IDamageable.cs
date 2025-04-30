using System;

namespace DungeonExplorer
{
    public interface IDamageable
    {
        void TakeDamage(int amount);
        bool IsAlive { get; }
    }

    public interface ICollectible
    {
        string Name { get; }
    }
}
