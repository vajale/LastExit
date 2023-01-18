using Something.Scripts.Something.Characters;
using Something.SomethingArchitecture.Scripts.Something.Characters.Enemy;
using UnityEngine;

namespace Something.Scripts.Something.AI
{
    public class ChaseCommand : ICommand
    {
        private readonly EnemyCharacter _character;
        private readonly IPlayableCharacter _target;

        public ChaseCommand(IPlayableCharacter target, EnemyCharacter character)
        {
            _character = character;
            _target = target;
        }

        public void Execute()
        {
            _character.Mover.Move(_target.MoveController.Transform.position);
            _character.Animator.Run();

            var distance = (_target.MoveController.Transform.position - _character.Mover.transform.position).magnitude;
            
            if (distance < 2f)
            {
                _character.SetCommand(new AttackCommand(_character, _target));
            }
        }

        public void Update()
        {
            
        }

        public void Undo()
        {
        }
    }
}