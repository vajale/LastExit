using System;
using Something.SomethingArchitecture.Scripts.Architecture.Factory;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Something.SomethingArchitecture.Scripts.Something.Characters.Enemy
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyCharacterView : MonoBehaviour
    {
        private EnemyCharacter _enemyCharacter;
        private LootFactory _lootFactory;

        [SerializeField] private Loot _health;
        [SerializeField] private Loot _ammo;

        public Action UpdateTick;
        public Action Destroyed;

        private void Start()
        {
            _lootFactory = new LootFactory(_health, _ammo);
        }

        public void Die()
        {
            Destroy(this.gameObject);

            var random = Random.Range(0, 1);
            if (random == 1)
                _lootFactory.Create(LootType.Ammo);
            else
            {
                _lootFactory.Create(LootType.Health);
            }
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

            _enemyCharacter.Health.Ended += Die;
        }
    }
}