using System.Collections;
using System.Collections.Generic;
using Something.Scripts.Something.Spawners;

namespace Something.Scripts.Architecture.Utilities
{
    public class EliminateProgress : ISaveableProgress<EnemySquadSpawner, bool>
    {
        private readonly Dictionary<int, EnemySquadSpawner> _enemySpawners;

        public EliminateProgress()
        {
            _enemySpawners = new Dictionary<int, EnemySquadSpawner>();
        }

        public void Add(EnemySquadSpawner enemySquadSpawner)
        {
            var id = enemySquadSpawner.InstanceId;

            if (!_enemySpawners.ContainsKey(id))
                _enemySpawners.Add(id, enemySquadSpawner);
        }

        public void Get(EnemySquadSpawner enemySquadSpawner, out bool flag)
        {
            var id = enemySquadSpawner.InstanceId;

            if (_enemySpawners.TryGetValue(id, out enemySquadSpawner))
                flag = enemySquadSpawner.IsEliminated;

            flag = false;
        }

        public IEnumerable<ISaveable> GetAll()
        {
            var array = new List<ISaveable>();

            foreach (var spawners in _enemySpawners.Values)
            {
                array.Add(spawners);
            }

            return array.ToArray();
        }
    }
}