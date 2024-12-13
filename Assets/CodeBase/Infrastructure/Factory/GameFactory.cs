using CodeBase.Infrastructure.AssetManagement;
using UnityEngine;

namespace CodeBase.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assets;
        private GameObject _hudInstance;

        public GameFactory(IAssetProvider assets)
        {
            _assets = assets;
        }

        public void CreateHud()
        {
            _hudInstance = _assets.Instantiate(AssetPath.ManagerPath);
            Object.DontDestroyOnLoad(_hudInstance);
        }
    }
}