using System;
using System.Collections.Generic;
using Something.Scripts.Architecture.Services;
using Something.Scripts.Something;
using Something.Scripts.Something.Characters.MoveControllers.States;
using Something.SomethingArchitecture.Scripts.Architecture.Utilities.StateMachine;
using Something.SomethingArchitecture.Scripts.Something.Characters.Base;
using UnityEngine;

namespace Something.SomethingArchitecture.Scripts.Something.Camera
{
    public class MainCamera : MonoBehaviour
    {
        private StateMachine<IUpdatableState> _stateMachine;
        private Dictionary<Type, IUpdatableState> _stateMap;

        private CameraConfig _config;
        private Transform _characterCameraTransform;
        private IInputService _inputService;
        private bool _statesInitialized;

        public IStateMachine<IUpdatableState> StateMachine => _stateMachine;

        public void Initalize(PlayerCharacterView playerCharacterView)
        {
            _stateMachine = new StateMachine<IUpdatableState>();

            _stateMap = new Dictionary<Type, IUpdatableState>
            {
                [typeof(CameraPlayerState)] = new CameraPlayerState(playerCharacterView, this.transform, _config)
            };

            _stateMachine.Initialize(_stateMap);
            _statesInitialized = true;

            _stateMachine.SetState<CameraPlayerState>();
        }

        private void Update()
        {
            if (_statesInitialized)
            {
                _stateMachine.CurrentState.Update();
            }
        }
    }
}