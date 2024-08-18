using Zenject;

public class BlockLineSpawnerInstaller : MonoInstaller
{
    public override void InstallBindings() {
        Container.Bind<BlockLineSpawner>().FromComponentInHierarchy().AsSingle();
    }
}
