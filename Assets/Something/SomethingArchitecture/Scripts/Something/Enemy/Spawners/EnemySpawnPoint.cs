using Something.SomethingArchitecture.Scripts.Architecture.Data.ID;
using UnityEngine;

namespace Something.Scripts.Something.EnemyWave
{
    public class EnemySpawnPoint : MonoBehaviour
    {
        [SerializeField] private EnemyCharacterID _id;
        public EnemyCharacterID ID => _id;
    }
}