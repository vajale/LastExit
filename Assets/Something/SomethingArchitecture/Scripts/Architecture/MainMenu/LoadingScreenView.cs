using System;
using Something.Scripts.Architecture.Utilities;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Something.Scripts.Architecture
{
    public class LoadingScreenView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _loadingText;
        [SerializeField] private Slider _loadSlider;

        private float _progress;
        private Action OnProgressChanged;

        public void SetLoadingText(string text)
        {
            _loadingText.text = text;
        }

        public void SetProgress(float value)
        {
            if(value == 0) return;

            _progress = value;
            _loadSlider.value = value;
        }
        
        public void Initialize(IProgressProvider sceneLoaderLoadingProgress)
        {
            _progress = sceneLoaderLoadingProgress.LoadingProgress;
        }
    }
}