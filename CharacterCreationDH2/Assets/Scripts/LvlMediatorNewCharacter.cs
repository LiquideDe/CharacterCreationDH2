using System;
using UnityEngine;

public class LvlMediatorNewCharacter
{
    public event Action ReturnToMenu;
    private LvlFactory _lvlFactory;
    private CharacterFactory _characterFactory;
    private ICharacter _character;
    private AudioManager _audioManager;
    private CreatorTalents _creatorTalents;
    private CreatorPsyPowers _creatorPsyPowers;
    private CreatorSkills _creatorSkills;
    private CreatorTraits _creatorTraits;
    private CreatorImplant _creatorImplant;

    private CreatorWorlds _creatorWorlds;
    private CreatorBackgrounds _creatorBackgrounds;
    private CreatorRole _creatorRole;

    public LvlMediatorNewCharacter(LvlFactory lvlFactory, CharacterFactory characterFactory, AudioManager audioManager,
        CreatorTalents creatorTalents, CreatorPsyPowers creatorPsyPowers, CreatorTraits creatorTraits, CreatorImplant creatorImplant, CreatorSkills creatorSkills)
    {
        _lvlFactory = lvlFactory;
        _characterFactory = characterFactory;
        _audioManager = audioManager;
        _creatorTalents = creatorTalents;
        _creatorPsyPowers = creatorPsyPowers;
        _creatorTraits = creatorTraits;
        _creatorImplant = creatorImplant;
        _creatorSkills = creatorSkills;
    }

    public void LoadNewCharacter()
    {
        LoadingCanvas loadingScreen = _lvlFactory.Get(TypeScene.Loading).GetComponent<LoadingCanvas>();
        loadingScreen.SetMaxAmount(3);
        _creatorWorlds = new CreatorWorlds(_creatorSkills, _audioManager);
        _creatorBackgrounds = new CreatorBackgrounds(_creatorSkills, _creatorTalents, _creatorTraits, _creatorImplant, _audioManager);
        _creatorRole = new CreatorRole(_creatorTalents, _audioManager);

        _creatorWorlds.CreateWorldIsFinished += loadingScreen.PlusReady;
        _creatorBackgrounds.CreateBackgroundIsDone += loadingScreen.PlusReady;
        _creatorRole.CreatingRoleIsDone += loadingScreen.PlusReady;
        loadingScreen.LoadingIsDone += NewCharacter;
    }

    private void NewCharacter()
    {
        _character = _characterFactory.Get();
        CanvasIntermediate canvasIntermediate = _lvlFactory.Get(TypeScene.Intermediate).GetComponent<CanvasIntermediate>();
        canvasIntermediate.gameObject.SetActive(true);
        canvasIntermediate.OpenIntermediatePanel(ShowMessageBeforeWorld, "Это сорок первое тысячелетие. Вот уже сотню веков Император недвижимо восседает на Золотом троне Земли. " +
            "Волей богов он владычествует над человечеством, и мощью своих неисчислимых армий он повелевает миллионом миров. " +
            "Он – гниющий труп, незримо поддерживаемый  могуществом Тёмной эры технологий. " +
            "Он – Великий падальщик, которому каждый день приносят в жертву тысячу душ, и которой поэтому никогда по-настоящему не умрёт. " +
            "Быть человеком в такие времена – значит быть одним из бессчётных миллиардов. Это значит жить при самом жестоком и кровавом режиме, который можно вообразить. " +
            "Эта история о тех временах. Забудьте о могуществе технологии и науки, ибо было забыто столь многое, что уже никогда не будет открыто вновь. " +
            "Забудьте об обещаниях прогресса и взаимопонимания, ибо в беспросветном мраке будущего есть только война. " +
            "Нет мира среди звезд, есть лишь вечность бойни и резни под смех кровожадных богов.");
    }

    private void ShowMessageBeforeWorld()
    {
        CanvasIntermediate canvasIntermediate = _lvlFactory.Get(TypeScene.Intermediate).GetComponent<CanvasIntermediate>();
        canvasIntermediate.gameObject.SetActive(true);
        canvasIntermediate.OpenIntermediatePanel(OpenHomeworldPanelFromRight, "В следующем окне вам нужно выбрать свой родной мир. " +
            "Тип мира будет отражать ваши привычки, вашу внешность и восприятие окружения. " +
            "Так же родной мир определяет сильные и слабые стороны");
    }

    private void OpenHomeworldPanelFromLeft() => OpenHomeworldPanel().ShowFromLeft();


    private void OpenHomeworldPanelFromRight() => OpenHomeworldPanel().Show();

