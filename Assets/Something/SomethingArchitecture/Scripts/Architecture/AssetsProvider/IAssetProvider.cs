using UnityEngine;

namespace Something.Scripts.Architecture.AssetsProvider
{
    public interface IAssetProvider
    {
        GameObject GetAsset(string path);
    }
}