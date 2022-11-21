using System;
using SomethingArchitecture.Scripts.Something.Weapon.Factory;

namespace Something.Scripts.Something.Weapon.Base
{
    public interface IWeaponModel
    {
        WeaponData WeaponData { get; }
        IWeaponMagazine CurrentWeaponMagazine { get; }
        bool PerformShoot();
        void ReloadMagazine(IWeaponMagazine weaponMagazine);

        event Action<float> AttackPerformed;
        event Action<int> MagazineReloaded;
    }
}