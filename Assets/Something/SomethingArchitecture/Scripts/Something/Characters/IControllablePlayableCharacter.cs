using Something.Scripts.Architecture.Services;
using Something.Scripts.Something.Characters.MoveControllers;

namespace Something.Scripts.Something.Characters
{
    public interface IControllablePlayableCharacter : IPlayableCharacter
    {
        IPlayerMoveController MoveController { get; set; }
        void RemoveInputContext();
        void SetInputContext(ref IInputContext contextCurrent);
    }
    
}