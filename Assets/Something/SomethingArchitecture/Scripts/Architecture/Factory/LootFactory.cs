using UnityEngine;

namespace Something.SomethingArchitecture.Scripts.Architecture.Factory
{
    public class LootFactory : ILootFactory
    {
        private readonly Loot _health;
        private readonly Loot _ammo;

        public LootFactory(Loot health, Loot ammo)
        {
            _health = health;
            _ammo = ammo;
        }
        
        public Loot Create(LootType type)
        {
            switch (type)
            {
                case LootType.Ammo:
                    var ammo = GameObject.Instantiate(_ammo);
                    return ammo;
                    break;
                case LootType.Health:
                    var health = GameObject.Instantiate(_health);
                    return health;
                    break;
            }


            return null;
        }
    }
}