using System.Collections;
using UnityEngine;

namespace Something.Scripts.Something.Weapon.Base
{
    public class WeaponRecoil : MonoBehaviour
    {
        [SerializeField] private WeaponView _currentWeapon;
        [SerializeField] private Transform _camera;

        [Header("Shake parametries")] 
    
        [SerializeField] private float _recoilY;
        [SerializeField] private float _recoilX;
        [SerializeField] private float _recoilZ;

        [SerializeField] private float _snappiness;
        [SerializeField] private float _returnSpeed;
    
        private Vector3 _currentRotation;
        private Vector3 _targetRotation;

        public bool IsAiming { get; set; }

        private void OnEnable()
        {
            _currentWeapon.PerformShoot += RecoilFire;
        }

        private void OnDisable()
        {
            _currentWeapon.PerformShoot -= RecoilFire;
        }

        private void Update()
        {
            //var returnSpeed = IsAiming ? _returnSpeed : _returnSpeed * 5;
        
            _targetRotation = Vector3.Lerp(_targetRotation, Vector3.zero, _returnSpeed * Time.deltaTime);
            _currentRotation = Vector3.Slerp(_currentRotation, _targetRotation, _snappiness * Time.fixedDeltaTime);
            
            _camera.localRotation = Quaternion.Euler(_currentRotation);
        }

        private void RecoilFire()
        {
            _targetRotation += new Vector3(_recoilX, Random.Range(-_recoilY, _recoilY), Random.Range(-_recoilZ, _recoilZ));
        }

        private void ReloadShake()
        {
            StartCoroutine(ShakeCamera(Vector3.right, 1f, 0.2f));
            StartCoroutine(ShakeCamera(Vector3.left, 1f, 1.4f));
            StartCoroutine(ShakeCamera(Vector3.left, 2f, 2.2f));
        }

        IEnumerator ShakeCamera(Vector3 direction, float power, float time)
        {
            yield return new WaitForSeconds(time);

            var finalDirection = direction;

            finalDirection *= power;

            _targetRotation += finalDirection;
        }
    }
}