using System;
using Something.Scripts.Something.Characters.MoveControllers.States;
using Something.SomethingArchitecture.Scripts.Something.Characters.Base;
using UnityEngine;

namespace Something.Scripts.Something
{
    public class CameraPlayerState : IUpdatableState
    {
        private readonly CameraConfig _config;
        private readonly Transform _characterCameraTransform;
        private readonly Transform _cameraTransform;
        private bool _isReady;
        private Vector3 _bodyVector;

        public CameraPlayerState(PlayerCharacterView playerPlayerCharacterView, Transform cameraTransform, CameraConfig config = null)
        {
            _characterCameraTransform = playerPlayerCharacterView.CameraTransform;
            _cameraTransform = cameraTransform;
            _config = config;
        }

        public void Enter()
        {
            CheckReady();
            _cameraTransform.SetParent(_characterCameraTransform);
        }

        public void Exit()
        {
            _cameraTransform.SetParent(_cameraTransform);
        }

        public void Update()
        {
            if (!_isReady) return;

            ApplyCameraPosition();
            CalculateRotation();
            ApplyBodyRotation();
        }

        private void CheckReady()
        {
            _isReady = true;

            if (_characterCameraTransform == null)
            {
                _isReady = false;
                throw new Exception("Camera Character state dont have character transform");
            }

            if (_cameraTransform == null)
            {
                _isReady = false;
                throw new Exception("Camera Character state dont have camera transform");
            }
        }

        private void ApplyCameraPosition()
        {
            _cameraTransform.position = _characterCameraTransform.position;
            _cameraTransform.rotation = _characterCameraTransform.rotation;
        }

        private void CalculateRotation()
        {
            float sensivity = 1f;

            if (_config != null)
                sensivity = _config.Sensivity;

            var mouseX = sensivity * Input.GetAxis("Mouse X");
            var mouseY = sensivity * Input.GetAxis("Mouse Y");

            _bodyVector.x -= mouseY;
            _bodyVector.y += mouseX;
            _bodyVector.z = 0;

        }

        private void ApplyBodyRotation()
        {
            _cameraTransform.eulerAngles = _bodyVector;
            var rotation = new Vector3(_bodyVector.x, _bodyVector.y,0f);
            
            _characterCameraTransform.transform.rotation = Quaternion.Euler(rotation);
        }
    }
}