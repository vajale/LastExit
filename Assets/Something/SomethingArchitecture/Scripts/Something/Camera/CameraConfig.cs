using UnityEngine;

namespace Something.Scripts.Something
{
    [CreateAssetMenu(menuName = "Create CameraMouseConfig", fileName = "CameraMouseConfig", order = 0)]

    public class CameraConfig : ScriptableObject
    {
        [SerializeField] private float sensivity;

        public float Sensivity => sensivity;
    }
}