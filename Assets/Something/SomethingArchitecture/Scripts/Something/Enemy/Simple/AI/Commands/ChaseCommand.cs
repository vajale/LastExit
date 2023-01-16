using Something.Scripts.Something.Characters;
using Something.SomethingArchitecture.Scripts.Something.Characters.Enemy;
using UnityEngine;

namespace Something.Scripts.Something.AI
{
    public class ChaseCommand : ICommand
    {
        private readonly EnemyCharacter _character;
        public IPlayableCharacter Target;

        public ChaseCommand(IPlayableCharacter target, EnemyCharacter character)
        {
            _character = character;
            Target = target;
        }

        public void Execute()
        {
            _character.Mover.Move(Target.MoveController.Transform.position);
            _character.Animator.Run();
        }

        public void Update()
        {
            
        }

        public void Undo()
        {
        }
    }
}