using System;
using Something.Scripts.Something.Characters;
using Something.SomethingArchitecture.Scripts.Something.Characters.Base;
using UnityEngine;
using UnityEngine.AI;

namespace Something.SomethingArchitecture.Scripts.Something.Characters.Enemy
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyCharacterView : MonoBehaviour
    {
        [SerializeField] private EnemyEyeRaycast[] _enemyEyeRaycast;
        private EnemyCharacter _enemyCharacter;

        public Action UpdateTick;
        public Action Destroyed;
        public Action<IPlayableCharacter> FindTarget;

        public void Die() =>
            Destroy(this.gameObject);

        private void OnDestroy() =>
            Destroyed?.Invoke();

        private void Update()
        {
            UpdateTick?.Invoke();
        }
    }
}