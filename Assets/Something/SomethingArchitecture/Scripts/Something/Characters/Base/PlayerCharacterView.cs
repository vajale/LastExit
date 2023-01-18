using Something.Scripts.Something.Characters;
using UnityEngine;

namespace Something.SomethingArchitecture.Scripts.Something.Characters.Base
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerCharacterView : MonoBehaviour, IPlayableCharacterView
    {
        [SerializeField] private Transform cameraTransform;
        [SerializeField] private Transform weaponTransform;
        [SerializeField] private float rotationSmooth = 1f;
        
        private PlayerCharacterModel _characterModelModel;

        public PlayerCharacterModel CharacterModel => _characterModelModel;
        public Transform CameraTransform => cameraTransform;
        public Transform WeaponTransform => weaponTransform;

        public void InitializeModel(PlayerCharacterModel model)
        {
            _characterModelModel = model;
        }

        private void Update()
        {
            
            _characterModelModel?.ControlInteractUpdate();

            if (cameraTransform != null)
            {
                var rotation = cameraTransform.rotation.eulerAngles;
                transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
            }

            if (weaponTransform != null)
            {
                weaponTransform.rotation = Quaternion.Euler(CameraTransform.rotation.eulerAngles);
            }
        }
    }
}