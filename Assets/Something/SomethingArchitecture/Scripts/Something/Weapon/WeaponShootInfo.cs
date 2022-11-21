using UnityEngine;

namespace Something.Scripts.Something.Weapon.Base
{
    public struct WeaponShootInfo
    {
        public WeaponShootInfo(bool isLuckyShoot, Vector3 shootPoint, int weaponCurrentBulletCount,
            int weaponMagazineCapacity)
        {
            IsLuckyShoot = isLuckyShoot;
            ShootPoint = default;
            WeaponCurrentBulletCount = 0;
            WeaponMagazineCapacity = 0;

            if (!isLuckyShoot) return;
            ShootPoint = shootPoint;
            WeaponCurrentBulletCount = weaponCurrentBulletCount;
            WeaponMagazineCapacity = weaponMagazineCapacity;
        }

        public bool IsLuckyShoot { get; private set; }
        public Vector3 ShootPoint { get; private set; }
        public int WeaponCurrentBulletCount { get; private set; }
        public int WeaponMagazineCapacity { get; private set; }
    }
}