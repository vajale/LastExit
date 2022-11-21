using System;
using System.Collections.Generic;
using Something.Scripts.Architecture.GameInfrastucture.States.Interfaces;

namespace Something.Scripts.Architecture.GameInfrastucture
{
    public class GameStateMachine
    {
        private IGameState _currentState;
        private Dictionary<Type, IGameState> _stateMap;

        public void Initialize(Dictionary<Type, IGameState> stateMap)
        {
            _stateMap = stateMap;
        }

        public void SetState<T>() where T : IGameState
        {
            var state = GetState<T>();
            ChangeState(state);
        }

        private void ChangeState(IGameState newState)
        {
            if (_currentState != null)
                _currentState.Exit();

            _currentState = newState;
            _currentState.Enter();
        }

        private IGameState GetState<T>() where T : IGameState
        {
            var type = typeof(T);
            return _stateMap[type];
        }
    }
}