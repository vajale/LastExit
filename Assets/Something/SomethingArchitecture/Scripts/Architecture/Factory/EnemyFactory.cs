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
            out EnemyCharacter enemyCharacterModel)
        {
            var enemyData = _dataService.GetEnemy(enemyCharacterID);
            var prefab = Object.Instantiate(enemyData.PreFab, spawnPosition, Quaternion.identity);

            prefab.TryGetComponent(out EnemyCharacterView characterView);
            if (characterView == null)
                throw new Exception("Prefab has no component found EnemyCharacterView!");

            prefab.TryGetComponent(out NavMeshAgent navMeshAgent);
            if (navMeshAgent == null)
                throw new Exception("Prefab has no component found NavMeshAgent!");

            prefab.TryGetComponent(out EnemyUnitBodyPresenter unitBodyComponent);
            if (unitBodyComponent == null)
                throw new Exception("CharacterInstance not contains UnitBodyComponent component");
            
            prefab.TryGetComponent(out EnemyAnimator animator);
            if (unitBodyComponent == null)
                throw new Exception("CharacterInstance not contains UnitBodyComponent component");

            var health = new Health(enemyData.HealthPointCount);
            var unitBody = new UnitBody(health, unitBodyComponent);

            var mover = new SimpleEnemyMover(navMeshAgent, enemyData.WalkSpeed);
            var simpleAI = new SimpleEnemyAI(mover);

            enemyCharacterModel = new EnemyCharacter(unitBody, mover, simpleAI, animator);
            characterView.InitializeModel(enemyCharacterModel);

            return characterView;
        }
    }
}