using System.Collections;
using UnityEngine;

namespace Something.Scripts.Architecture.Utilities
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}