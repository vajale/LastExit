using Something.Scripts.Something.Characters;
using UnityEngine;

namespace Something.Scripts.Something.AI
{
    public class ChaseCommand : ICommand
    {
        private readonly Vector3 _target;
        private readonly IEnemyMover _enemyMover;

        public ChaseCommand(ref IPlayableCharacter target, IEnemyMover enemyMover)
        {
            _target = target.MoveController.Transform.position;
            _enemyMover = enemyMover;
        }

        public void Execute()
        {
            _enemyMover.Move(_target);
        }

        public void Undo()
        { 
            _enemyMover.StopMoving();
        }
    }

    public class AttackCommand : ICommand
    {
        private readonly Vector3 _target;
        private readonly IEnemyMover _enemyMover;
        private readonly IEnemyAttacker _enemyAttacker;

        public AttackCommand(IEnemyMover enemyMover)
        {
            _enemyMover = enemyMover;
        }

        public void Execute()
        {
        }

        public void Undo()
        {
        }
        
        
    }
}