using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Factory;
using Zenject;

namespace CodeBase.Infrastructure.Installers
{
    public class GameplayInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
            Container.Bind<IGameFactory>().To<GameFactory>().AsSingle();
            Container.Bind<SceneLoader>().AsSingle();
            Container.Bind<ICoroutineRunner>().FromInstance(FindObjectOfType<GameBootstrapper>()).AsSingle();
        }
    }
}