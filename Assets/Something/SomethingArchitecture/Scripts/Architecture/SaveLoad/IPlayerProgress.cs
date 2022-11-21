using Something.Scripts.Something.Characters;
using UnityEngine;

namespace Something.Scripts.Architecture.Utilities
{
    public interface IPlayerProgress
    {
        Vector3 PlayerPosition { get; }
        Health HeathProgress { get; }
        WorldDataProgress WorldProgress { get; }
    }
}