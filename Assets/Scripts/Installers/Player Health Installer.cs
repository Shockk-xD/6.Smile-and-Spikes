using Zenject;

public class PlayerHealthInstaller : MonoInstaller
{
    public override void InstallBindings() {
        Container.Bind<PlayerHealth>().FromComponentInHierarchy().AsSingle();
    }
}
