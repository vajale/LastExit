using Something.Scripts.Something.AI;
using UnityEngine;

namespace Something.Scripts.Something.EnemyWave
{
    public class SearchTargetCommand : ICommand
    {
        private readonly IEnemyMover _mover;

        public SearchTargetCommand(IEnemyMover mover)
        {
            _mover = mover;
        }
        
        public void Execute()
        {
            _mover.Rotate();
        }

        public void Undo()
        {
            
        }
    }
}