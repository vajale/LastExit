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

        public void SwitchTarget(ref IPlayableCharacter playableCharacter)
        {
            _enemyAI.SwitchTarget(playableCharacter);
        }

        public void SetCommand(ICommand command)
        {
            _enemyAI.SetCommand(command);
        }

        #region shitas

        public void Initialize()
        {
            Health.Ended += OnHealthEnd;
            //_characterView.Destroyed += Uinitialize;
            //_characterView.FindTarget += _enemyAI.SwitchTarget;
        }

        private void Uinitialize()
        {
            Health.Ended -= OnHealthEnd;
            //_characterView.Destroyed -= Uinitialize;
            //_characterView.FindTarget -= _enemyAI.SwitchTarget;
        }

        private void OnHealthEnd()
        {
            //_characterView.Die();
        }

        #endregion
    }
}