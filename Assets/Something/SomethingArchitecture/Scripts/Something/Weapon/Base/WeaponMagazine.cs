using System;

namespace Something.Scripts.Something.Weapon.Base
{
    public class WeaponMagazine : IWeaponMagazine
    {
        public IAmmo AmmoType { get; private set; }
        public bool IsEmpty { get; private set; }
        public int Ammo { get; private set; }
        public int MagazineCapacity { get; private set; }
        public Action Changed { get; set; }

        public WeaponMagazine(int startMagazineCapacity, IAmmo ammoType)
        {
            Ammo = startMagazineCapacity;
            AmmoType = ammoType;
            MagazineCapacity = startMagazineCapacity;
        }
        public bool SpendAmmo(int count)
        {
            if (Ammo <= 0)
            {
                IsEmpty = true;
                return false;
            }

            IsEmpty = false;
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