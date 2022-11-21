using Something.Scripts.Architecture.Services;
using UnityEngine;

namespace Something.Scripts.Something.Characters.MoveControllers
{
    public interface IMoveController
    {
        void Move();
        Vector3 Position { get; }
    }

    public interface IPlayerMoveController
    {
        void Move(ref IInputContext inputContext);
        Transform Transform { get; }
    }
}