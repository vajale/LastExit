using Something.Scripts.Something.AI;
using Something.Scripts.Something.Characters;

namespace Something.SomethingArchitecture.Scripts.Something.Characters.Enemy
{
    public class EnemyCharacter : IEnemyCharacter
    {
        private readonly IEnemyAI _enemyAI;

        public IPlayableCharacter Target { get; private set; }
        public IEnemyMover Mover { get; private set; }

        public Health Health { get; private set; }

        public EnemyCharacter(UnitBody unitBody, IEnemyMover mover, IEnemyAI enemyAI)
        {
            Mover = mover;
            _enemyAI = enemyAI;
            Health = unitBody.Health;
        }

        public void Update()
        {
            _enemyAI.UpdateProgress();
        }

        public void SetTarget(ref IPlayableCharacter playableCharacter)
        {
            _enemyAI.SwitchTarget(playableCharacter);
        }

        public void SetCommand(ICommand command)
        {
            _enemyAI.SetCommand(command);
        }
    }
}