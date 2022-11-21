using UnityEngine;

namespace Something.Scripts.Something.Characters.MoveControllers.States
{
    public interface IState
    {
        void Enter();

        void Exit();
    }

    public interface IUpdatableState : IState
    {
        void Update();
    }

    public interface IInputState : IUpdatableState
    {
        void Update(IInputContext inputContext);
    }
}