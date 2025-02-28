using Zenject;

namespace CharacterCreation
{
    public class CreatorInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindInstance();
        }

        private void BindInstance()
        {
            Container.Bind<CreatorSkills>().AsSingle();
            Container.Bind<CreatorEquipment>().AsSingle();
            Container.Bind<CreatorTraits>().AsSingle();
            Container.Bind<CreatorImplant>().AsSingle();
            Container.Bind<CreatorPsyPowers>().AsSingle();
            Container.Bind<CreatorWeaponTrait>().AsSingle();
        }
    }
}

