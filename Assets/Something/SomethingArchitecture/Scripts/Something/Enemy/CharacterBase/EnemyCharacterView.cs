using System;
using UnityEngine;
using UnityEngine.AI;

namespace Something.SomethingArchitecture.Scripts.Something.Characters.Enemy
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyCharacterView : MonoBehaviour
    {
        private EnemyCharacter _enemyCharacter;

        public Action UpdateTick;
        public Action Destroyed;

        public void Die()
        {
            Destroy(this.gameObject);
        }

        private void OnDestroy()
        {
            Destroyed?.Invoke();
        }

        private void Update()
        {
            if (_enemyCharacter != null)
                _enemyCharacter.Update();
        }

        public void InitializeModel(EnemyCharacter model)
        {
            _enemyCharacter = model;
        }
    }
}