using UnityEngine;
using Zenject;

public class LvlMediatorInstaller : MonoInstaller
{
    [SerializeField] private PrefabHolder _prefabHolder;
    public override void InstallBindings()
    {
        Container.Bind<PrefabHolder>().FromInstance(_prefabHolder).AsSingle();
        Container.Bind<LvlFactory>().AsSingle();
        Container.Bind<PresenterFactory>().AsSingle();
        Container.Bind<CharacterFactory>().AsSingle();
        Container.Bind<LvlMediatorNewCharacter>().AsSingle();
        Container.Bind<LvlMediatorUpgradeCharacter>().AsSingle();
        Container.Bind<LvlVediatorEditCharacter>().AsSingle();
        Container.Bind<LvlMediator>().AsSingle();
    }
}
