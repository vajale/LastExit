using Something.Scripts.Something.Characters;
using Something.SomethingArchitecture.Scripts.Architecture.Data.ID;
using UnityEngine;

namespace Something.SomethingArchitecture.Scripts.Something.Characters.Enemy
{
    public interface IEnemyFactory
    {
        EnemyCharacterView Create(EnemyCharacterID enemyCharacterID, Vector3 spawnPosition, out EnemyCharacter enemyCharacterModel);
    }
}