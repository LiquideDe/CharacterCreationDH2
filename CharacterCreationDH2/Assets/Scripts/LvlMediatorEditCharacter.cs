using System;
using UnityEngine;

public class LvlMediatorEditCharacter
{
    public event Action ReturnToMenu;
    private ICharacter _character;
    private LvlFactory _lvlFactory;
    private AudioManager _audioManager;
    private CreatorTraits _creatorTraits;
    private CreatorEquipment _creatorEquipment;
    private CreatorImplant _creatorImplant;
    private CreatorWeaponProperties _creatorWeaponProperties;
    private CreatorTalents _creatorTalents;
    private CreatorPsyPowers _creatorPsyPowers;

    public LvlMediatorEditCharacter(LvlFactory lvlFactory, AudioManager audioManager, CreatorTraits creatorTraits, CreatorEquipment creatorEquipment,
        CreatorImplant creatorImplant, CreatorWeaponProperties creatorWeaponProperties, CreatorTalents creatorTalents, CreatorPsyPowers creatorPsyPowers)
    {
        _lvlFactory = lvlFactory;
        _audioManager = audioManager;
        _creatorTraits = creatorTraits;
        _creatorEquipment = creatorEquipment;
        _creatorImplant = creatorImplant;
        _creatorWeaponProperties = creatorWeaponProperties;
        _creatorTalents = creatorTalents;
        _creatorPsyPowers = creatorPsyPowers;
    }

    public void Initialize(ICharacter character)
    {
        _character = character;
        ShowEditPropertiesFromRight(character);
    }

    private void ShowEditPropertiesFromRight(ICharacter character) => ShowEditProperties(character).Show();

    private void ShowEditPropertiesFromLeft(ICharacter character) => ShowEditProperties(character).ShowFromLeft();

    private EditPropertyCharacterView ShowEditProperties(ICharacter character)
    {
        Debug.Log($"Запускает едит");
        EditPropertyCharacterView propertyCharacterView = _lvlFactory.Get(TypeScene.EditProperties).GetComponent<EditPropertyCharacterView>();

        EditPropertyCharacterPresenter propertyCharacterPresenter = new EditPropertyCharacterPresenter
            (propertyCharacterView, _audioManager, character, _lvlFactory, _creatorTraits);
        propertyCharacterPresenter.GoNext += ShowEditCharactersFromRight;

        return propertyCharacterView;
    }

    private void ShowEditCharactersFromRight(ICharacter character) => ShowEditCharacters(character).Show();
    
    private void ShowEditCharactersFromLeft(ICharacter character) => ShowEditCharacters(character).ShowFromLeft();

    private EditCharacteristicsAndEquipmentsView ShowEditCharacters(ICharacter character)
    {
        Debug.Log($"character = {character.GetType()} is null {character == null}");
        EditCharacteristicsAndEquipmentsView equipmentsView = _lvlFactory.Get(TypeScene.EditCharacteristicsAndEquipments).GetComponent<EditCharacteristicsAndEquipmentsView>();

        EditCharacteristicsAndEquipmentsPresenter andEquipmentsPresenter =
            new EditCharacteristicsAndEquipmentsPresenter(equipmentsView, _audioManager, _lvlFactory, _creatorEquipment, _creatorImplant, _creatorWeaponProperties,
            character);

        andEquipmentsPresenter.GoNext += ShowUpgradeCharacteristicsFromRight;
        andEquipmentsPresenter.ReturnBack += ShowEditPropertiesFromLeft;
        return equipmentsView;
    }

    private void ShowUpgradeCharacteristicsFromRight(ICharacter character) => ShowUpgradeCharacteristics(character).Show();

    private void ShowUpgradeCharacteristicsFromLeft(ICharacter character) => ShowUpgradeCharacteristics(character).ShowFromLeft();

    private UpgradeCharacteristicsView ShowUpgradeCharacteristics(ICharacter character)
    {
        UpgradeCharacteristicsView upgradeCharacteristicsView = _lvlFactory.Get(TypeScene.UpgradeCharacteristic).GetComponent<UpgradeCharacteristicsView>();
        UpgradeCharacteristicsPresenter characteristicsPresenter = new UpgradeCharacteristicsPresenter(character, upgradeCharacteristicsView, _audioManager, true);
        characteristicsPresenter.GoNext += ShowUpgradeSkillFromRight;
        characteristicsPresenter.ReturnToPrev += ShowEditCharactersFromLeft;
        characteristicsPresenter.SetEdit();
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
        skillPresenter.SetEdit();

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
        talentPresenter.SetEdit();
        talentPresenter.GoNext += ShowPsycanaFromRight;

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
        presenter.SetEdit();
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
