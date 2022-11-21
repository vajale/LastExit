using System;
using Something.SomethingArchitecture.Scripts.Something.Weapon.Factory;
using UnityEngine;

namespace Something.Scripts.Something.Weapon.Base
{
    public class WeaponPresenter : IDisposable, IWeaponPresenter
    {
        private IWeaponMagazine _currentMagazine;

        public WeaponPresenter(IWeaponModel model, WeaponView view)
        {
            WeaponModel = model;
            View = view;

            Initialize();
        }

        public IWeaponModel WeaponModel { get; }
        public IWeaponView View { get; }
        public WeaponTypeId Type => WeaponModel.WeaponData.WeaponID;

        public void PerformShoot()
        {
            if (View.IsReloading) return;
            
            WeaponModel.PerformShoot();
        }

        public void Reload(IWeaponMagazine weaponMagazine)
        {
            if (View.IsReloading) return;

            View.StartWeaponReload();
            _currentMagazine = weaponMagazine;
        }

        private void ReloadWeapon()
        {
            WeaponModel.ReloadMagazine(_currentMagazine);
        }

        private void Initialize()
        {
            WeaponModel.AttackPerformed += View.OnPerformShoot;
            View.ReloadAnimationComplete += ReloadWeapon;
            View.Destroy += OnViewDestroy;
        }

        private void Uintialize()
        {
            WeaponModel.AttackPerformed -= View.OnPerformShoot;
            View.ReloadAnimationComplete -= ReloadWeapon;
            View.Destroy -= OnViewDestroy;
        }

        private void OnViewDestroy()
        {
            Uintialize();
        }


        public void Dispose()
        {
            Uintialize();
        }
    }
}