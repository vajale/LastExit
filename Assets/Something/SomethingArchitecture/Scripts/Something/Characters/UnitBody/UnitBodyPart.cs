using Something.Scripts.Something.Characters.UnitBody;
using Something.Scripts.Something.Weapon.AmmoTypes;
using Something.Scripts.Something.Weapon.Base;
using UnityEngine;

public class UnitBodyPart : MonoBehaviour, IWeaponVisitor
{
    [SerializeField] private EnemyUnitBodyPresenter bodyOwner;
    [SerializeField] private float damageMultiplier = 1f;

    public void Visit(RifleAmmo rifleAmmo, RaycastHit raycastHit)
    {
    }

    public void Visit(UspAmmo uspAmmo, RaycastHit raycastHit)
    {
    }

    public void Visit(IAmmo ammoType, RaycastHit raycastHit)
    {
        bodyOwner.SpawnParticliesOnPoint(raycastHit);
        bodyOwner.Visit?.Invoke(ammoType, damageMultiplier);
    }
}