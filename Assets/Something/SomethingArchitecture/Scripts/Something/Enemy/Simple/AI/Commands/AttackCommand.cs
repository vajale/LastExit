using UnityEngine;

namespace Something.Scripts.Something.AI
{
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

        public void Update()
        {
            throw new System.NotImplementedException();
        }

        public void Undo()
        {
            
        }
        
        
    }
}