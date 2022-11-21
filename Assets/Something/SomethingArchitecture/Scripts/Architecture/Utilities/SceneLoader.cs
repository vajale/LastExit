using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Something.Scripts.Architecture.Utilities
{
    public class SceneLoader : IProgressProvider
    {
        private readonly ICoroutineRunner _coroutineRunner;
        private float _loadProgress = 0f;
        public float LoadingProgress => _loadProgress;

        public SceneLoader(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        public void Load(string name, LoadSceneMode loadMode, Action onLoaded = null) =>
            _coroutineRunner.StartCoroutine(LoadCoroutine(name, loadMode, onLoaded));

        public void LoadWithSequence(List<AsyncOperation> asyncOperations, Action onLoaded = null) =>
            _coroutineRunner.StartCoroutine(LoadWithSequenceCoroutine(asyncOperations, onLoaded));

        public void LoadWithActivation(string name, LoadSceneMode loadMode, Action onLoaded = null) =>
            _coroutineRunner.StartCoroutine(LoadSceneWithActivationCoroutine(name, loadMode, onLoaded));

        public IEnumerator LoadCoroutine(string nextScene, LoadSceneMode loadMode, Action onLoaded = null)
        {
            if (SceneManager.GetActiveScene().name == nextScene)
            {
                onLoaded?.Invoke();
                yield break;
            }

            var asyncLoad = SceneManager.LoadSceneAsync(nextScene, loadMode);

            while (!asyncLoad.isDone)
            {
                yield return null;
            }

            onLoaded?.Invoke();
        }

        public IEnumerator LoadSceneWithActivationCoroutine(string nextScene, LoadSceneMode loadMode, Action onLoaded = null)
        {
            if (SceneManager.GetActiveScene().name == nextScene)
            {
                onLoaded?.Invoke();
                yield break;
            }

            var asyncLoad = SceneManager.LoadSceneAsync(nextScene, loadMode);
            asyncLoad.allowSceneActivation = false;

            while (asyncLoad.progress < 0.9f)
            {
                yield return null;
            }

            asyncLoad.allowSceneActivation = true;
            onLoaded?.Invoke();
        }

        public IEnumerator LoadWithSequenceCoroutine(List<AsyncOperation> asyncOperations, Action onLoaded = null)
        {
            foreach (var loading in asyncOperations)
            {
                while (!loading.isDone)
                {
                    //_loadProgress = (_loadProgress / asyncOperations.Count);
                    yield return null;
                }
            }

            onLoaded?.Invoke();
        }
    }
}