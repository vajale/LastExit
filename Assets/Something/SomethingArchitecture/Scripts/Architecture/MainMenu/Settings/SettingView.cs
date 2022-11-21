using UnityEngine;
using UnityEngine.UI;

namespace Something.Scripts.Architecture.MainMenu.Settings
{
    public class SettingView : Window, IWindow
    {
        [SerializeField] private Button _applyButton;
        [SerializeField] private Button _setToDefaultButton;

        private SettingTable _settingTable;
        private GameConfig _gameConfig;

        private GameConfig _templateGameConfig;

        public void Initialize(GameConfig gameConfig)
        {
            _gameConfig = gameConfig;
            _settingTable = new SettingTable(gameConfig);

            _setToDefaultButton.onClick.AddListener(OnInvokeDefaultSetting);
            _applyButton.onClick.AddListener(OnApplySetting);
            closeButton.onClick.AddListener(CloseWindow);
        }

        public void Uninitialize()
        {
            _setToDefaultButton.onClick.RemoveListener(OnInvokeDefaultSetting);
            _applyButton.onClick.RemoveListener(OnApplySetting);
            closeButton.onClick.RemoveListener(CloseWindow);
        }

        public override void BulidWindow()
        {
            gameObject.SetActive(true);
            _settingTable.BulidContexTable();
        }

        public override void CloseWindow()
        {
            gameObject.SetActive(false);
        }

        private void OnInvokeDefaultSetting()
        {
            _gameConfig = _gameConfig.GetToDefault();
        }

        private void OnApplySetting()
        {
            _settingTable.ApplySettings();
            _gameConfig.SetNewStats(_templateGameConfig);
        }
    }
}