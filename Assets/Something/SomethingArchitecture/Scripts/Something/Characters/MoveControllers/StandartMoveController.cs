using System;
using System.Collections.Generic;
using Something.Scripts.Something;
using Something.Scripts.Something.Characters.MoveControllers;
using Something.Scripts.Something.Characters.MoveControllers.States;
using Something.SomethingArchitecture.Scripts.Architecture.Data;
using Something.SomethingArchitecture.Scripts.Architecture.Utilities.StateMachine;
using UnityEngine;

namespace Something.SomethingArchitecture.Scripts.Something.Characters.MoveControllers
{
    public class StandartMoveController : IPlayerMoveController
    {
        public StandartMoveController(CharacterData characterData, CharacterController characterController)
        {
            _characterController = characterController;
            _data = characterData;
            InitializeStateMachine();
        }

        private readonly CharacterController _characterController;
        private readonly CharacterData _data;
        private StateMachine<IInputState> _movementSm;
        private Dictionary<Type, IInputState> _stateMap;
        private Vector3 _finalMovement;
        private CharacterData Data => _data;
        public Transform Transform => _characterController.transform;


        public void Move(ref IInputContext inputContext)
        {
            _movementSm.CurrentState.Update(inputContext);
            var moveVector = TransformWorldVectorToLocal(_finalMovement);
            _characterController.Move(moveVector * Time.deltaTime);
        }
        
        public void SetMoveVector(Vector3 vector)
        {
            _finalMovement = vector;
        }

        private void InitializeStateMachine()
        {
            _movementSm = new StateMachine<IInputState>();

            _stateMap = new Dictionary<Type, IInputState>
            {
                [typeof(GroundMoveState)] = new GroundMoveState(_movementSm, Data, this),
            };

            _movementSm.Initialize(_stateMap);
            _movementSm.SetState<GroundMoveState>();
        }

        private Vector3 TransformWorldVectorToLocal(Vector3 vector) =>
            _characterController.transform.TransformDirection(vector);
    }
}