    private HomeworldBackGroundRoleView OpenHomeworldPanel()
    {
        HomeworldBackGroundRoleView homeworldView = _lvlFactory.Get(TypeScene.Homeworld).GetComponent<HomeworldBackGroundRoleView>();
        HomeworldPresenter homeworldPresenter = new HomeworldPresenter(homeworldView, _lvlFactory, _creatorWorlds, _audioManager, _character);
        homeworldPresenter.ChooseIsDone += CharacterHasHomeworld;
        return homeworldView;
    }

    private void CharacterHasHomeworld(ICharacter character)
    {
        _character = character;
        ShowMessageBeforeBackground();
    }

    private void ShowMessageBeforeBackground()
    {
        CanvasIntermediate canvasIntermediate = _lvlFactory.Get(TypeScene.Intermediate).GetComponent<CanvasIntermediate>();
        canvasIntermediate.OpenIntermediatePanel(OpenBackgroundPanelFromRight, "В следующем окне вам следует выбрать свою предисторию. Кем вы были до того как поступить на службу инквизиции. " +
            "Этот выбор " +
            "повлияет на стартовую экипировку, таланты и склонности");
    }

    private void OpenBackgroundPanelFromRight() => OpenBackgroundPanel().Show();

    private void OpenBackgroundPanelFromLeft() => OpenBackgroundPanel().ShowFromLeft();

    private HomeworldBackGroundRoleView OpenBackgroundPanel()
    {
        HomeworldBackGroundRoleView homeworldView = _lvlFactory.Get(TypeScene.Background).GetComponent<HomeworldBackGroundRoleView>();
        BackgroundPresenter backgroundPresenter = new BackgroundPresenter(homeworldView, _lvlFactory, _creatorBackgrounds, _audioManager, _character);
        backgroundPresenter.ChooseIsDone += CharacterHasBackground;
        backgroundPresenter.ReturnToPrevWindow += OpenHomeworldPanelFromLeft;
        return homeworldView;
    }

    private void CharacterHasBackground(ICharacter character)
    {
        _character = character;
        ShowMessageBeforeRole();
    }

    private void ShowMessageBeforeRole()
    {
        CanvasIntermediate canvasIntermediate = _lvlFactory.Get(TypeScene.Intermediate).GetComponent<CanvasIntermediate>();
        canvasIntermediate.OpenIntermediatePanel(OpenRoleCanvasFromRight, "В следующем окне вам следует выбрать свою роль. Это больше игромеханический выбор в каком направлении " +
            "вы хотите развиваться. Выбор роли влияет на таланты и склонности.");
    }

    private void OpenRoleCanvasFromRight() => OpenRoleCanvas().Show();

    private void OpenRoleCanvasFromLeft() => OpenRoleCanvas().ShowFromLeft();

    private HomeworldBackGroundRoleView OpenRoleCanvas()
    {
        HomeworldBackGroundRoleView homeworldView = _lvlFactory.Get(TypeScene.Role).GetComponent<HomeworldBackGroundRoleView>();
        RolePresenter rolePresenter = new RolePresenter(_lvlFactory, homeworldView, _creatorRole, _character, _audioManager);
        rolePresenter.ReturnToPrevWindow += OpenBackgroundPanelFromLeft;
        rolePresenter.ChooseIsDone += CharacterHasRole;
        return homeworldView;
    }

    private void CharacterHasRole(ICharacter character)
    {
        _character = character;
        ShowChoiceBetweenManualAndRandomFromRight();
    }

    private void ShowChoiceBetweenManualAndRandomFromRight() => ShowChoiceBetweenManualAndRandom(_character).Show();
    private void ShowChoiceBetweenManualAndRandomFromLeft(ICharacter character) => ShowChoiceBetweenManualAndRandom(character).ShowFromLeft();

    private CanvasChoiceManulaAndRandom ShowChoiceBetweenManualAndRandom(ICharacter character)
    {
        CanvasChoiceManulaAndRandom manulaAndRandom = _lvlFactory.Get(TypeScene.ChoiceBetweenManualAndRandom).GetComponent<CanvasChoiceManulaAndRandom>();
        manulaAndRandom.ShowChoose();
        manulaAndRandom.ChooseManual += ShowManual;
        manulaAndRandom.ChoseRandom += ShowRandom;
        return manulaAndRandom;
    }

    private void ShowManual(int startCharacteristic)
    {
        CharacteristicManualView characteristicView = _lvlFactory.Get(TypeScene.ManualCharacteristic).GetComponent<CharacteristicManualView>();
        CharacteristicManualPresenter characteristicPresenter = new CharacteristicManualPresenter(_character, characteristicView, startCharacteristic, _audioManager);
        characteristicPresenter.ReturnToRole += OpenRoleCanvasFromLeft;
        characteristicPresenter.ReturnCharacterWithCharacteristics += CharacterHasCharacteristics;
    }

