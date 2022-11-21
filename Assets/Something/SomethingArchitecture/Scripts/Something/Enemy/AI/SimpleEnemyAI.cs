using Something.Scripts.Something.Characters;

namespace Something.Scripts.Something.AI
{
    public class SimpleEnemyAI : IEnemyAI
    {
        private ICommandRecorder _commandRecorder;
        private IEnemyMover _enemyMover;
        private IEnemyAttacker _enemyAttacker;
        private IPlayableCharacter _target;

        public SimpleEnemyAI(IEnemyMover enemyMover)
        {
            _enemyMover = enemyMover;
            _commandRecorder = new EnemyCommandRecorder();
        }

        public void SetCommand(ICommand command)
        {
            _commandRecorder.Undo();
            _commandRecorder.Record(command);
        }

        public void SwitchTarget(IPlayableCharacter playableCharacter)
        {
            _target = playableCharacter;
        }

        public void UpdateProgress()
        {
            
        }
    }
}