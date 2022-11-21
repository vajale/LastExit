using System;
using Something.Scripts.Something.AI;
using Something.Scripts.Something.Characters;
using Something.SomethingArchitecture.Scripts.Architecture.Data.ID;
using SomethingArchitecture.Scripts.Architecture.Services;
using UnityEngine;
using UnityEngine.AI;
using Object = UnityEngine.Object;

namespace Something.SomethingArchitecture.Scripts.Something.Characters.Enemy
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly StaticDataService _dataService;

        public EnemyFactory(StaticDataService dataService)
        {
            _dataService = dataService;
        }

        public EnemyCharacterView Create(EnemyCharacterID enemyCharacterID, Vector3 spawnPosition,
            IPlayableCharacter playableCharacter = null)
        {
            var enemyData = _dataService.GetEnemy(enemyCharacterID);
            var prefab = Object.Instantiate(enemyData.PreFab, spawnPosition, Quaternion.identity);

            prefab.TryGetComponent(out EnemyCharacterView characterView);
            if (characterView == null)
                throw new Exception("Prefab has no component found EnemyCharacterView!");

            prefab.TryGetComponent(out NavMeshAgent navMeshAgent);
            if (navMeshAgent == null)
                throw new Exception("Prefab has no component found NavMeshAgent!");

            prefab.TryGetComponent(out UnitBodyPresenter unitBodyComponent);
            if (unitBodyComponent == null)
                throw new Exception("CharacterInstance not contains UnitBodyComponent component");

            var health = new Health(enemyData.HealthPointCount);
            var unitBody = new UnitBody(health, unitBodyComponent);

            var mover = new SimpleEnemyMover(navMeshAgent, enemyData.WalkSpeed);
            var simpleAI = new SimpleEnemyAI(mover);

            var model = new EnemyCharacter(unitBody, mover, simpleAI);
            model.Initialize();

            return characterView;
        }

        public EnemyCharacter Create(EnemyCharacterID enemyCharacterID, Vector3 spawnPosition)
        {
            var enemyData = _dataService.GetEnemy(enemyCharacterID);
            var prefab = Object.Instantiate(enemyData.PreFab, spawnPosition, Quaternion.identity);

            prefab.TryGetComponent(out EnemyCharacterView characterView);
            if (characterView == null)
                throw new Exception("Prefab has no component found EnemyCharacterView!");

            prefab.TryGetComponent(out NavMeshAgent navMeshAgent);
            if (navMeshAgent == null)
                throw new Exception("Prefab has no component found NavMeshAgent!");

            prefab.TryGetComponent(out UnitBodyPresenter unitBodyComponent);
            if (unitBodyComponent == null)
                throw new Exception("CharacterInstance not contains UnitBodyComponent component");

            var health = new Health(enemyData.HealthPointCount);
            var unitBody = new UnitBody(health, unitBodyComponent);

            var mover = new SimpleEnemyMover(navMeshAgent, enemyData.WalkSpeed);
            var simpleAI = new SimpleEnemyAI(mover);

            var model = new EnemyCharacter(unitBody, mover, simpleAI);
            model.Initialize();

            return model;
        }
    }
}