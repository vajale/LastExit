using UnityEngine;

namespace Something.SomethingArchitecture.Scripts.Architecture.Data
{
    public interface ICharacterData
    {
        GameObject PreFab { get; }
        float HealthPointCount { get; }
        float WalkSpeed { get; }
        float RunSpeed { get; }
        float JumpSpeed { get; }
    }
}