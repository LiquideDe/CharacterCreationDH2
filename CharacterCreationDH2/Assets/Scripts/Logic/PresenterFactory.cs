using Zenject;
using System;

public class PresenterFactory
{
    private DiContainer _diContainer;

    public PresenterFactory(DiContainer diContainer) => _diContainer = diContainer;

    public IPresenter Get(TypeScene type)
    {
        switch (type)
        {
            case TypeScene.Homeworld:
                return _diContainer.Instantiate<HomeworldPresenter>();

            case TypeScene.HomeworldFinal:
                return _diContainer.Instantiate<HomeworldFinalPanelPresenter>();

            case TypeScene.MainMenu:
                return _diContainer.Instantiate<MainMenuPresenter>();

            case TypeScene.Background:
                return _diContainer.Instantiate<BackgroundPresenter>();

            case TypeScene.BackgroundFinal:
                return _diContainer.Instantiate<BackgroundFinalPanelPresenter>();

            case TypeScene.Role:
                return _diContainer.Instantiate<RolePresenter>();

            case TypeScene.RoleFinal:
                return _diContainer.Instantiate<RoleFinalPresenter>();

            case TypeScene.RandomCharacteristic:
                return _diContainer.Instantiate<CharacteristicRandomPresenter>();

            case TypeScene.ManualCharacteristic:
                return _diContainer.Instantiate<CharacteristicManualPresenter>();

            case TypeScene.UpgradeCharacteristic:
                return _diContainer.Instantiate<UpgradeCharacteristicsPresenter>();

            case TypeScene.UpgradeSkill:
                return _diContainer.Instantiate<UpgradeSkillPresenter>();

            case TypeScene.UpgradeTalent:
                return _diContainer.Instantiate<UpgradeTalentPresenter>();

            case TypeScene.UpgradePsycana:
                return _diContainer.Instantiate<UpgradePsycanaPresenter>();

            case TypeScene.Prophecy:
                return _diContainer.Instantiate<ProphecyPresenter>();

            case TypeScene.Name:
                return _diContainer.Instantiate<ChooseNamePresenter>();

            case TypeScene.Pictures:
                return _diContainer.Instantiate<TakePicturesPresenter>();

            case TypeScene.Loads:
                return _diContainer.Instantiate<CharacterLoadsPresenter>();

            case TypeScene.InputExperience:
                return _diContainer.Instantiate<SetExperiencePresenter>();

            case TypeScene.FinalMenu:
                return _diContainer.Instantiate<FinalMenuPresenter>();

            case TypeScene.EditProperties:
                return _diContainer.Instantiate<EditPropertyCharacterPresenter>();

            case TypeScene.EditCharacteristicsAndEquipments:
                return _diContainer.Instantiate<EditCharacteristicsAndEquipmentsPresenter>();

            default:
                throw new ArgumentException(nameof(type));
        }
    }
}
