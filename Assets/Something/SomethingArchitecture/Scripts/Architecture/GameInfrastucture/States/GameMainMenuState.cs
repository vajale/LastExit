using System.Collections;
using System.Collections.Generic;
using Something.Scripts.Architecture;
using Something.Scripts.Architecture.Utilities;
using Something.Scripts.Something.Characters.MoveControllers.States;
using Something.SomethingArchitecture.Scripts.Architecture.MainMenu;
using Something.SomethingArchitecture.Scripts.Architecture.Utilities.StateMachine;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Something.SomethingArchitecture.Scripts.Architecture.GameInfrastucture.States
{
    public class GameMainMenuState : IState
    {
        private readonly StateMachine<IState> _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly ICoroutineRunner _coroutineRunner;
        private MainMenuView _mainMenuView;

        public GameMainMenuState(StateMachine<IState> stateMachine, ICoroutineRunner coroutineRunner,
            SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
            _stateMachine = stateMachine;
            _coroutineRunner = coroutineRunner;
        }

        public void Enter()
        {
            _coroutineRunner.StartCoroutine(LoadMainMenuViewCoroutine());
        }

        public void Exit()
        {
            UninitializeMainMenu();
        }

        #region Initialize

        private IEnumerator LoadMainMenuViewCoroutine()
        {
            var asyncOperations = new List<AsyncOperation>
            {
                SceneManager.LoadSceneAsync(ScenesIndex.MainMenuView, LoadSceneMode.Additive),
                SceneManager.LoadSceneAsync(ScenesIndex.MainMenuBackground, LoadSceneMode.Additive)
            };

            yield return _sceneLoader.LoadWithSequenceCoroutine(asyncOperations);
            InitializeMainMenu();
        }

        private IEnumerator UnloadMainMenuViewCoroutine()
        {
            yield return _mainMenuView.FadeIn();

            var asyncOperations = new List<AsyncOperation>
            {
                SceneManager.UnloadSceneAsync(ScenesIndex.MainMenuView),
                SceneManager.UnloadSceneAsync(ScenesIndex.MainMenuBackground)
            };

            yield return _sceneLoader.LoadWithSequenceCoroutine(asyncOperations);
            _stateMachine.SetState<GameLoadingState>();
        }

        private void InitializeMainMenu()
        {
            _mainMenuView = FindOrInstantiateMainMenu();

            _mainMenuView.Initialize();
            _mainMenuView.GameLoading += EnterGameLoadingState;
        }

        private void UninitializeMainMenu()
        {
            _mainMenuView.Uninitialize();
            _mainMenuView.GameLoading -= EnterGameLoadingState;
        }

        #endregion

        private void EnterGameLoadingState()
        {
            _coroutineRunner.StartCoroutine(UnloadMainMenuViewCoroutine());
        }

        private MainMenuView FindOrInstantiateMainMenu()
        {
            if (SceneReferenceFinderExtensions.FindByTag(Tags.MainMenu, out var findMenu))
            {
                return findMenu.GetComponent<MainMenuView>();
            }

            return null;
        }
    }
}