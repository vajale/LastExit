using System;
using Something.Scripts.Something.Characters;
using Something.Scripts.Something.Weapon.Base;
using UnityEngine;

public class UnitBody
{
    public Health Health { get; private set; }
    private readonly UnitBodyPresenter _unitBodyPresenter;

    public event Action HealthEnded;

    public UnitBody(Health health, UnitBodyPresenter unitBodyPresenter)
    {
        _unitBodyPresenter = unitBodyPresenter;
        Health = health;
        
        Initialize();
    }

    private void Initialize()
    {
        _unitBodyPresenter.Visit += ApplyDamage;

    }

    private void ApplyDamage(IAmmo ammo, float damageMultiplier)
    {
        var finalDamage = ammo.Damage * damageMultiplier;
        Health.TakeDamage(finalDamage);
        
        Debug.Log("Health is" + Health.Count);
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