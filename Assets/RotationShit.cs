using UnityEngine;

public class RotationShit : MonoBehaviour
{
    [SerializeField] private Transform other;

    private void Update()
    {
        other.rotation = transform.rotation;
    }
}