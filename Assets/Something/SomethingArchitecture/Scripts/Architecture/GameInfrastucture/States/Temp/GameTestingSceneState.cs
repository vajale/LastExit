using Something.Scripts.Architecture.Services;
using Something.Scripts.Architecture.Services.ServiceLocator;
using Something.Scripts.Architecture.Utilities;
using Something.Scripts.Something;
using Something.Scripts.Something.Characters.MoveControllers.States;
using Something.SomethingArchitecture.Scripts.Architecture;
using Something.SomethingArchitecture.Scripts.Architecture.Factory.Interface;
using Something.SomethingArchitecture.Scripts.Something.Characters.Base;
using Something.SomethingArchitecture.Scripts.Something.Weapon.Factory;
using SomethingArchitecture.Scripts.Architecture.Services;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Something.Scripts.Architecture.GameInfrastucture
{
    public class GameTestingSceneState : IState
    {
        private readonly SceneLoader _sceneLoader;

        private IGameplayService _gameplayService;
        private StaticDataService _dataService;
        private PlayerUIFactory _playerUIFactory;
        private SceneReferenceService _sceneReferenceService;

        public GameTestingSceneState(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            InitFactory();
            _sceneLoader.Load(ScenesIndex.TestScene, LoadSceneMode.Additive, CreateGameWorld);
        }
        
        public void Exit()
        {
        }

        private void InitFactory()
        {
            _dataService = ServiceLocator.GetService<StaticDataService>();
            _playerUIFactory = new PlayerUIFactory();
            _sceneReferenceService = new SceneReferenceService();
            _gameplayService = new GameplayService(_dataService);
        }
        
        private void CreateGameWorld()
        {
            _sceneReferenceService.Initialize();
            _gameplayService.UpdateReferences();
            
            var inputService = ServiceLocator.GetService<PlayerInputService>();
            var playerSession = new Player(inputService);

            var character = CreateCharacter(out var playerCharacter);

            playerSession.SetCharacter(playerCharacter);
            playerSession.SetInputContext(InputContextType.PlayerCharacter);

            InitializeCamera(character);

            _gameplayService.CreateEnemyWave();
            
            _gameplayService.GiveWeapon(WeaponTypeId.Rifle);

            Cursor.lockState = CursorLockMode.Locked;
        }

        private void InitializeCamera(PlayerCharacterView playerCharacterView)
        {
            var mainCamera = _sceneReferenceService.GetMainCamera();
            mainCamera.Initalize(playerCharacterView);
            mainCamera.StateMachine.SetState<CameraPlayerState>();
        }

        private PlayerCharacterView CreateCharacter(out PlayerCharacterModel playerCharacterModel)
        {
            var spawmPos = _sceneReferenceService.GetPlayerSpawnPosition();
            var character = _gameplayService.CreatePlayerCharacter(out playerCharacterModel, spawmPos);
            return character;
        }


        private PlayerUIView CreatePlayerGUI(ref Player playerSession)
        {
            var guiView = _dataService.GetPlayerGUI();
            return _playerUIFactory.CreateBaseUI(ref playerSession, guiView.gameObject);
        }
    }
}