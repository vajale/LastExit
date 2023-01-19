using UnityEngine;

namespace Something.SomethingArchitecture.Scripts.Architecture.Factory
{
    public interface ILootFactory
    {
        Loot Create(LootType type);
    }
}