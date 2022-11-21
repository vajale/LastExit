using System;
using System.Collections;
using System.Collections.Generic;
using Something.Scripts.Architecture;
using Something.Scripts.Architecture.GameInfrastucture;
using Something.Scripts.Architecture.Services.ServiceLocator;
using Something.Scripts.Architecture.Utilities;
using Something.Scripts.Something.Characters.MoveControllers.States;
using Something.SomethingArchitecture.Scripts.Architecture.Utilities.StateMachine;
using SomethingArchitecture.Scripts.Architecture.Services;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Something.SomethingArchitecture.Scripts.Architecture.GameInfrastucture.States
{
    public class GameLoadingState : IState
    {
        private readonly StateMachine<IState> _stateMachine;
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly SceneLoader _sceneLoader;

        private LoadingScreenView _loadingScreenView;

        public GameLoadingState(StateMachine<IState> stateMachine, ICoroutineRunner coroutineRunner,
            SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
            _stateMachine = stateMachine;
            _coroutineRunner = coroutineRunner;
        }

        public void Enter()
        {
            _coroutineRunner.StartCoroutine(LoadLoadingStateCoroutine(OnLoaded));
        }

        public void Exit()
        {
            //_loadingScreenView.gameObject.SetActive(false);
        }

        #region LoadingScreen

        private IEnumerator LoadLoadingStateCoroutine(Action onLoaded = null)
        {
            var asyncOperations = new List<AsyncOperation>()
            {
                SceneManager.LoadSceneAsync(ScenesIndex.Loading, LoadSceneMode.Additive),
                SceneManager.LoadSceneAsync(ScenesIndex.Level, LoadSceneMode.Additive)
            };

            yield return _sceneLoader.LoadWithSequenceCoroutine(asyncOperations, onLoaded);

            SceneManager.SetActiveScene(SceneManager.GetSceneByName(ScenesIndex.Level));
            _loadingScreenView = InitLoadingScreen();
        }

        private IEnumerator UnloadLoadingStateCoroutine()
        {
            var asyncOperations = new List<AsyncOperation>()
            {
                SceneManager.UnloadSceneAsync(ScenesIndex.Loading),
            };

            yield return _sceneLoader.LoadWithSequenceCoroutine(asyncOperations);
            _stateMachine.SetState<GameLoopState>();
        }

        #endregion

        private void OnLoaded()
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(ScenesIndex.Level));
            ServiceLocator.GetService<SceneReferenceService>().Initialize();
            
            RegisterGameplayService();
            _coroutineRunner.StartCoroutine(UnloadLoadingStateCoroutine());
        }

        private void RegisterGameplayService()
        {
            var dataService = ServiceLocator.GetService<StaticDataService>();
            var gameplayFactory = new GameplayService(dataService);

            ServiceLocator.Register(gameplayFactory);
        }

        private LoadingScreenView InitLoadingScreen()
        {
            if (SceneReferenceFinderExtensions.FindByTag(Tags.LoadingScreen, out var findScreen))
            {
                return findScreen.GetComponent<LoadingScreenView>();
            }

            return null;
        }
    }
}