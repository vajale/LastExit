using Something.Scripts.Something.Weapon.Base;
using Something.SomethingArchitecture.Scripts.Something.Weapon.Factory;
using SomethingArchitecture.Scripts.Something.Weapon.Factory;
using UnityEngine;

namespace Something.SomethingArchitecture.Scripts.Architecture.Factory.Interface
{
    public interface IWeaponFactory
    {
        WeaponView Create(Transform parent, WeaponTypeId weaponTypeId, out WeaponPresenter weaponPresenter);
    }
}