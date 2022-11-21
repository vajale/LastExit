using UnityEngine;

namespace Something.SomethingArchitecture.Scripts.Something.Characters.Base
{
    [RequireComponent(typeof(CharacterController))]
    public class Character : MonoBehaviour
    {
        [SerializeField] private Transform cameraTransform;
        [SerializeField] private Transform weaponTransform;
        [SerializeField] private float rotationSmooth = 1f;
        private PlayerCharacter _characterModel;

        public Transform CameraTransform => cameraTransform;
        public Transform WeaponTransform => weaponTransform;

        public void ViewInit(PlayerCharacter model)
        {
            _characterModel = model;
        }


        private void Update()
        {
            _characterModel.InteractUpdate();

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