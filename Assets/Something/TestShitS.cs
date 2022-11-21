using System;
using UnityEngine;

public class TestShitS : MonoBehaviour
{
    public int id = 1;

    private void OnValidate()
    {
        id = GetInstanceID();
    }
}