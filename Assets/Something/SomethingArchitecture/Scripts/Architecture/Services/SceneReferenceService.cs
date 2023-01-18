using System;
using System.Collections.Generic;
using Something.Scripts.Architecture.Services.ServiceLocator;
using Something.Scripts.Architecture.Utilities;
using Something.Scripts.Something.Spawners;
using Something.SomethingArchitecture.Scripts.Architecture.GameInfrastucture.States;
using Something.SomethingArchitecture.Scripts.Something.Camera;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

namespace Something.Scripts.Architecture.GameInfrastucture
{
    public class SceneReferenceService : IService
    {
        private MainCamera _mainCamera;
        private NavMeshSurface _navMeshSurface;
        private List<EnemySquadSpawner> _enemySpawners;
        private Vector3 _playerSpawnPosition;
        private bool _isInitialized;

        public SceneReferenceService()
        {
            _isInitialized = false;
        }

        public void Initialize()
        {
            InitializeSpawners();
            InitializeSpawnPosition();
            InitializeNavMesh();
            InitializeMainCamera();
        }

        public MainCamera GetMainCamera() =>
            CheckInitialize() == false ? null : _mainCamera;

        public NavMeshSurface GetNavMeshSurface() =>
            CheckInitialize() == false ? null : _navMeshSurface;

        public IReadOnlyList<EnemySquadSpawner> GetSpawners()
        {
            return _enemySpawners;
        }

        public Vector3 GetPlayerSpawnPosition() =>
            CheckInitialize() ? new Vector3() : _playerSpawnPosition;

        private bool CheckInitialize()
        {
            // if (_isInitialized == false)
            // {
            //     throw new Exception("Scene references not has been initialized and cannot return Scene gameObject");
            // }

            return true;
        }

        private void InitializeMainCamera()
        {
            var component = FindOnScene<MainCamera>(Tags.MainCamera);

            if (SearchIsFailed(component)) return;

            _mainCamera = component;
        }

        private bool SearchIsFailed(object component)
        {
            if (component == null)
            {
                throw new Exception(component.ToString() + "нету его на");
            }

            return false;
        }

        private void InitializeNavMesh()
        {
            var component = FindOnScene<NavMeshSurface>(Tags.NavMeshSurface);
            if (SearchIsFailed(component)) return;
            _navMeshSurface = component;
        }

        private void InitializeSpawnPosition()
        {
            SceneReferenceFinderExtensions.FindByTag(Tags.PlayerSpawn, out var gameObject);
            _playerSpawnPosition = gameObject == null ? gameObject.transform.position : new Vector3();
        }

        private T FindOnScene<T>(string tag) where T : MonoBehaviour
        {
            var taggedGameObject = SceneReferenceFinderExtensions.FindByTag(tag);

            if (taggedGameObject != null)
            {
                taggedGameObject.TryGetComponent(out T component);

                if (component == null)
                    throw new Exception(component + " component is  not contains on " + taggedGameObject.name);


                return component;
            }

            return null;
        }

        private void InitializeSpawners()
        {
            var spawners = SceneReferenceFinderExtensions.FindByTags(Tags.EnemySpawner);
            _enemySpawners = new List<EnemySquadSpawner>();

            foreach (var spawner in spawners)
            {
                _enemySpawners.Add(spawner.GetComponent<EnemySquadSpawner>());
            }
        }

        public List<T> Find<T>(string tag) where T : MonoBehaviour
        {
            var levers = SceneReferenceFinderExtensions.FindByTags(tag);

            List<T> list = new List<T>();

            foreach (var lever in levers)
                list.Add(lever.GetComponent<T>());

            return list;
        }
    }
}