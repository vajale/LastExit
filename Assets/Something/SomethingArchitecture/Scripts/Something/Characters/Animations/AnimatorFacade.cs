using UnityEngine;

namespace Something.Scripts.Something.Characters.Animations
{
    public class AnimatorFacade
    {
        private Animator _animator;

        public AnimatorFacade(Animator animator)
        {
            _animator = animator;
        }

        public void SetTrigger(string name)
        {
            _animator.SetTrigger(name);
        }

        public void SetBool(string name, bool flag)
        {
            _animator.SetBool(name, flag);
        }
    }
}