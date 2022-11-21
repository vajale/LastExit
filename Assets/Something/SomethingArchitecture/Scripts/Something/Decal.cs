using System.Collections;
using UnityEngine;

namespace Something.Scripts.Something
{
    public class Decal : MonoBehaviour
    {
        [SerializeField] private float _time;

        private void OnEnable()
        {
            StartCoroutine(DecalDeleter(_time));
        }

        IEnumerator DecalDeleter(float time)
        {
            yield return new WaitForSeconds(time);
            Destroy(gameObject);
        }
    
    }
}