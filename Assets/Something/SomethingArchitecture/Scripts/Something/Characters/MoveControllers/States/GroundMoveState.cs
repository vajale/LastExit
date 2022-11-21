using Something.SomethingArchitecture.Scripts.Architecture.Data;
using Something.SomethingArchitecture.Scripts.Architecture.Utilities.StateMachine;
using Something.SomethingArchitecture.Scripts.Something.Characters.MoveControllers;
using UnityEngine;

namespace Something.Scripts.Something.Characters.MoveControllers.States
{
    public class GroundMoveState : IInputState
    {
        private readonly StateMachine<IInputState> _stateMachine;
        private readonly CharacterData _characterData;
        private readonly StandartMoveController _standartMoveController;
        private float _currentSpeed;

        public GroundMoveState(StateMachine<IInputState> stateMachine, CharacterData characterData, StandartMoveController standartMoveController)
        {
            _stateMachine = stateMachine;
            _characterData = characterData;
            _standartMoveController = standartMoveController;
        }


        public void Enter()
        {
        }

        public void Exit()
        {
        }

        public void Update()
        {
            throw new System.NotImplementedException();
        }

        public void Update(IInputContext inputContext)
        {
            var xAxis = inputContext.Axis.X;
            var yAxis = inputContext.Axis.Y;
            _standartMoveController.SetMoveVector(GetMoving(xAxis, yAxis));
        }

        private Vector3 CalculatedDirection(float xAxis, float yAxis)
        {
            Vector3 verticalDirection = Vector3.forward * xAxis;
            Vector3 horizontalDirection = Vector3.right * yAxis;

            var desiredDir = verticalDirection + horizontalDirection;
            return desiredDir;
        }

        private float CalculateSpeed()
        {
            _currentSpeed = _characterData.WalkSpeed;
            return _currentSpeed;
        }

        private Vector3 GetMoving(float xAxis, float yAxis)
        {
            var finalMoveVector = CalculatedDirection(xAxis, yAxis) * CalculateSpeed() + ApplyGravity();
            return finalMoveVector;
        }

        private Vector3 ApplyGravity()
        {
            var gravityVector = Vector3.down * 9.8f;
            gravityVector *= _characterData.GravityMultiplier;

            return gravityVector;
        }
    }
}