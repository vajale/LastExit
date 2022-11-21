using UnityEngine;

namespace Something.Scripts.Something.Characters.Enemy
{
    public class EnemyAnimator
    {
        private Animator _animator;
        private const string Run = "Run";
        private const string Attack = "Attack";
        private const string Dead = "Dead";

        public EnemyAnimator(Animator animator)
        {
            _animator = animator;
        }

        private void SetBool(string name, bool flag) => _animator.SetBool(name, flag);
        private void SetTriger(string name) => _animator.SetTrigger(name);

        public void OnStartPurpose()
        {
            SetBool(Run, true);
        }

        public void OnStartAttack()
        {
            SetBool(Run, false);
            SetTriger(Attack);
        }

        public void OnDead()
        {
            SetBool(Run, false);
            SetTriger(Dead);
        }
    }
}