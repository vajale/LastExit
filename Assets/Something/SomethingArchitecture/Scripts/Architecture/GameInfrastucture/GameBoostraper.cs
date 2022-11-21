using Something.Scripts.Architecture.AssetsProvider;
using Something.Scripts.Architecture.Utilities;
using SomethingArchitecture.Scripts.Architecture.Services;
using UnityEngine;

namespace Something.Scripts.Architecture.GameInfrastucture
{
    public class GameBoostraper : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField] private bool _isTest;
        [SerializeField] private StaticDataService _staticDataService;
        private Game _game;
        private AssetProvider _assets;


        private void Awake()
        {
            _assets = new AssetProvider();
            _game = new Game(this, _isTest);

            DontDestroyOnLoad(this.gameObject);
        }
    }
}