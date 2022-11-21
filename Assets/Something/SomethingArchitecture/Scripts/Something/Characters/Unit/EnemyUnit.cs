using UnityEngine;

namespace Something.Scripts.Something.Characters.Unit
{
    public interface IEnemyUnit
    {
        Transform TargetPosition { get; }
    }

    public class TestEnemy : IEnemyUnit
    {
        public Transform TargetPosition { get; }
        private Health _enemyHealth;
    }
}