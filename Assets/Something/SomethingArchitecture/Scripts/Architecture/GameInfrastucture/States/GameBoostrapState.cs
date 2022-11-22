using Something.Scripts.Architecture.Services;
using Something.Scripts.Architecture.Services.ServiceLocator;
using Something.Scripts.Architecture.Utilities;
using Something.Scripts.Something.Characters.MoveControllers.States;
using Something.SomethingArchitecture.Scripts.Architecture.GameInfrastucture.States;
using Something.SomethingArchitecture.Scripts.Architecture.Utilities.StateMachine;
using SomethingArchitecture.Scripts.Architecture.Services;

namespace Something.Scripts.Architecture.GameInfrastucture.States
{
    public class GameBoostrapState : IState
    {
        private readonly StateMachine<IState> _stateMachine;
        private readonly bool _isTest;

        public GameBoostrapState(StateMachine<IState> stateMachine, bool isTest)
        {
            _stateMachine = stateMachine;
            _isTest = isTest;
        }

        public void Enter()
        {
            RegisterServices();
            SetGameState();
        }

        private void SetGameState()
        {
            if (_isTest)
            {
                _stateMachine.SetState<GameTestingSceneState>();
                return;
            }

            _stateMachine.SetState<GameMainMenuState>();
        }

        public void Exit()
        {
        }

        private void RegisterServices()
        {
            ServiceLocator.Register<PlayerInputService>(new PlayerInputService());
            ServiceLocator.Register<SceneReferenceService>(new SceneReferenceService());
            ServiceLocator.Register<StaticDataService>(new StaticDataService());
            ServiceLocator.Register<SaveLoadService>(new SaveLoadService());
        }
    }
}