using Something.Scripts.Something.Spawners;
using UnityEngine;

namespace Something.SomethingArchitecture.Scripts.Something
{
    public class CreateZombieTrigger : GameLoopScript
    {
        [SerializeField] private EnemySquadSpawner _enemySquadSpawner;
        
        protected override void Execute()
        {
            gamePlayService.SpawnEnemy(_enemySquadSpawner);
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("zombie spawner ");
            
            if (CheckIfPlayer(other))
            {
                Execute();
            }
        }
    }

    public class ASFSAF : GameLoopScript
    {
        public GameObject bo4ka;
        
        protected override void Execute()
        {
            Destroy(bo4ka);
        }
        
    }
}