using Something.Scripts.Something;
using Something.Scripts.Something.Characters;
using Something.Scripts.Something.Characters.MoveControllers;
using Something.Scripts.Something.Weapon.AmmoTypes;
using Something.Scripts.Something.Weapon.Base;
using Something.SomethingArchitecture.Scripts.Something.Characters.Base.Base;
using Something.SomethingArchitecture.Scripts.Something.Weapon.Factory;
using UnityEngine;

namespace Something.SomethingArchitecture.Scripts.Something.Characters.Base
{
    public class PlayerCharacterModel : IControllablePlayableCharacter
    {
        private IInputContext _inputContext;

        //public IInventory Inventory { get; set; }
        public IWeaponInteract WeaponInventory { get; private set; }
        public IPlayerMoveController MoveController { get; set; }
        public IWeaponModel CurrentWeapon => WeaponInventory.CurrentWeapon.WeaponModel;

        public Health Health { get; }

        public PlayerCharacterModel(UnitBody unitBody, IPlayerMoveController moveController, IInventory inventory)
        {
            Health = unitBody.Health;
            MoveController = moveController;
            //Inventory = inventory;
        }

        public void SetWeaponInteract(IWeaponInteract weaponInteract)
        {
            WeaponInventory = weaponInteract;
        }

        #region InteractShit

        public void InteractUpdate()
        {
            if (_inputContext == null)
                return;

            MoveController.Move(ref _inputContext);

            WeaponInteractUpdate();
        }

        private void WeaponInteractUpdate()
        {
            if (_inputContext.MouseScrollWheel >= 0.1f || _inputContext.MouseScrollWheel <= -0.1f)
            {
                WeaponInventory.SwitchWeapon(_inputContext.MouseScrollWheel);
            }

            if (_inputContext.WeaponInteractInvoke2)
            {
                Debug.Log(WeaponInventory.CurrentWeapon.Type);
            }

            if (_inputContext.WeaponInteractInvoke)
            {
                WeaponInventory.CurrentWeapon.PerformShoot();
            }

            if (_inputContext.WeaponReloadInteract)
            {
                IWeaponMagazine weaponMagazine = null;

                switch (WeaponInventory.CurrentWeapon.Type)
                {
                    case WeaponTypeId.Pistol:
                        var pistol = new UspAmmo();
                        weaponMagazine = new WeaponMagazine(7, pistol);
                        break;
                    case WeaponTypeId.Rifle:
                        var rifle = new RifleAmmo();
                        weaponMagazine = new WeaponMagazine(30, rifle);
                        break;
                }

                WeaponInventory.CurrentWeapon.Reload(weaponMagazine);
            }
        }

        #endregion

        #region inputContext

        public void SetInputContext(ref IInputContext inputContext)
        {
            _inputContext = inputContext;
        }

        public void RemoveInputContext()
        {
            _inputContext = null;
        }

        #endregion
    }
}