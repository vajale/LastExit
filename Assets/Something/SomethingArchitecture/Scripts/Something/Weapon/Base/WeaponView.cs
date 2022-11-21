using System;
using System.Collections;
using Something.SomethingArchitecture.Scripts.Something.Characters.Base;
using SomethingArchitecture.Scripts.Something.Weapon.Factory;
using UnityEngine;
using Random = UnityEngine.Random;


namespace Something.Scripts.Something.Weapon.Base
{
    public class WeaponView : MonoBehaviour, IWeaponView
    {
        [SerializeField] private WeaponAnimator _weaponAnimator;
        [SerializeField] private Transform _shootSource;
        [SerializeField] private AudioSource _shootAudioSource;
        [SerializeField] private AudioSource _reloadAudioSource;

        private bool _isReload = false;

        private ParticleSystem _muzzleParticles;
        private ParticleSystem _sparkParticles;
        private AudioClip _shootSound;
        private AudioClip _reloadSound;
        private Light _muzzleflashLight;
        private float _lightDuration;

        public event Action PerformShoot;

        public Transform ShootSource => _shootSource;
        public bool IsReloading => _isReload;
        public event Action ReloadAnimationComplete;
        public new event Action Destroy;


        #region MonoBehaviourCallback

        private void OnEnable()
        {
            _weaponAnimator.ReloadAnimationComplete += OnWeaponReloadAnimationComplete;
        }

        private void OnDisable()
        {
            _weaponAnimator.ReloadAnimationComplete -= OnWeaponReloadAnimationComplete;
        }

        #endregion

        #region VizualImpact

        private void PlayShootImpact(float value)
        {
            _shootAudioSource.clip = _shootSound;
            _shootAudioSource.Play();
            _muzzleParticles.Emit(1);
            _sparkParticles.Emit(Random.Range(2, 3));
            StartCoroutine(MuzzleFlashLight());
        }

        private IEnumerator MuzzleFlashLight()
        {
            _muzzleflashLight.enabled = true;
            yield return new WaitForSeconds(_lightDuration);
            _muzzleflashLight.enabled = false;
            yield return null;
        }

        #endregion

        public void SetVizualSettings(WeaponData weaponData)
        {
            _muzzleParticles = weaponData.MuzzleParticle;
            _sparkParticles = weaponData.SparkParticle;
            _shootSound = weaponData.ShootSound;
            _reloadSound = weaponData.ReloadSound;
            _muzzleflashLight = weaponData.MuzzelFlashLight;
            _lightDuration = weaponData.LightDuration;
        }

        public void Hide(IWeaponInteract weaponInteract)
        {
            gameObject.SetActive(false);
            _isReload = false;
        }

        public void Draw(IWeaponInteract weaponInteract)
        {
            gameObject.SetActive(true);
            _isReload = false;
        }

        public void OnDestroy() =>
            Destroy?.Invoke();

        public void OnPerformShoot(float value)
        {
            PerformShoot?.Invoke();
            _weaponAnimator.PlayShootAnimation();
            PlayShootImpact(value);
        }

        public void StartWeaponReload()
        {
            _isReload = true;
            _weaponAnimator.PlayReloadAnimation();
        }

        public void EnterAimMode()
        {
            _weaponAnimator.SetAimAnimation();
        }

        public void ExitAimMode()
        {
            _weaponAnimator.RemoveAimAnimation();
        }

        private void OnWeaponReloadAnimationComplete()
        {
            _isReload = false;
            ReloadAnimationComplete?.Invoke();
        }
    }
}