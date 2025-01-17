using System;
using UnityEngine;

public class LvlMediatorUpgradeCharacter
{
    public event Action ReturnToMenu;
    private ICharacter _character;
    private LvlFactory _lvlFactory;
    private AudioManager _audioManager;
    private CreatorTalents _creatorTalents;
    private CreatorPsyPowers _creatorPsyPowers;

    public LvlMediatorUpgradeCharacter(LvlFactory lvlFactory, AudioManager audioManager, CreatorTalents creatorTalents, CreatorPsyPowers creatorPsyPowers)
    {
        _lvlFactory = lvlFactory;
        _audioManager = audioManager;
        _creatorTalents = creatorTalents;
        _creatorPsyPowers = creatorPsyPowers;
    }

    public void Initialize(ICharacter character)
    {
        _character = character;
        SetExperience();
    }

    private void SetExperience()
    {
        SetExperienceView experienceView = _lvlFactory.Get(TypeScene.InputExperience).GetComponent<SetExperienceView>();
        SetExperiencePresenter setExperiencePresenter = new SetExperiencePresenter( _audioManager, _character, experienceView );
        setExperiencePresenter.ReturnCharacterWithExperience += ShowUpgradeCharacteristicsFromRight;
    }

    private void ShowUpgradeCharacteristicsFromRight(ICharacter character) => ShowUpgradeCharacteristics(character).Show();

    private void ShowUpgradeCharacteristicsFromLeft(ICharacter character) => ShowUpgradeCharacteristics(character).ShowFromLeft();

    private UpgradeCharacteristicsView ShowUpgradeCharacteristics(ICharacter character)
    {
        UpgradeCharacteristicsView upgradeCharacteristicsView = _lvlFactory.Get(TypeScene.UpgradeCharacteristic).GetComponent<UpgradeCharacteristicsView>();
        UpgradeCharacteristicsPresenter characteristicsPresenter = new UpgradeCharacteristicsPresenter(character, upgradeCharacteristicsView, _audioManager, true);
        characteristicsPresenter.GoNext += ShowUpgradeSkillFromRight;
        upgradeCharacteristicsView.SetVisibleButtonReturnBack(false);
        return upgradeCharacteristicsView;
    }

    private void ShowUpgradeSkillFromRight(ICharacter character) => ShowUpgradeSkill(character).Show();

    private void ShowUpgradeSkillFromLeft(ICharacter character) => ShowUpgradeSkill(character).ShowFromLeft();

    private UpgradeSkillView ShowUpgradeSkill(ICharacter character)
    {
        GameObject gameObject = _lvlFactory.Get(TypeScene.UpgradeSkill);
        UpgradeSkillCreatorView creatorView = gameObject.GetComponent<UpgradeSkillCreatorView>();
        UpgradeSkillView skillView = gameObject.GetComponent<UpgradeSkillView>();

        UpgradeSkillPresenter skillPresenter = new UpgradeSkillPresenter(creatorView, skillView, character, _audioManager);
        skillPresenter.GoToTalent += ShowUpgradeTalentFromRight;
        skillPresenter.ReturnToCharacteristics += ShowUpgradeCharacteristicsFromLeft;
        skillPresenter.ShowInformationPanel += ShowInfoSkill;

        return skillView;
    }

    private void ShowInfoSkill(Skill skill)
    {
        CanvasWithSkillInfo info = _lvlFactory.Get(TypeScene.SkillInformationPanel).GetComponent<CanvasWithSkillInfo>();
        info.SetSkill(skill);
        info.Show();
    }

    private void ShowUpgradeTalentFromRight(ICharacter character) => ShowUpgradeTalent(character).Show();

    private void ShowUpgradeTalentFromLeft(ICharacter character) => ShowUpgradeTalent(character).ShowFromLeft();

    private UpgradeTalentView ShowUpgradeTalent(ICharacter character)
    {
        UpgradeTalentView upgradeTalent = _lvlFactory.Get(TypeScene.UpgradeTalent).GetComponent<UpgradeTalentView>();

        UpgradeTalentPresenter talentPresenter = new UpgradeTalentPresenter(character, upgradeTalent, _audioManager, _creatorTalents);
        talentPresenter.ReturnToSkill += ShowUpgradeSkillFromLeft;

        if (character.PsyRating > 0)
            talentPresenter.GoNext += ShowPsycanaFromRight;
        else
            talentPresenter.GoNext += ShowFinalMenu;

        return upgradeTalent;
    }

    private void ShowPsycanaFromRight(ICharacter character) => ShowPsycana(character).Show();
    private void ShowPsycanaFromLeft(ICharacter character) => ShowPsycana(character).ShowFromLeft();

    private UpgradePsycanaView ShowPsycana(ICharacter character)
    {
        GameObject gameObject = _lvlFactory.Get(TypeScene.UpgradePsycana);
        UpgradePsycanaView upgradePsycana = gameObject.GetComponent<UpgradePsycanaView>();
        PsycanaCreatorView psycanaCreatorView = gameObject.GetComponent<PsycanaCreatorView>();
        UpgradePsycanaPresenter presenter = new UpgradePsycanaPresenter(character, _audioManager, psycanaCreatorView, upgradePsycana, _creatorPsyPowers);
        presenter.GoNext += ShowFinalMenu;
        presenter.ReturnToTalent += ShowUpgradeTalentFromLeft;
        return upgradePsycana;
    }

    private void ShowFinalMenu(ICharacter character)
    {
        FinalMenuView menuView = _lvlFactory.Get(TypeScene.FinalMenu).GetComponent<FinalMenuView>();
        FinalMenuPresenter menuPresenter = new FinalMenuPresenter(_audioManager, menuView, character);
        menuPresenter.Exit += Exit;
        menuPresenter.ReturnToMenu += ReturnToMenuPressed;
        menuPresenter.SaveAndExit += TakePicturesAndExit;
        menuPresenter.SaveAndReturn += TakePictureAndReturnToMenu;
        menuView.Show();
    }

    private void TakePictureAndReturnToMenu(ICharacter character) => TakePictureAndSomething(SaveAndReturnToMenu, character);
    

    private void TakePicturesAndExit(ICharacter character) => TakePictureAndSomething(SaveAndExit, character);

    private void TakePictureAndSomething(Action<ICharacter> doSome, ICharacter character)
    {
        FirstCharacterSheet firstCharacterSheet = _lvlFactory.Get(TypeScene.FirstPage).GetComponent<FirstCharacterSheet>();
        SecondCharacterSheet secondCharacterSheet = _lvlFactory.Get(TypeScene.SecondPage).GetComponent<SecondCharacterSheet>();
        ThirdCharacterSheet thirdCharacterSheet = _lvlFactory.Get(TypeScene.ThirdPage).GetComponent<ThirdCharacterSheet>();

        firstCharacterSheet.gameObject.SetActive(false);
        secondCharacterSheet.gameObject.SetActive(false);
        thirdCharacterSheet.gameObject.SetActive(false);

        TakePicturesPresenter picturesPresenter = new TakePicturesPresenter(firstCharacterSheet, secondCharacterSheet, thirdCharacterSheet, character);
        picturesPresenter.WorkIsFinished += doSome;
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
