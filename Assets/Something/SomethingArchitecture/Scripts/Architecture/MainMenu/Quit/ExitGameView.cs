using System;
using Something.Scripts.Architecture.GameInfrastucture.Operations;
using UnityEngine;
using UnityEngine.UI;

namespace Something.Scripts.Architecture.MainMenu.Quit
{
    public class ExitGameView : Window 
    {
        [SerializeField] private Button _exitGameButton;

        private void OnEnable()
        {
            _exitGameButton.onClick.AddListener(OnExitGameClick);
        }

        private void OnDisable()
        {
            _exitGameButton.onClick.RemoveListener(OnExitGameClick);
        }

        private void OnExitGameClick()
        {
            var exitGameOperation = new ExitGameOperation();
        }

        public override void BulidWindow()
        {
            gameObject.SetActive(true);
        }

        public override void CloseWindow()
        {
            gameObject.SetActive(false);
        }
    }
}