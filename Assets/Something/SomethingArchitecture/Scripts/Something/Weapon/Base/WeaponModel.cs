using System;
using SomethingArchitecture.Scripts.Something.Weapon.Factory;

namespace Something.Scripts.Something.Weapon.Base
{
    public class WeaponModel : IWeaponModel
    {
        private readonly IShootLogic _shootLogic;

        public WeaponModel(WeaponData weaponData, IShootLogic shootLogic)
        {
            WeaponData = weaponData;
            _shootLogic = shootLogic;
        }

        public WeaponData WeaponData { get; }
        public IWeaponMagazine CurrentWeaponMagazine { get; private set; }

        public event Action<float> AttackPerformed;    
        public event Action<int>  MagazineReloaded;

        public float BulletDamage => CurrentWeaponMagazine.AmmoType.Damage;
        public int Ammo => CurrentWeaponMagazine.Ammo;


        public bool PerformShoot()
        {
            if (TrySpendAmmo(WeaponData.AmmoConsumption))
            {
                _shootLogic.PerformShootOperation(CurrentWeaponMagazine);
                AttackPerformed?.Invoke(CurrentWeaponMagazine.Ammo);
                return true;
            }

            return false;
        }

        public void ReloadMagazine(IWeaponMagazine weaponMagazine)
        {
            if (weaponMagazine == null)
                return;

            CurrentWeaponMagazine = weaponMagazine;
            MagazineReloaded?.Invoke(CurrentWeaponMagazine.Ammo);
        }

        private bool TrySpendAmmo(int ammoConsumption)
        {
            if (CurrentWeaponMagazine == null)
                return false;

            return !CurrentWeaponMagazine.IsEmpty && CurrentWeaponMagazine.SpendAmmo(ammoConsumption);
        }
    }
}