using System.Collections.Generic;
using Something.Scripts.Architecture.Utilities;
using Something.Scripts.Something.Characters;
using Something.Scripts.Something.EnemyWave;
using Something.SomethingArchitecture.Scripts.Something.Characters.Enemy;
using UnityEngine;

namespace Something.Scripts.Something.Spawners
{
    public class EnemySquadSpawner : MonoBehaviour, ISaveable
    {
        [SerializeField] private EnemySpawnPoint[] spawnPositions;
        private IEnemyFactory _enemyFactory;
        private IPlayableCharacter _target;
        private bool _isEliminated;

        public int InstanceId => GetInstanceID();
        public bool IsEliminated => _isEliminated;

        public void Initialize(IEnemyFactory enemyFactory, IPlayableCharacter playableCharacter = null)
        {
            _target = playableCharacter;
            _enemyFactory = enemyFactory;
        }

        public EnemySquad CreateSquad()
        {
            var enemyArray = new EnemyCharacter[spawnPositions.Length];

            for (var i = 0; i < spawnPositions.Length; i++)
            {
                var point = spawnPositions[i];
                _enemyFactory.Create(point.ID, point.transform.position, out var model);
                enemyArray[i] = model;
            }

            var newSquad = new EnemySquad(enemyArray, ref _target);
            newSquad.Initialize();
            return newSquad;
        }

        private void OnDrawGizmos()
        {
            foreach (var point in spawnPositions)
            {
                var to = point.transform.position;
                Gizmos.DrawLine(transform.position, to);
                Gizmos.color = Color.yellow;
                Gizmos.DrawSphere(to, 0.25f);
            }

            Gizmos.color = Color.green;
            Gizmos.DrawSphere(transform.position, 0.5f);
        }

        public void LoadProgress(IPlayerProgress playerProgress)
        {
            var worldProgress = playerProgress.WorldProgress;
            worldProgress.EliminateProgress.Get(this, out var flag);
            _isEliminated = flag;
        }

        public void UpdateProgress(IPlayerProgress playerProgress)
        {
            var worldProgress = playerProgress.WorldProgress;
            worldProgress.EliminateProgress.Add(this);
        }
    }
}