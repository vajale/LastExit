using Something.Scripts.Architecture.Services;
using Something.Scripts.Architecture.Services.ServiceLocator;
using Something.Scripts.Architecture.Utilities;
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
            
            var inputService = ServiceLocator.GetService<PlayerInputService>();
            
            var playerSession = new Player(inputService);
    
            
            CreatePlayerGUI(ref playerSession);
            
            Cursor.lockState = CursorLockMode.Locked;
        }

        private PlayerUIView CreatePlayerGUI(ref Player playerSession)
        {
            var guiView = _dataService.GetPlayerGUI();
            return _playerUIFactory.CreateBaseUI(ref playerSession, guiView.gameObject);
        }
    }
}