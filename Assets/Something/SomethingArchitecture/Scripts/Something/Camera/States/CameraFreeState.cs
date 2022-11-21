using Something.Scripts.Something.Characters.MoveControllers.States;
using UnityEngine;

namespace Something.Scripts.Something
{
    public class CameraFreeState : IUpdatableState
    {
        private readonly Transform _cameraTransform;
        private Vector3 _finalVector;
        private float _sensivity;
        
        public CameraFreeState(Transform transform, float configSensivity)
        {
            _cameraTransform = transform;
            _sensivity = configSensivity;
        }

        public void Enter()
        {
        }

        public void Exit()
        {
        }

        public void Update()
        {
            CalculateRotation();
            ApplyBodyRotation();
        }
        
        private void CalculateRotation()
        {
            float sensivity = 1f;

            var mouseX = sensivity * Input.GetAxis("Mouse X");
            var mouseY = sensivity * Input.GetAxis("Mouse Y");

            _finalVector.x -= mouseY;
            _finalVector.y += mouseX;
            _finalVector.z = 0;
        }

        private void ApplyBodyRotation()
        {
            _cameraTransform.eulerAngles = _finalVector;
            var rotation = new Vector3(0, _finalVector.y, 0);
            var playerRotation = Quaternion.Euler(rotation);
            _cameraTransform.transform.rotation = playerRotation;
        }
    }
}