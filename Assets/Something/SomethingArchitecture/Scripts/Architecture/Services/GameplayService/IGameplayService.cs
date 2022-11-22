using Something.Scripts.Something.Characters;
using Something.SomethingArchitecture.Scripts.Something.Characters.Base;
using Something.SomethingArchitecture.Scripts.Something.Weapon.Factory;
using UnityEngine;

namespace Something.Scripts.Architecture.GameInfrastucture
{
    public interface IGameplayService
    {
        PlayerCharacter GetCurrentCharacter();
        Character CreatePlayerCharacter(out PlayerCharacter playerCharacter, Vector3 spawnPosition);
        void UpdateReferences();
        void GiveWeapon(WeaponTypeId id);
        void SpawnEnemy();
        void CreateEnemyWave();
        void CreateEnemyWaveByDestination();
    }
}