using Something.Scripts.Something.Characters;
using Something.SomethingArchitecture.Scripts.Something.Characters.Base;
using Something.SomethingArchitecture.Scripts.Something.Characters.Enemy;
using UnityEngine;

namespace Something.Scripts.Something.AI
{
    public class AttackCommand : ICommand
    {
        private IPlayableCharacter _target;
        private readonly EnemyCharacter _character;

        private float time;
        
        public AttackCommand(EnemyCharacter enemyCharacter, IPlayableCharacter target)
        {
            _target = target;
            _character = enemyCharacter;
        }

        public void Execute()
        {
            var distance = (_target.MoveController.Transform.position - _character.Mover.transform.position).magnitude;
            _character.Mover.transform.LookAt(_character.Mover.transform);
            
            _character.Animator.Attacking();

            time += Time.deltaTime;
            
            if(time > 0.75f)
            {
                Attack();
            }
            
            if (distance > 2f)
            {
                _character.SetCommand(new ChaseCommand(_target, _character));
            }
        }

        public void Update()
        {
            time = 0f;
        }

        public void Undo()
        {
            
        }

        private bool Attack()
        {
            var targets = Physics.OverlapSphere(_character.Mover.transform.position, 2f);

            foreach (var target in targets)
            {
                if (target.TryGetComponent<IPlayableCharacterView>(out var component))
                {
                    component.CharacterModel.Health.TakeDamage(1f);
                }
            }

            time = 0f;

            return false;
        }
        
        
    }
}