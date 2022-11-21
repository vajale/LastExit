using Something.Scripts.Something.Weapon.AmmoTypes;
using Something.Scripts.Something.Weapon.Base;
using UnityEngine;

namespace Something.Scripts.Something.Characters.UnitBody
{
    public interface IWeaponVisitor
    {
        void Visit(RifleAmmo rifleAmmo, RaycastHit raycastHit);
        void Visit(UspAmmo uspAmmo, RaycastHit raycastHit);
        void Visit(IAmmo rifleAmmo, RaycastHit raycastHit);
    }
}
