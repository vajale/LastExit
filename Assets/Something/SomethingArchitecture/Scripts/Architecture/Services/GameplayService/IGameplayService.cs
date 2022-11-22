using Something.Scripts.Something.Characters;
using Something.SomethingArchitecture.Scripts.Something.Characters.Base;
using Something.SomethingArchitecture.Scripts.Something.Weapon.Factory;
using UnityEngine;

namespace Something.Scripts.Architecture.GameInfrastucture
{
    public interface IGameplayService
    {
        PlayerCharacterModel GetCurrentCharacter();
        PlayerCharacterView CreatePlayerCharacter(out PlayerCharacterModel playerCharacterModel, Vector3 spawnPosition);
        void UpdateReferences();
        void GiveWeapon(WeaponTypeId id);
        void SpawnEnemy();
        void CreateEnemyWave();
        void CreateEnemyWaveByDestination();
    }
}