using Zenject;

public class ScoreManagerInstaller : MonoInstaller
{
    public override void InstallBindings() {
        Container.Bind<ScoreManager>().FromComponentInHierarchy().AsSingle();
    }
}
