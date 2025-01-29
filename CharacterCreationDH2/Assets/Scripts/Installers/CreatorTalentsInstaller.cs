using Zenject;

public class CreatorTalentsInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<CreatorTalents>().AsSingle();
    }
}
