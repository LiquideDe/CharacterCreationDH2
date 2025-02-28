using Zenject;

namespace CharacterCreation
{
    public class CreatorTalentsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<CreatorTalents>().AsSingle();
        }
    }
}

