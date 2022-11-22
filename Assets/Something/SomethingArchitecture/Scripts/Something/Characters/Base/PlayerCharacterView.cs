using UnityEngine;

namespace Something.SomethingArchitecture.Scripts.Something.Characters.Base
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerCharacterView : MonoBehaviour
    {
        [SerializeField] private Transform cameraTransform;
        [SerializeField] private Transform weaponTransform;
        [SerializeField] private float rotationSmooth = 1f;
        private PlayerCharacterModel _characterModelModel;

        public Transform CameraTransform => cameraTransform;
        public Transform WeaponTransform => weaponTransform;

        public void InitializeModel(PlayerCharacterModel model)
        {
            _characterModelModel = model;
        }
        
        private void Update()
        {
            _characterModelModel.InteractUpdate();

            if (cameraTransform != null)
            {
                var rotation = cameraTransform.rotation.eulerAngles;
                transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
            }

            if (weaponTransform != null)
            {
                weaponTransform.rotation = cameraTransform.rotation;
            }
        }
    }
}