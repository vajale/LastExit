using Something.Scripts.Something.Characters;
using Something.Scripts.Something.Weapon.Base;
using UnityEngine;

public class UnitBody
{
    public Health Health { get; private set; }
    private readonly UnitBodyPresenter _unitBodyComponent;

    public UnitBody(Health health, UnitBodyPresenter unitBodyComponent)
    {
        _unitBodyComponent = unitBodyComponent;
        Health = health;

        Initialize();
    }

    private void Initialize()
    {
        _unitBodyComponent.Visit += ApplyDamage;
    }

    private void ApplyDamage(IAmmo ammo, float damageMultiplier)
    {
        var finalDamage = ammo.Damage * damageMultiplier;
        Health.TakeDamage(finalDamage);
    }

    #region ammoTypeShit

    // private void ApplyDamage(RifleAmmo rifleAmmo)
    // {
    //     var finalDamage = rifleAmmo.Damage * damageMultiplier;
    //     Health.TakeDamage(finalDamage);
    // }
    //
    // private void ApplyDamage(WeaponRaycastModel weapon)
    // {
    //     var finalDamage = weapon.BulletDamage * damageMultiplier;
    //     Health.TakeDamage(finalDamage);
    //     Debug.Log(Health.Count);
    // }

    #endregion
}