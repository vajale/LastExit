using System;
using Something.Scripts.Architecture.Services.ServiceLocator;
using Something.Scripts.Architecture.Utilities;
using Something.Scripts.Something.Spawners;
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
        private EnemySquadSpawner[] _enemySpawners;
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
            
            Debug.Log(SceneManager.GetActiveScene().name + " is active scene to find Reference");
            
            _isInitialized = true;
        }

        public MainCamera GetMainCamera() =>
            CheckInitialize() == false ? null : _mainCamera;

        public NavMeshSurface GetNavMeshSurface() =>
            CheckInitialize() == false ? null : _navMeshSurface;

        public EnemySquadSpawner[] GetSpawners() =>
            CheckInitialize() == false ? null : _enemySpawners;

        public Vector3 GetPlayerSpawnPosition() =>
            CheckInitialize() ? new Vector3() : _playerSpawnPosition;

        private bool CheckInitialize()
        {
            if (_isInitialized == false)
            {
                throw new Exception("Scene references not has been initialized and cannot return Scene gameObject");
            }

            return true;
        }

        private void InitializeMainCamera()
        {
            var component = FindOnScene<MainCamera>(Tags.MainCamera);
            _mainCamera = component;
        }

        private void InitializeNavMesh()
        {
            var component = FindOnScene<NavMeshSurface>(Tags.NavMeshSurface);
            _navMeshSurface = component;
        }

        private void InitializeSpawnPosition()
        {
            //SceneReferenceFinderExtensions.FindByTag(Tags.PlayerSpawn, out var gameObject);
            //_playerSpawnPosition = gameObject == null ? gameObject.transform.position : new Vector3();
        }

        private T FindOnScene<T>(string tag) where T : MonoBehaviour
        {
            var taggedGameObject = SceneReferenceFinderExtensions.FindByTag(tag);
            taggedGameObject.TryGetComponent(out T component);

            if (component == null)
                throw new Exception(component + " component is  not contains on " + taggedGameObject.name);

            return component;
        }

        private void InitializeSpawners()
        {
            var spawners = SceneReferenceFinderExtensions.FindByTags(Tags.EnemySpawner);
            var array = new EnemySquadSpawner[spawners.Length];

            for (var i = 0; i < spawners.Length; i++)
            {
                array[i] = spawners[i].GetComponent<EnemySquadSpawner>();
            }

            _enemySpawners = array;
        }
    }
}