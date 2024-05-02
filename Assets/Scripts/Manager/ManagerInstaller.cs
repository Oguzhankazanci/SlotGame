using Zenject;
using ObjectPool;
namespace Spin.Manager
{
    public class ManagerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IGameManager>().To<GameManager>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.Bind<IDataManager>().To<DataManager>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.Bind<IUIManager>().To<UIManager>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.Bind<ISpriteAtlasManager>().To<SpriteAtlasManager>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.Bind<IObjectPooler>().To<ObjectPooler>().FromComponentInHierarchy().AsSingle().NonLazy();
            //Container.Bind<IGameManager>().To<GameManager2>().AsSingle().NonLazy();
        }
    }
}