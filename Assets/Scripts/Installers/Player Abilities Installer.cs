using UnityEngine;
using Zenject;

public class PlayerAbilitiesInstaller : MonoInstaller
{
    public override void InstallBindings() {
        InstallCoinAttractionAbility();
        InstallPlayerShield();
    }

    private void InstallPlayerShield() {
        Container.Bind<PlayerShield>()
                    .FromComponentInHierarchy(true)
                    .AsSingle();
    }

    private void InstallCoinAttractionAbility() {
        Container.Bind<CoinAttractionAbility>()
            .FromComponentInHierarchy(true)
            .AsSingle();
    }
}
