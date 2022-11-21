using UnityEngine;
using UnityEngine.UI;

namespace Something.Scripts.Architecture.MainMenu
{
    public abstract class Window : MonoBehaviour, IWindow
    {
        [SerializeField] protected Button closeButton;
        
        private void Awake()
        {
            closeButton.onClick.AddListener(CloseWindow);
        }
        
        public abstract void BulidWindow();
        public abstract void CloseWindow();
    }
}