using System.Collections.Generic;
using UnityEngine;

namespace SomethingArchitecture.Scripts.Dialoge
{
    [CreateAssetMenu(menuName = "Create DialogeWihCharacterExample", fileName = "DialogeWihCharacterExample", order = 0)]
    public class DialogeWihCharacter : ScriptableObject
    {
        [SerializeField] private List<DialogeUnit> _dialogs;
        [SerializeField] private DialogeCharacterId _characterId;

        public DialogeCharacterId characterId => _characterId;

        public void ShowText()
        {
            
        }
    }
}