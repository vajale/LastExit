using System;
using Something.SomethingArchitecture.Scripts.Something.Characters.Base;
using UnityEngine;

namespace Something.Scripts.Something.Weapon.Base
{
    public interface IWeaponView
    {
        void Hide(IWeaponInteract weaponInteract);
        void Draw(IWeaponInteract weaponInteract);
        Transform ShootSource { get; }
        bool IsReloading { get; }
        event Action ReloadAnimationComplete;
        event Action Destroy;
        void OnDestroy();
        void OnPerformShoot(float value);
        void StartWeaponReload();
        void EnterAimMode();
        void ExitAimMode();
    }
}