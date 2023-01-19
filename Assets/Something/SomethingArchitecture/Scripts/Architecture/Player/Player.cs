using System;
using Something.Scripts.Architecture.Services;
using Something.Scripts.Architecture.Utilities;
using Something.Scripts.Something;
using Something.Scripts.Something.Characters;
using Something.SomethingArchitecture.Scripts.Something.Camera;
using Vector2 = System.Numerics.Vector2;

namespace Something.SomethingArchitecture.Scripts.Architecture
{
    public class Player : ISaveable
    {
        private class InputContext : IInputContext
        {
            internal InputContext(ref IInputService inputService)
            {
                _inputService = inputService;
            }

            private readonly IInputService _inputService;

            public Vector2 Axis =>
                new Vector2(_inputService.Axis.X, _inputService.Axis.Y);

            public bool Interact => _inputService.InteractButton;
            public bool WeaponInteractInvoke => _inputService.RightMouseButton;
            public bool WeaponInteractInvoke2 => _inputService.LeftMouseButton;
            public bool WeaponReloadInteract => _inputService.ReloadButton;
            public float MouseScrollWheel => _inputService.MouseScrollWheel;
            public bool JumpButton => _inputService.JumpButton;
        }

        private IInputContext _contextCurrent;
        private IControllablePlayableCharacter _controllablePlayableCharacter;

        public IPlayableCharacter CurrentPlayableCharacter { get; private set; }

        public Player(IInputService inputService)
        {
            _contextCurrent = new InputContext(ref inputService);
        }

        public void SetCharacter(IControllablePlayableCharacter controllablePlayableCharacter)
        {
            if (_controllablePlayableCharacter != null)
                _controllablePlayableCharacter.RemoveInputContext();

            _controllablePlayableCharacter = controllablePlayableCharacter;

            CurrentPlayableCharacter = _controllablePlayableCharacter;
            SetOnCharacterContext();
        }

        public void SetInputContext(InputContextType inputContextType)
        {
            SetOnCharacterContext();
        }

        private void SetOnCharacterContext()
        {
            if (_controllablePlayableCharacter == null)
                throw new Exception("PLayer ControllableCharacter is null");

            _controllablePlayableCharacter.SetInputContext(ref _contextCurrent);
        }

        #region LoadSave

        public void LoadProgress(IPlayerProgress playerProgress)
        {
            _controllablePlayableCharacter.MoveController.Transform.position = playerProgress.PlayerPosition;
            _controllablePlayableCharacter.Health.SetCount(playerProgress);
        }

        public void UpdateProgress(IPlayerProgress playerProgress)
        {
            playerProgress = new PlayerProgress();
        }

        #endregion
    }

    public enum InputContextType
    {
        PlayerCharacter = 1,
        Menu = 2,
        Pause = 3,
        EndSession = 4,
    }
}