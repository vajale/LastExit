using System.Collections;
using UnityEngine;

namespace Something.Scripts.Architecture
{
    public class FadePanel : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _image;

        public IEnumerator FadeCoroutine()
        {
            _image.gameObject.SetActive(true);
        
            while (_image.alpha < 1)
            {
                _image.alpha += 0.01f;
                yield return null;
            }
        }
    }
}