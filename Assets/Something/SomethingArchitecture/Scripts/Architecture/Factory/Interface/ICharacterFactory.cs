using Something.SomethingArchitecture.Scripts.Architecture.Data;
using Something.SomethingArchitecture.Scripts.Something.Characters.Base;
using UnityEngine;

namespace Something.SomethingArchitecture.Scripts.Architecture.Factory.Interface
{
    public interface ICharacterFactory
    {
        Character CreatePlayerCharacter(Vector3 position, CharacterData data, out PlayerCharacter playerCharacter);
    }
}