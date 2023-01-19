using System;
using System.Collections.Generic;
using Something.Scripts.Something.Weapon.AmmoTypes;
using Something.Scripts.Something.Weapon.Base;
using Something.SomethingArchitecture.Scripts.Architecture.Factory.Interface;
using Something.SomethingArchitecture.Scripts.Something.Weapon.Factory;
using UnityEngine;

namespace Something.SomethingArchitecture.Scripts.Something.Characters.Base
{
    public class WeaponInventory : IWeaponInteract
    {
        private readonly Dictionary<WeaponTypeId, WeaponPresenter> _weapons;
        private readonly List<WeaponPresenter> _equippedList;
        private readonly List<IWeaponMagazine> _weaponMagazines;
        private readonly Transform _transform;
        private readonly IWeaponFactory _weaponFactory;
        private int _currentWeaponIndex;

        public WeaponInventory(IWeaponFactory weaponFactory, Transform weaponTransform, int equippedCapacity)
        {
            _transform = weaponTransform;
            _weaponFactory = weaponFactory;
            _equippedList = new List<WeaponPresenter>();
            _weaponMagazines = new List<IWeaponMagazine>();
            _weapons = new Dictionary<WeaponTypeId, WeaponPresenter>();
            _currentWeaponIndex = 0;
        }

        public IReadOnlyList<WeaponPresenter> Equipped => _equippedList;

        public WeaponPresenter CurrentWeapon
        {
            get
            {
                if (_equippedList != null) return _equippedList[_currentWeaponIndex];
                return null;
            }
        }

        public event Action Switched;
        public event Action Added;

        public void SwitchWeapon(float axis)
        {
            var nextIndex = axis * 10 + _currentWeaponIndex;

            if (nextIndex is < 0 or > 1)
            {
                nextIndex = 0;
            }

            _currentWeaponIndex = (int)nextIndex;
            if (_equippedList != null & _currentWeaponIndex < _equippedList.Count)
            {
                SetInteractWeapon(_currentWeaponIndex);
            }
        }

        public void AddMagazine(WeaponTypeId weaponTypeId)
        {
            WeaponMagazine weaponMagazine;

            switch (weaponTypeId)
            {
                case WeaponTypeId.Pistol:
                    weaponMagazine = new WeaponMagazine(7, new UspAmmo(), weaponTypeId);
                    _weaponMagazines.Add(weaponMagazine);
                    break;
                case WeaponTypeId.Rifle:
                    weaponMagazine = new WeaponMagazine(30, new RifleAmmo(), weaponTypeId);
                    _weaponMagazines.Add(weaponMagazine);
                    break;
                case WeaponTypeId.ShootGun:
                    break;
            }
        }

        public bool GetMagazine(WeaponTypeId currentWeaponType, out IWeaponMagazine weaponMagazine)
        {
            foreach (var magazine in _weaponMagazines)
            {
                if (magazine.IsEmpty == false & (magazine.WeaponTypeId == currentWeaponType))
                {
                    weaponMagazine = magazine;
                        
                    return true;
                }
            }

            weaponMagazine = null;
            return false;
        }

        public void SwitchWeapon(int weaponIndex)
        {
            if (Equipped.Count == 0)
                throw new Exception("Equipped count is 0");

            SetInteractWeapon(weaponIndex);
        }

        public void AddWeapon(WeaponTypeId weaponTypeId)
        {
            var view = _weaponFactory.Create(_transform, weaponTypeId, out var weaponPresenter);
            view.Hide(this);
            view.transform.SetParent(_transform);
            _weapons.Add(weaponTypeId, weaponPresenter);

            var equippedCount = _equippedList.Count;

            if (equippedCount != 2)
            {
                SetInEquipped(weaponPresenter);
            }

            Added?.Invoke();
        }

        private void SetInteractWeapon(int index)
        {
            foreach (var equipped in _equippedList)
            {
                equipped.View.Hide(this);
            }

            _equippedList[index].View.Draw(this);
            Switched?.Invoke();
        }

        private void SetInEquipped(WeaponPresenter weapon)
        {
            if (_equippedList.Contains(weapon))
            {
                return;
            }

            _equippedList.Add(weapon);
        }
    }
}