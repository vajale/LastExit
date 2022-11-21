using System.Collections.Generic;
using SomethingArchitecture.Scripts.Architecture.Services;

namespace SomethingArchitecture.Scripts.Dialoge
{
    public class DialogService
    {
        private Dictionary<DialogeCharacterId, DialogeWihCharacter> _dailogs;
        private StaticDataService _dataService;
        private DialogeWihCharacter _current;

        public DialogService(StaticDataService dataService)
        {
            _dataService = dataService;
            _dailogs = _dataService.GetDialogsData();
        }

        private DialogeWihCharacter GetDialoge(DialogeCharacterId dialogeCharacterId) => 
            _dailogs.TryGetValue(dialogeCharacterId, out DialogeWihCharacter dialogeWihCharacterExample) ? dialogeWihCharacterExample : null;

        private void BulidDialogeScene()
        {
            return;
        }

        public bool ShowDialoge(DialogeCharacterId dialogeCharacterId)
        {
            var dialoge = GetDialoge(dialogeCharacterId);
            
            if (dialoge == null)
                return false;
            
            BulidDialogeScene();
            dialoge.ShowText();

            return true;
        }
    }
}