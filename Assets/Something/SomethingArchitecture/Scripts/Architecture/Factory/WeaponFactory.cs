using System;
using Something.Scripts.Something.Weapon.Base;
using Something.SomethingArchitecture.Scripts.Architecture.Factory.Interface;
using Something.SomethingArchitecture.Scripts.Something.Weapon.Factory;
using SomethingArchitecture.Scripts.Architecture.Services;
using SomethingArchitecture.Scripts.Something.Weapon.Factory;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Something.SomethingArchitecture.Scripts.Architecture.Factory
{
    public class WeaponFactory : IWeaponFactory
    {
        private readonly StaticDataService _staticDataService;

        public WeaponFactory(StaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }
        
        public WeaponView Create(Transform parent, WeaponTypeId weaponTypeId, out WeaponPresenter weaponPresenter)
        {
            var data = _staticDataService.GetWeaponData(weaponTypeId);
            var viewPreFab = Object.Instantiate(data.PreFab, parent);

            viewPreFab.TryGetComponent(out WeaponView view);
            if (view == null)
                throw new Exception("PreFab not contains WeaponView Component");

            IShootLogic raycastLogic = null;

            if (data.ShootLogic == WeaponShootLogic.Rifle)
                raycastLogic = new RaycastShootLogic(data.SpreadMultiplier, data.UseSpread, view.ShootSource);
            
            var weaponModel = new WeaponModel(data, raycastLogic);

            weaponPresenter = new WeaponPresenter(weaponModel, view);

            view.SetVizualSettings(data);

            return view;
        }
    }
}