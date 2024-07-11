using System;
using UnityEngine;

public class LvlMediatorUpgradeCharacter
{
    public event Action ReturnToMenu;
    private ICharacter _character;
    private LvlFactory _lvlFactory;
    private PresenterFactory _presenterFactory;

    public LvlMediatorUpgradeCharacter(LvlFactory lvlFactory, PresenterFactory presenterFactory)
    {
        _lvlFactory = lvlFactory;
        _presenterFactory = presenterFactory;
    }

    public void Initialize(ICharacter character)
    {
        _character = character;
        SetExperience();
    }

    private void SetExperience()
    {
        SetExperienceView experienceView = _lvlFactory.Get(TypeScene.InputExperience).GetComponent<SetExperienceView>();
        SetExperiencePresenter setExperiencePresenter = (SetExperiencePresenter)_presenterFactory.Get(TypeScene.InputExperience);
        setExperiencePresenter.ReturnCharacterWithExperience += ShowUpgradeCharacteristics;
        setExperiencePresenter.Initialize(_character,experienceView);
    }

    private void ShowUpgradeCharacteristics(ICharacter character)
    {
        UpgradeCharacteristicsView upgradeCharacteristicsView = _lvlFactory.Get(TypeScene.UpgradeCharacteristic).GetComponent<UpgradeCharacteristicsView>();
        UpgradeCharacteristicsPresenter characteristicsPresenter = (UpgradeCharacteristicsPresenter)_presenterFactory.Get(TypeScene.UpgradeCharacteristic);
        characteristicsPresenter.GoNext += ShowUpgradeSkill;
        characteristicsPresenter.Initialize(character, upgradeCharacteristicsView, false);
    }

    private void ShowUpgradeSkill(ICharacter character)
    {
        GameObject gameObject = _lvlFactory.Get(TypeScene.UpgradeSkill);
        UpgradeSkillCreatorView creatorView = gameObject.GetComponent<UpgradeSkillCreatorView>();
        UpgradeSkillView skillView = gameObject.GetComponent<UpgradeSkillView>();

        UpgradeSkillPresenter skillPresenter = (UpgradeSkillPresenter)_presenterFactory.Get(TypeScene.UpgradeSkill);
        skillPresenter.GoToTalent += ShowUpgradeTalent;
        skillPresenter.ReturnToCharacteristics += ShowUpgradeCharacteristics;
        skillPresenter.Initialize(skillView, creatorView, character);
    }

    private void ShowUpgradeTalent(ICharacter character)
    {
        UpgradeTalentView upgradeTalent = _lvlFactory.Get(TypeScene.UpgradeTalent).GetComponent<UpgradeTalentView>();
        UpgradeTalentPresenter talentPresenter = (UpgradeTalentPresenter)_presenterFactory.Get(TypeScene.UpgradeTalent);
        talentPresenter.ReturnToSkill += ShowUpgradeSkill;
        talentPresenter.Initialize(upgradeTalent, character);

        if (character.PsyRating > 0)
            talentPresenter.GoNext += ShowPsycana;
        else
            talentPresenter.GoNext += ShowFinalMenu;
    }

    private void ShowPsycana(ICharacter character)
    {
        GameObject gameObject = _lvlFactory.Get(TypeScene.UpgradePsycana);
        UpgradePsycanaView upgradePsycana = gameObject.GetComponent<UpgradePsycanaView>();
        PsycanaCreatorView psycanaCreatorView = gameObject.GetComponent<PsycanaCreatorView>();
        UpgradePsycanaPresenter presenter = (UpgradePsycanaPresenter)_presenterFactory.Get(TypeScene.UpgradePsycana);
        presenter.GoNext += ShowFinalMenu;
        presenter.ReturnToTalent += ShowUpgradeTalent;
        presenter.Initialize(character, psycanaCreatorView, upgradePsycana);
    }

    private void ShowFinalMenu(ICharacter character)
    {
        FinalMenuView menuView = _lvlFactory.Get(TypeScene.FinalMenu).GetComponent<FinalMenuView>();
        FinalMenuPresenter menuPresenter = (FinalMenuPresenter)_presenterFactory.Get(TypeScene.FinalMenu);
        menuPresenter.Exit += Exit;
        menuPresenter.ReturnToMenu += ReturnToMenuPressed;
        menuPresenter.SaveAndExit += TakePicturesAndExit;
        menuPresenter.SaveAndReturn += TakePictureAndReturnToMenu;
        menuPresenter.Initialize(menuView, character);
    }

    private void TakePictureAndReturnToMenu(ICharacter character)
    {
        FirstCharacterSheet firstCharacterSheet = _lvlFactory.Get(TypeScene.FirstPage).GetComponent<FirstCharacterSheet>();
        SecondCharacterSheet secondCharacterSheet = _lvlFactory.Get(TypeScene.SecondPage).GetComponent<SecondCharacterSheet>();
        ThirdCharacterSheet thirdCharacterSheet = _lvlFactory.Get(TypeScene.ThirdPage).GetComponent<ThirdCharacterSheet>();

        firstCharacterSheet.gameObject.SetActive(false);
        secondCharacterSheet.gameObject.SetActive(false);
        thirdCharacterSheet.gameObject.SetActive(false);

        TakePicturesPresenter picturesPresenter = (TakePicturesPresenter)_presenterFactory.Get(TypeScene.Pictures);
        picturesPresenter.WorkIsFinished += SaveAndReturnToMenu;
        picturesPresenter.Initialize(firstCharacterSheet, secondCharacterSheet, thirdCharacterSheet, character);
    }

    private void TakePicturesAndExit(ICharacter character)
    {
        FirstCharacterSheet firstCharacterSheet = _lvlFactory.Get(TypeScene.FirstPage).GetComponent<FirstCharacterSheet>();
        SecondCharacterSheet secondCharacterSheet = _lvlFactory.Get(TypeScene.SecondPage).GetComponent<SecondCharacterSheet>();
        ThirdCharacterSheet thirdCharacterSheet = _lvlFactory.Get(TypeScene.ThirdPage).GetComponent<ThirdCharacterSheet>();

        firstCharacterSheet.gameObject.SetActive(false);
        secondCharacterSheet.gameObject.SetActive(false);
        thirdCharacterSheet.gameObject.SetActive(false);

        TakePicturesPresenter picturesPresenter = (TakePicturesPresenter)_presenterFactory.Get(TypeScene.Pictures);
        picturesPresenter.WorkIsFinished += SaveAndExit;
        picturesPresenter.Initialize(firstCharacterSheet, secondCharacterSheet, thirdCharacterSheet, character);
    }

    private void SaveAndExit(ICharacter character)
    {
        new Save(character);
        Exit();
    }

    private void SaveAndReturnToMenu(ICharacter character)
    {
        new Save(character);
        ReturnToMenuPressed();
    }

    private void Exit()
    {
        Application.OpenURL((Application.dataPath) + "/StreamingAssets/CharacterSheets");
        Application.Quit();
    }

    private void ReturnToMenuPressed() => ReturnToMenu?.Invoke();
}
