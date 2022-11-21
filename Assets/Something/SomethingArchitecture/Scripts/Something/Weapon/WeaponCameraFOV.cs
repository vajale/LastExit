using System.Collections;
using UnityEngine;

namespace Something.Scripts.Something.Weapon
{
    public class WeaponCameraFOV : MonoBehaviour
    {
        [SerializeField] private Camera _playerCamera;
        [SerializeField] private float _aimSpeed;
        [SerializeField] private float _aimFov;

        public void AimIn()
        {
            StartCoroutine(ChangeCmareFOV(_aimFov, _aimSpeed));
        }

        private void AimOut()
        {
            StartCoroutine(ChangeCmareFOV(40f, _aimSpeed));
        }

        private IEnumerator ChangeCmareFOV(float target, float speed)
        {
            _playerCamera.fieldOfView = Mathf.Lerp(_playerCamera.fieldOfView, target, speed * Time.deltaTime);
            yield return null;
        }
    }
}