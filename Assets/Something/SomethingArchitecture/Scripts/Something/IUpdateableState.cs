using Something.Scripts.Something.Characters.MoveControllers.States;

namespace Something.Scripts.Something
{
    public interface IUpdateableState : IState
    {
        void Update();
    }
}