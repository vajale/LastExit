using Something.SomethingArchitecture.Scripts.Something.Weapon.Factory;
using UnityEngine;
using UnityEngine.Serialization;

namespace SomethingArchitecture.Scripts.Something.Weapon.Factory
{
    [CreateAssetMenu(fileName = "WeaponData", menuName = "Assets/WeaponData")]
    public class WeaponData : ScriptableObject
    {
        [SerializeField] private WeaponTypeId weaponTypeId;

        #region Settings

        [Header("Settings")] [SerializeField] [Range(0.1f, 20f)]
        private float fireRate = 0.1f;

        [SerializeField] private float spreadMultiplier;
        [SerializeField] private int ammoConsumption;
        [SerializeField] private bool useSpread;
        [Header("Vizual")] [SerializeField] private float lightDuration;
        [SerializeField] private ParticleSystem muzzleParticles;
        [SerializeField] private ParticleSystem sparkParticles;
        [SerializeField] private Light muzzleFlashLight;
        [Header("Audio")] [SerializeField] private AudioClip shootSound;
        [SerializeField] private AudioClip reloadSound;

        #endregion

        #region Weapon PreFab

        [Header("Weapon PreFab")] [SerializeField]
        private GameObject preFab;

        #endregion

        #region Public Fields

        public GameObject PreFab => preFab;

        public float FireRate => fireRate;
        public float SpreadMultiplier => spreadMultiplier;
        public int AmmoConsumption => ammoConsumption;
        public bool UseSpread => useSpread;
        public ParticleSystem MuzzleParticle => muzzleParticles;
        public ParticleSystem SparkParticle => sparkParticles;
        public AudioClip ShootSound => shootSound;
        public AudioClip ReloadSound => reloadSound;
        public Light MuzzelFlashLight => muzzleFlashLight;
        public float LightDuration => lightDuration;
        public WeaponTypeId WeaponID => weaponTypeId;
        public WeaponShootLogic ShootLogic { get; set; }

        #endregion
    }

    public enum WeaponShootLogic
    {
        ShootGun = 0,
        Rifle = 1,
    }
}