using System;
using System.Collections;
using Something.Scripts.Architecture;
using Something.Scripts.Architecture.MainMenu.Quit;
using Something.Scripts.Architecture.MainMenu.Settings;
using UnityEngine;
using UnityEngine.UI;

namespace Something.SomethingArchitecture.Scripts.Architecture.MainMenu
{
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _exitButton;
        [SerializeField] private Button _settingButton;
        [SerializeField] private FadePanel _fidePanel;
        [SerializeField] private ExitGameView _exitGameView;
        [SerializeField] private SettingView _settingView;

        public event Action GameLoading;

        public void Initialize()
        {
            _settingView.Initialize(new GameConfig());

            _playButton.onClick.AddListener(OnPlayButtonClick);
            _settingButton.onClick.AddListener(OnSettingButtonClick);
            _exitButton.onClick.AddListener(OnExitButtonClick);
        }

        public void Uninitialize()
        {
            _settingView.Uninitialize();

            _playButton.onClick.RemoveListener(OnPlayButtonClick);
            _settingButton.onClick.RemoveListener(OnSettingButtonClick);
            _exitButton.onClick.RemoveListener(OnExitButtonClick);
        }

        private void OnPlayButtonClick()
        {
            GameLoading?.Invoke();
        }

        private void OnSettingButtonClick()
        {
            _settingView.BulidWindow();
        }

        private void OnExitButtonClick()
        {
            _exitGameView.BulidWindow();
        }

        public IEnumerator FadeIn()
        {
            yield return _fidePanel.FadeCoroutine();
        }
    }
}