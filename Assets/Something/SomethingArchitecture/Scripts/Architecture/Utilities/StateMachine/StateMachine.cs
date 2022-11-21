using System;
using System.Collections.Generic;
using Something.Scripts.Something.Characters.MoveControllers.States;
using UnityEngine;

namespace Something.SomethingArchitecture.Scripts.Architecture.Utilities.StateMachine
{
    public class StateMachine<T> : IStateMachine<T> where T : IState
    {
        private T _currentState;
        private Dictionary<Type, T> _stateMap;
        public T CurrentState => _currentState;

        private void ChangeState(T newState)
        {
            if (_currentState != null)
                _currentState.Exit();

            _currentState = newState;
            _currentState.Enter();
        }

        private T GetState<TState>() where TState : T
        {
            var type = typeof(TState);
            return _stateMap[type];
        }

        public void SetState<TState>() where TState : T
        {
            var state = GetState<TState>();
            ChangeState(state);
        }

        public void Initialize(Dictionary<Type, T> stateMap)
        {
            _stateMap = stateMap;
        }
    }

    public interface IStateMachine<T>
    {
        void SetState<TState>() where TState : T;
    }
}