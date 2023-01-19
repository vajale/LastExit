using Something.Scripts.Something;
using Something.Scripts.Something.Characters;
using Something.Scripts.Something.Characters.MoveControllers;
using Something.Scripts.Something.Weapon.AmmoTypes;
using Something.Scripts.Something.Weapon.Base;
using Something.SomethingArchitecture.Scripts.Architecture.GameInfrastucture.States;
using Something.SomethingArchitecture.Scripts.Something.Weapon.Factory;
using UnityEngine;

namespace Something.SomethingArchitecture.Scripts.Something.Characters.Base
{
    public class PlayerCharacterModel : IControllablePlayableCharacter
    {
        private IInputContext _inputContext;
        private Transform _cameraTransfrom;

        public IWeaponInteract WeaponInventory { get; private set; }
        public IPlayerMoveController MoveController { get; set; }

        public Health Health { get; }

        public PlayerCharacterModel(UnitBody unitBody, IPlayerMoveController moveController)
        {
            Health = unitBody.Health;
            MoveController = moveController;
        }

        public void SetWeaponInteract(IWeaponInteract weaponInteract)
        {
            WeaponInventory = weaponInteract;
        }

        #region InteractShit

        public void ControlInteractUpdate()
        {
            if (_inputContext == null)
                return;

            MoveController.Move(ref _inputContext);

            WeaponInteractUpdate();
            PlayerInteract();
        }

        private void PlayerInteract()
        {
            if (_inputContext.Interact)
            {
                var transform = _cameraTransfrom.transform;
                
                if (Physics.Raycast(transform.position, transform.forward, out var hit))
                {
                    if (hit.collider.TryGetComponent<ITouchable>(out var touchable))
                    {
                        touchable.Touch();
                        
                    }
                }
            }
        }

        private void WeaponInteractUpdate()
        {
            if (_inputContext.MouseScrollWheel >= 0.1f || _inputContext.MouseScrollWheel <= -0.1f)
            {
                WeaponInventory.SwitchWeapon(_inputContext.MouseScrollWheel);
            }

            if (_inputContext.WeaponInteractInvoke2)
            {
            }

            if (_inputContext.WeaponInteractInvoke)
            {
                WeaponInventory.CurrentWeapon.PerformShoot();
            }

            if (_inputContext.WeaponReloadInteract)
            {
                if (WeaponInventory.GetMagazine(WeaponInventory.CurrentWeapon.Type, out var newMagazine))
                {
                    WeaponInventory.CurrentWeapon.Reload(newMagazine);
                }
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

        public void SetCamera(Transform characterViewCameraTransform)
        {
            _cameraTransfrom = characterViewCameraTransform;
        }
    }
}