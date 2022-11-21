using UnityEngine;

namespace SomethingArchitecture.Scripts.Dialoge
{
    [CreateAssetMenu(menuName = "Create DialogeUnit", fileName = "DialogeUnit", order = 0)]
    public class DialogeUnit : ScriptableObject, IDialogeUnit
    {
        [SerializeField] private string text;
        [SerializeField] private DialogeType dialogeType;

        public string Text => text;
        public DialogeType DialogeType => dialogeType;
    }
}