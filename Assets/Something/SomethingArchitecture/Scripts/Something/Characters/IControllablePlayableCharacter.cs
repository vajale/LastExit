using Something.Scripts.Architecture.Services;
using Something.Scripts.Something.Characters.MoveControllers;

namespace Something.Scripts.Something.Characters
{
    public interface IControllablePlayableCharacter : IPlayableCharacter
    {
        void RemoveInputContext();
        void SetInputContext(ref IInputContext contextCurrent);
    }
    
}