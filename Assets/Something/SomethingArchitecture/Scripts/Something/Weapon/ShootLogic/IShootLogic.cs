using UnityEngine;

namespace Something.Scripts.Something.Weapon.Base
{
    public interface IShootLogic
    {
        Vector3 LastShootLogic { get; }
        bool PerformShootOperation(IWeaponMagazine weaponMagazine);
    }
}