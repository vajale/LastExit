using System;
using UnityEngine;

namespace Something.Scripts.Something.Weapon.Base
{
    [RequireComponent(typeof(Animator))]
    public class WeaponAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private WeaponView _weapon;

        private const string Shoot = "Shoot";
        private const string Reload = "Reload";
        private const string Aim = "Aim";
        public event Action ReloadAnimationComplete;

        public void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void SetTrigger(string value) => _animator.SetTrigger(value);
        private void SetBool(string value, bool flag) => _animator.SetBool(value, flag);

        public void PlayReloadAnimation()
        {
            SetTrigger(Reload);
        }
        
        public void SetAimAnimation()
        {
            SetBool(Aim, true);
        }

        public void RemoveAimAnimation()
        {
            SetBool(Aim, false);
        }

        public void PlayShootAnimation()
        {
            SetTrigger(Shoot);
        }

        public void OnReloadAnimationComplete()
        {
            ReloadAnimationComplete?.Invoke();
        }
    }
}