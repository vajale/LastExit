using System;
using Something.Scripts.Something.Weapon.AmmoTypes;

namespace Something.Scripts.Something.Weapon.Base
{
    public interface IWeaponMagazine
    {
        IAmmo AmmoType { get; }
        bool IsEmpty { get; }
        int Ammo { get; }
        int MagazineCapacity { get; }
        Action Changed { get; set; }
        bool SpendAmmo(int count);
    }
}