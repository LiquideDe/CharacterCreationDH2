using Zenject;

namespace CharacterCreation
{
    public class FactoryInstaller : MonoInstaller
    {

        public override void InstallBindings()
        {
            Container.Bind<LvlFactory>().AsSingle();
            Container.Bind<CharacterFactory>().AsSingle();
        }
    }
}

