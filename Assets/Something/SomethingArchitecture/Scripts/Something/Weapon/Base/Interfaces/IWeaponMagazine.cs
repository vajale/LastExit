using System;
using Something.Scripts.Something.Weapon.AmmoTypes;
using Something.SomethingArchitecture.Scripts.Something.Weapon.Factory;

namespace Something.Scripts.Something.Weapon.Base
{
    public interface IWeaponMagazine
    {
        WeaponTypeId WeaponTypeId { get; }
        IAmmo AmmoType { get; }
        bool IsEmpty { get; }
        int Ammo { get; }
        int MagazineCapacity { get; }
        Action Changed { get; set; }
        bool SpendAmmo(int count);
    }
}