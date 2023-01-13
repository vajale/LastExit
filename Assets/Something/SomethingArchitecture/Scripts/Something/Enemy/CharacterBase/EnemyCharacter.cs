using Something.Scripts.Something.AI;
using Something.Scripts.Something.Characters;
using Something.SomethingArchitecture.Scripts.Something.Characters.Base;

namespace Something.SomethingArchitecture.Scripts.Something.Characters.Enemy
{
    public class EnemyCharacter : IEnemyCharacter
    {
        private readonly IEnemyAI _enemyAI;
        public EnemyAnimator Animator;

        public IEnemyMover Mover { get; private set; }

        public Health Health { get; private set; }

        public EnemyCharacter(UnitBody unitBody, IEnemyMover mover, IEnemyAI enemyAI, EnemyAnimator animator)
        {
            Mover = mover;
            _enemyAI = enemyAI;
            Animator = animator;
            Health = unitBody.Health;
        }

        public void Update()
        {
            _enemyAI.UpdateProgress();
        }

        public void SetCommand(ICommand command)
        {
            _enemyAI.SetCommand(command);
        }
    }
}