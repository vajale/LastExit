using System;
using Something.Scripts.Architecture.Services.ServiceLocator;
using Something.Scripts.Architecture.Utilities;
using Something.Scripts.Something.Characters;
using Something.Scripts.Something.Spawners;
using Something.SomethingArchitecture.Scripts.Architecture.Factory;
using Something.SomethingArchitecture.Scripts.Architecture.Factory.Interface;
using Something.SomethingArchitecture.Scripts.Something.Camera;
using Something.SomethingArchitecture.Scripts.Something.Characters.Base;
using Something.SomethingArchitecture.Scripts.Something.Characters.Enemy;
using Something.SomethingArchitecture.Scripts.Something.Weapon.Factory;
using SomethingArchitecture.Scripts.Architecture.Factory;
using SomethingArchitecture.Scripts.Architecture.Services;
using UnityEngine;

namespace Something.Scripts.Architecture.GameInfrastucture
{
    public class GameplayService : IGameplayService, IService
    {
        private readonly StaticDataService _dataService;
        private readonly SceneReferenceService _sceneReferenceService;

        private readonly IEnemyFactory _enemyFactory;
        private readonly IWeaponFactory _weaponFactory;
        private readonly ICharacterFactory _characterFactory;
        private readonly PlayerUIFactory _playerUIFactory;
        private readonly SaveLoadService _saveLoadService;

        private PlayerCharacterModel _playerCharacterModel;
        private MainCamera _mainCamera;

        private bool _spawnersIsInitialized;
        private bool _cameraIsInitialized;


        public GameplayService(StaticDataService staticDataService)
        {
            _dataService = staticDataService;
            _enemyFactory = new EnemyFactory(staticDataService);
            _weaponFactory = new WeaponFactory(staticDataService);
            _characterFactory = new CharacterFactory();
            _sceneReferenceService = ServiceLocator.GetService<SceneReferenceService>();
        }

        public void UpdateReferences()
        {
            ServiceLocator.GetService<SceneReferenceService>().Initialize();
        }

        public PlayerCharacterModel GetCurrentCharacter()
        {
            if (_playerCharacterModel != null)
            {
                throw new Exception("CurrentCharacter not is instatiated");
            }

            return _playerCharacterModel;
        }


        public PlayerCharacterView CreatePlayerCharacter(out PlayerCharacterModel playerCharacterModel, Vector3 spawnPosition)
        {
            var characterPlayerData = _dataService.GetPlayerData();
            var characterView =
                _characterFactory.CreatePlayerCharacter(spawnPosition, characterPlayerData, out var model);

            playerCharacterModel = model;
            _playerCharacterModel = model;

            var weaponInventory = new WeaponInventory(_weaponFactory, characterView.WeaponTransform, 2);
            _playerCharacterModel.SetWeaponInteract(weaponInventory);

            return characterView;
        }

        public void SpawnEnemy()
        {
        }

        public void CreateEnemyWave()
        {
            if (_playerCharacterModel == null)
                throw new Exception("Игровой персонаж не создан");

            if (_spawnersIsInitialized == false)
            {
                InitializeEnemySpawners(_playerCharacterModel);
                _spawnersIsInitialized = true;
            }

            foreach (var spawner in _sceneReferenceService.GetSpawners())
            {
                spawner.CreateSquad();
            }
        }

        public void CreateEnemyWaveByDestination()
        {
        }

        public void GiveWeapon(WeaponTypeId id)
        {
            if (_playerCharacterModel == null)
                throw new Exception("Игровой персонаж не создан");

            var weaponInventory = _playerCharacterModel.WeaponInventory;
            weaponInventory.AddWeapon(id);
        }

        private void InitializeEnemySpawners(IPlayableCharacter playableCharacter)
        {
            var enemySpawners = _sceneReferenceService.GetSpawners();
            Debug.Log(enemySpawners);

            foreach (var spawner in enemySpawners)
            {
                spawner.GetComponent<EnemySquadSpawner>().Initialize(_enemyFactory, ref playableCharacter);
            }
        }
    }
}