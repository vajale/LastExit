using Something.Scripts.Architecture.Services.ServiceLocator;
using Something.Scripts.Architecture.Utilities;
using Something.Scripts.Something.Characters;
using Something.Scripts.Something.Spawners;
using Something.SomethingArchitecture.Scripts.Architecture;
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
    public interface IGamePlayServiceHelper
    {
        public void SpawnEnemy(EnemySquadSpawner squadSpawner);
        public void GiveWeapon(WeaponTypeId id, IPlayableCharacter character);
    }
    
    public class GameplayService : IService, IGamePlayServiceHelper
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

        public PlayerCharacterView CreatePlayerCharacter(out PlayerCharacterModel playerCharacterModel,
            Vector3 spawnPosition)
        {
            var characterPlayerData = _dataService.GetPlayerData();
            var characterView =
                _characterFactory.CreatePlayerCharacter(spawnPosition, characterPlayerData, out var model);

            playerCharacterModel = model;
            _playerCharacterModel = model;

            var weaponInventory = new WeaponInventory(_weaponFactory, characterView.WeaponTransform, 4);
            _playerCharacterModel.SetWeaponInteract(weaponInventory);

            return characterView;
        }

        public void SpawnEnemy(EnemySquadSpawner squadSpawner)
        {
            squadSpawner.Initialize(_enemyFactory);
            squadSpawner.CreateSquad();
        }

        public void SpawnAllEnemy()
        {
            if (_spawnersIsInitialized == false)
            {
                InitializeEnemySpawners();
                _spawnersIsInitialized = true;
            }

            foreach (var spawner in _sceneReferenceService.GetSpawners())
            {
                spawner.CreateSquad();
            }
        }

        public void GiveWeapon(WeaponTypeId id, IPlayableCharacter character)
        {
            var weaponInventory = character.WeaponInventory;
            weaponInventory.AddWeapon(id);
        }

        private void InitializeEnemySpawners(IPlayableCharacter playableCharacter = null)
        {
            var enemySpawners = _sceneReferenceService.GetSpawners();

            foreach (var spawner in enemySpawners)
            {
                spawner.GetComponent<EnemySquadSpawner>().Initialize(_enemyFactory);
            }
        }
    }
    
}