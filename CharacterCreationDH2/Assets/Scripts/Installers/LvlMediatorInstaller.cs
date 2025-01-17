using Zenject;

public class LvlMediatorInstaller : MonoInstaller
{    
    public override void InstallBindings()
    {        
        Container.Bind<LvlMediatorNewCharacter>().AsSingle();
        Container.Bind<LvlMediatorUpgradeCharacter>().AsSingle();
        Container.Bind<LvlMediatorEditCharacter>().AsSingle();
        Container.Bind<LvlMediator>().AsSingle();
    }
}
