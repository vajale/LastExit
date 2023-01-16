using Something.Scripts.Something.AI;
using Something.Scripts.Something.Characters;
using Something.SomethingArchitecture.Scripts.Something.Characters.Enemy;

namespace Something.Scripts.Something.EnemyWave
{
    public class EnemySquad
    {
        private readonly EnemyCharacter[] _units;
        private IPlayableCharacter _target;

        public EnemySquad(EnemyCharacter[] unitArray,ref  IPlayableCharacter target)
        {
            _target = target;
            _units = unitArray;
        }

        public void Initialize()
        {
            foreach (var unit in _units)
            {
                unit.SetCommand(new SearchTargetCommand(unit));
            }
        }
    }
}