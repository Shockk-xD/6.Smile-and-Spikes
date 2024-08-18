using Zenject;

public class CoinBankInstaller : MonoInstaller
{
    public override void InstallBindings() {
        var coinBank = new CoinBank();
        Container.Bind<CoinBank>().FromInstance(coinBank).AsSingle();
    }
}
