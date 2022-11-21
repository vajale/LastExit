using System.Collections.Generic;
using Something.SomethingArchitecture.Scripts.Architecture.Factory;
using UnityEngine;

namespace Something.Scripts.Architecture.Utilities
{
    public class LootProgress : ISaveableProgress<Loot, Transform>
    {
        private readonly Dictionary<int, ILoot> _loots;

        public LootProgress()
        {
            _loots = new Dictionary<int, ILoot>();
        }

        public void Add(Loot value)
        {
            throw new System.NotImplementedException();
        }

        public void Get(Loot value, out Transform result)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ISaveable> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}