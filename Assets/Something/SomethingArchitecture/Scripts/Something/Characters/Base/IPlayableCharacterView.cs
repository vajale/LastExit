using UnityEngine;

namespace Something.SomethingArchitecture.Scripts.Something.Characters.Base
{
    public interface IPlayableCharacterView
    {
        public Transform transform { get; }
        public PlayerCharacterModel CharacterModel { get; }
    }
}