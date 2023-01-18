using System;
using System.Collections.Generic;
using Something.Scripts.Architecture;
using Something.Scripts.Architecture.GameInfrastucture;
using Something.Scripts.Architecture.GameInfrastucture.States.GameLoopStates;
using Something.Scripts.Architecture.GameInfrastucture.States.Interfaces;
using Something.Scripts.Architecture.Services;
using Something.Scripts.Architecture.Services.ServiceLocator;
using Something.Scripts.Architecture.Utilities;
using Something.Scripts.Something;
using Something.SomethingArchitecture.Scripts.Architecture.Utilities.StateMachine;
using Something.SomethingArchitecture.Scripts.Something.Weapon.Factory;
using Unity.VisualScripting;
using UnityEngine;
using IState = Something.Scripts.Something.Characters.MoveControllers.States.IState;

namespace Something.SomethingArchitecture.Scripts.Architecture.GameInfrastucture.States
{
    public class GameLoopState : IState
    {
        private readonly StateMachine<IState> _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly GameStateMachine _gameLoopStateMachine;

        private Dictionary<Type, IGameState> _stateMap;
        private GameplayService _gameplay;
        private SceneReferenceService _sceneReference;
        private Player _playerSession;
        private SaveLoadService _saveLoadService;

        private GameSceneryLoop _gameScenery;

        public GameLoopState(StateMachine<IState> gameStateMachine, SceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _gameLoopStateMachine = new GameStateMachine();

            InitializeStateMachine();
        }

        private void InitializeGameplayState()
        {
            _gameplay = ServiceLocator.GetService<GameplayService>();
            _sceneReference = ServiceLocator.GetService<SceneReferenceService>();
            _saveLoadService = ServiceLocator.GetService<SaveLoadService>();
        }

        public void Enter()
        {
            InitializeGameplayState();

            Cursor.lockState = CursorLockMode.Locked;
            _gameLoopStateMachine.SetState<GameLoopQuietState>();

            CreatePlayerSession();

            var spawmPos = _sceneReference.GetPlayerSpawnPosition();
            var character = _gameplay.CreatePlayerCharacter(out var playerCharacter, spawmPos);
            var mainCamera = _sceneReference.GetMainCamera();
            

            _playerSession.SetCharacter(playerCharacter);
            _playerSession.SetInputContext(InputContextType.PlayerCharacter);

            mainCamera.Initalize(character);
            mainCamera.StateMachine.SetState<CameraPlayerState>();

            _gameplay.GiveWeapon(WeaponTypeId.Pistol, playerCharacter);
            _gameplay.GiveWeapon(WeaponTypeId.Rifle, playerCharacter);

            var playerProgress = new PlayerProgress();

            _saveLoadService.SetProgress(ref playerProgress);
            _saveLoadService.LoadProgress();
        }

        private void CreatePlayerSession()
        {
            var inputService = ServiceLocator.GetService<PlayerInputService>();
            var playerSession = new Player(inputService);

            _playerSession = playerSession;
        }

        public void Exit()
        {
        }

        private void InitializeStateMachine()
        {
            _stateMap = new Dictionary<Type, IGameState>
            {
                [typeof(GameLoopQuietState)] = new GameLoopQuietState(),
                [typeof(GameLoopActionState)] = new GameLoopActionState(),
                [typeof(GameLoopInZoneState)] = new GameLoopInZoneState(),
            };

            _gameLoopStateMachine.Initialize(_stateMap);
        }
    }
}