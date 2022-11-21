using System;
using System.Collections.Generic;
using Something.Scripts.Architecture.GameInfrastucture.States;
using Something.Scripts.Architecture.Utilities;
using Something.Scripts.Something.Characters.MoveControllers.States;
using Something.SomethingArchitecture.Scripts.Architecture.GameInfrastucture.States;
using Something.SomethingArchitecture.Scripts.Architecture.Utilities.StateMachine;

namespace Something.Scripts.Architecture.GameInfrastucture
{
    public class Game
    {
        public StateMachine<IState> StateMachine { get; private set; }
        private readonly SceneLoader _sceneLoader;
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly bool _isTest;

        private Dictionary<Type, IState> _stateMap;

        public Game(ICoroutineRunner coroutineRunner, bool isTest)
        {
            _coroutineRunner = coroutineRunner;
            _isTest = isTest;
            _sceneLoader = new SceneLoader(coroutineRunner);

            InitGameState(isTest);
        }

        private void InitGameState(bool isTest)
        {
            if (isTest)
            {
                InitializeTestingGame();
            }
            else
            {
                InitializeGameStateMachine();
            }

            StateMachine.SetState<GameBoostrapState>();
        }

        private void InitializeGameStateMachine()
        {
            StateMachine = new StateMachine<IState>();

            _stateMap = new Dictionary<Type, IState>
            {
                [typeof(GameBoostrapState)] = new GameBoostrapState(StateMachine, _isTest),
                [typeof(GameMainMenuState)] = new GameMainMenuState(StateMachine, _coroutineRunner, _sceneLoader),
                [typeof(GameLoadingState)] = new GameLoadingState(StateMachine, _coroutineRunner, _sceneLoader),
                [typeof(GameLoopState)] = new GameLoopState(StateMachine, _sceneLoader),
            };

            StateMachine.Initialize(_stateMap);
        }

        private void InitializeTestingGame()
        {
            StateMachine = new StateMachine<IState>();

            _stateMap = new Dictionary<Type, IState>
            {
                [typeof(GameBoostrapState)] = new GameBoostrapState(StateMachine, _isTest),
                [typeof(GameTestingSceneState)] = new GameTestingSceneState(_sceneLoader),
            };

            StateMachine.Initialize(_stateMap);
        }
    }
}