    private void ShowRandom(int startCharacteristic)
    {
        CharacteristicRandomView characteristicRandomView = _lvlFactory.Get(TypeScene.RandomCharacteristic).GetComponent<CharacteristicRandomView>();
        CharacteristicRandomPresenter characteristicRandomPresenter = 
            new CharacteristicRandomPresenter(_character, characteristicRandomView, startCharacteristic, _audioManager);
        characteristicRandomPresenter.ReturnToRole += OpenRoleCanvasFromLeft;
        characteristicRandomPresenter.ReturnCharacterWithCharacteristics += CharacterHasCharacteristics;
    }

    private void CharacterHasCharacteristics(ICharacter character)
    {
        _character = character;
        ShowMessageBeforeTrainingCharacteristics();
    }

    private void ShowMessageBeforeTrainingCharacteristics()
    {
        CanvasIntermediate canvasIntermediate = _lvlFactory.Get(TypeScene.Intermediate).GetComponent<CanvasIntermediate>();
        
        canvasIntermediate.OpenIntermediatePanel(PrepareCharacterAnus, "В следующих трех окнах вы можете прокачать персонажа: вам доступно 1000 Очков Опыта, которые можно потратить как на " +
            "улучшение храктеристик, так и на навыки и таланты. Вы можете свободно переключаться между ними. Наведя на шкалу интенсивности, вы увидите стоимость улучшения в очках опыта.");
    }

    private void PrepareCharacterAnus()
    {
        CharacterWithUpgrade character = new CharacterWithUpgrade(_character);
        character.SetExperience(1000);
        _character = character;
        ShowUpgradeCharacteristicsFromRight(_character);
    }

    private void ShowUpgradeCharacteristicsFromRight(ICharacter character) => ShowUpgradeCharacteristics(character).Show();

    private void ShowUpgradeCharacteristicsFromLeft(ICharacter character) => ShowUpgradeCharacteristics(character).ShowFromLeft();

    private UpgradeCharacteristicsView ShowUpgradeCharacteristics(ICharacter character)
    {
        UpgradeCharacteristicsView upgradeCharacteristicsView = _lvlFactory.Get(TypeScene.UpgradeCharacteristic).GetComponent<UpgradeCharacteristicsView>();
        UpgradeCharacteristicsPresenter characteristicsPresenter = new UpgradeCharacteristicsPresenter(character, upgradeCharacteristicsView, _audioManager, true);
        characteristicsPresenter.GoNext += ShowUpgradeSkillFromRight;
        characteristicsPresenter.ReturnToPrev += ShowChoiceBetweenManualAndRandomFromLeft;
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
            talentPresenter.GoNext += ShowProphecy;

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
        presenter.GoNext += ShowProphecy;
        presenter.ReturnToTalent += ShowUpgradeTalentFromLeft;
        return upgradePsycana;
    }

    private void ShowProphecy(ICharacter character)
    {
        _character = character;
        ProphecyView prophecyView = _lvlFactory.Get(TypeScene.Prophecy).GetComponent<ProphecyView>();
        ProphecyPresenter prophecyPresenter = new ProphecyPresenter( prophecyView, character, _audioManager);
        prophecyPresenter.GoNext += ShowChooseName;
    }

    private void ShowChooseName(ICharacter character)
    {
        ChooseNameView chooseNameView = _lvlFactory.Get(TypeScene.Name).GetComponent<ChooseNameView>();
        ChooseNamePresenter namePresenter = new ChooseNamePresenter(chooseNameView, character, _audioManager);
        namePresenter.GoNext += TakePictures;
    }

    private void TakePictures(ICharacter character)
    {
        FirstCharacterSheet firstCharacterSheet = _lvlFactory.Get(TypeScene.FirstPage).GetComponent<FirstCharacterSheet>();
        SecondCharacterSheet secondCharacterSheet = _lvlFactory.Get(TypeScene.SecondPage).GetComponent<SecondCharacterSheet>();
        ThirdCharacterSheet thirdCharacterSheet = _lvlFactory.Get(TypeScene.ThirdPage).GetComponent<ThirdCharacterSheet>();

        firstCharacterSheet.gameObject.SetActive(false);
        secondCharacterSheet.gameObject.SetActive(false);
        thirdCharacterSheet.gameObject.SetActive(false);

        TakePicturesPresenter picturesPresenter = new TakePicturesPresenter(firstCharacterSheet, secondCharacterSheet, thirdCharacterSheet, character);
        picturesPresenter.WorkIsFinished += SaveCharacterAndExit;
    }

    private void SaveCharacterAndExit(ICharacter character)
    {
        new Save(character);
        ReturnToMenu?.Invoke();
    }

}
