using UnityEngine;

namespace Something.Scripts.Architecture.AssetsProvider
{
    public class AssetProvider : IAssetProvider
    {
        public GameObject GetAsset(string path) =>
            Resources.Load<GameObject>(path);
    }
}