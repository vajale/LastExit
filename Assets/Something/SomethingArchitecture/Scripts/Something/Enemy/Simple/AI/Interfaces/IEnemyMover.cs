using UnityEngine;

namespace Something.Scripts.Something.AI
{
    public interface IEnemyMover
    {
        Transform transform { get; }
        void Move(Vector3 to);
        void StandBy(Vector3 to);
        void Stand(Vector3 to);
        void StopMoving();
        void Rotate();
    }
}