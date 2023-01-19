using System.Collections.Generic;
using Something.Scripts.Something.Weapon.Base;
using Something.SomethingArchitecture.Scripts.Architecture;
using UnityEngine;

public class PlayerUIPresenter
{
    private PlayerUIView _view;
    private Player _model;
    private IWeaponModel _bruh;

    private List<WeaponPresenter> weaponMagazines;

    public PlayerUIPresenter(PlayerUIView view, ref Player model)
    {
        _view = view;
        _model = model;

        weaponMagazines = new List<WeaponPresenter>();
    }

    private void FalseUpdate()
    {
        OnHealthChanged();
        OnWeaponSwitched();
    }

    public void Initialize()
    {
        var newWeapon = _model.CurrentPlayableCharacter.WeaponInventory.CurrentWeapon;
        _model.CurrentPlayableCharacter.Health.Changed += OnHealthChanged;
        
        if (!weaponMagazines.Contains(newWeapon))
        {
            newWeapon.WeaponModel.AttackPerformed += OnAmmoChanged;
            newWeapon.WeaponModel.MagazineReloaded += OnReloadWeapon;
            
            weaponMagazines.Add(newWeapon);
        }

        _model.CurrentPlayableCharacter.WeaponInventory.Switched += OnWeaponSwitched;
        _view.OnViewDestroyed += Uninitialize;
        FalseUpdate();
    }

    private void Uninitialize()
    {
        _model.CurrentPlayableCharacter.Health.Changed -= OnHealthChanged;
        foreach (var weapon in weaponMagazines)
        {
            weapon.WeaponModel.AttackPerformed -= OnAmmoChanged;
            weapon.WeaponModel.MagazineReloaded -= OnReloadWeapon;
        }

        _model.CurrentPlayableCharacter.WeaponInventory.Switched -= OnWeaponSwitched;
        _view.OnViewDestroyed -= Uninitialize;
    }

    private void OnHealthChanged()
    {
        var value = _model.CurrentPlayableCharacter.Health.Count;
        _view.SetHealthInfo(value);
    }

    private void OnAmmoChanged(float ammoValue)
    {
        var currentWeapon = _model.CurrentPlayableCharacter.WeaponInventory.CurrentWeapon.WeaponModel;
        if (currentWeapon.CurrentWeaponMagazine == null)
        {
            _view.SetAmmoInfo(0, 0);
            return;
        }

        var ammoCount = currentWeapon.CurrentWeaponMagazine.Ammo;
        var magazineCapacity = currentWeapon.CurrentWeaponMagazine.MagazineCapacity;
        _view.SetAmmoInfo(ammoCount, magazineCapacity);
    }

    private void OnReloadWeapon(int value)
    {
        var currentWeapon = _model.CurrentPlayableCharacter.WeaponInventory.CurrentWeapon.WeaponModel;
        var ammoCount = currentWeapon.CurrentWeaponMagazine.Ammo;
        var magazineCapacity = currentWeapon.CurrentWeaponMagazine.MagazineCapacity;

        _view.SetAmmoInfo(ammoCount, magazineCapacity);
    }

    private void OnWeaponSwitched()
    {
        var weapon = _model.CurrentPlayableCharacter.WeaponInventory.CurrentWeapon;
        var weaponType = weapon.Type;
        var magazine = _model.CurrentPlayableCharacter.WeaponInventory.CurrentWeapon.WeaponModel.CurrentWeaponMagazine;

        _view.SetWeaponName(weaponType.ToString());

        if (magazine != null)
        {
            _view.SetAmmoInfo(magazine.Ammo, magazine.MagazineCapacity);
        }
        else
        {
            _view.SetAmmoInfo(0, 0);
        }
    }
}