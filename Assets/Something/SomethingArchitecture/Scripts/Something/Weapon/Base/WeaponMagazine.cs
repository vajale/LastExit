using System;
using Something.SomethingArchitecture.Scripts.Something.Weapon.Factory;

namespace Something.Scripts.Something.Weapon.Base
{
    public class WeaponMagazine : IWeaponMagazine
    {
        private readonly WeaponTypeId _weaponTypeId;
        public WeaponTypeId WeaponTypeId => _weaponTypeId;
        public IAmmo AmmoType { get; private set; }
        public bool IsEmpty => Ammo <= 0;
        public int Ammo { get; private set; }
        public int MagazineCapacity { get; private set; }
        public Action Changed { get; set; }

        public WeaponMagazine(int startMagazineCapacity, IAmmo ammoType, WeaponTypeId weaponTypeId)
        {
            _weaponTypeId = weaponTypeId;
            Ammo = startMagazineCapacity;
            AmmoType = ammoType;
            MagazineCapacity = startMagazineCapacity;
        }
        
        public bool SpendAmmo(int count)
        {
            if (Ammo <= 0)
            {
                return false;
            }

            bool hasDifference = Ammo < count;

            if (hasDifference)
            {
                var remainCount = Ammo % count;
                Ammo -= remainCount;
            }
            else
            {
                Ammo -= count;
            }

            Changed?.Invoke();
            return true;
        }
    }
}