using System;
using System.Collections.Generic;
using Something.Scripts.Something;
using Something.Scripts.Something.Weapon.Base;
using Something.SomethingArchitecture.Scripts.Something.Weapon.Factory;

namespace Something.SomethingArchitecture.Scripts.Something.Characters.Base
{
    public interface IWeaponInteract
    {
        IReadOnlyList<WeaponPresenter> Equipped { get; }
        WeaponPresenter CurrentWeapon { get; }
        event Action Switched;
        event Action Added;
        void AddWeapon(WeaponTypeId weaponTypeId);
        void SwitchWeapon(float axis);
        void AddMagazine(WeaponTypeId weaponTypeId);
        bool GetMagazine(WeaponTypeId currentWeaponType, out IWeaponMagazine magazine);
    }
}