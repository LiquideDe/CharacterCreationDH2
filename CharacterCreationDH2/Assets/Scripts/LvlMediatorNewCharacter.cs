using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LvlMediatorNewCharacter
{
    public event Action ReturnToMenu;
    private LvlFactory _lvlFactory;
    private PresenterFactory _presenterFactory;
    private CharacterFactory _characterFactory;
    private ICharacter _character;

    public LvlMediatorNewCharacter(LvlFactory lvlFactory, PresenterFactory presenterFactory, CharacterFactory characterFactory)
    {
        _lvlFactory = lvlFactory;
        _presenterFactory = presenterFactory;
        _characterFactory = characterFactory;
    }

    public void NewCharacter()
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
        canvasIntermediate.OpenIntermediatePanel(OpenHomeworldPanel, "В следующем окне вам нужно выбрать свой родной мир. " +
            "Тип мира будет отражать ваши привычки, вашу внешность и восприятие окружения. " +
            "Так же родной мир определяет сильные и слабые стороны");
    }

    private void OpenHomeworldPanel()
    {
        HomeworldBackGroundRoleView homeworldView = _lvlFactory.Get(TypeScene.Homeworld).GetComponent<HomeworldBackGroundRoleView>();
        HomeworldPresenter homeworldPresenter = (HomeworldPresenter)_presenterFactory.Get(TypeScene.Homeworld);
        homeworldPresenter.ChooseIsDone += CharacterHasHomeworld;
        homeworldPresenter.Initialize(_character, homeworldView);
    }

    private void CharacterHasHomeworld(ICharacter character)
    {
        _character = character;
        ShowMessageBeforeBackground();
    }

    private void ShowMessageBeforeBackground()
    {
        CanvasIntermediate canvasIntermediate = _lvlFactory.Get(TypeScene.Intermediate).GetComponent<CanvasIntermediate>();
        canvasIntermediate.OpenIntermediatePanel(OpenBackgroundPanel, "В следующем окне вам следует выбрать свою предисторию. Кем вы были до того как поступить на службу инквизиции. " +
            "Этот выбор " +
            "повлияет на стартовую экипировку, таланты и склонности");
    }

    private void OpenBackgroundPanel()
    {
        HomeworldBackGroundRoleView homeworldView = _lvlFactory.Get(TypeScene.Background).GetComponent<HomeworldBackGroundRoleView>();
        BackgroundPresenter backgroundPresenter = (BackgroundPresenter)_presenterFactory.Get(TypeScene.Background);
        backgroundPresenter.ChooseIsDone += CharacterHasBackground;
        backgroundPresenter.ReturnToPrevWindow += OpenHomeworldPanel;
        backgroundPresenter.Initialize(_character, homeworldView);
    }

    private void CharacterHasBackground(ICharacter character)
    {
        _character = character;
        ShowMessageBeforeRole();
    }

    private void ShowMessageBeforeRole()
    {
        CanvasIntermediate canvasIntermediate = _lvlFactory.Get(TypeScene.Intermediate).GetComponent<CanvasIntermediate>();
        canvasIntermediate.OpenIntermediatePanel(OpenRoleCanvas, "В следующем окне вам следует выбрать свою роль. Это больше игромеханический выбор в каком направлении " +
            "вы хотите развиваться. Выбор роли влияет на таланты и склонности.");
    }

    private void OpenRoleCanvas()
    {
        HomeworldBackGroundRoleView homeworldView = _lvlFactory.Get(TypeScene.Role).GetComponent<HomeworldBackGroundRoleView>();
        RolePresenter rolePresenter = (RolePresenter)_presenterFactory.Get(TypeScene.Role);
        rolePresenter.ReturnToPrevWindow += OpenBackgroundPanel;
        rolePresenter.ChooseIsDone += CharacterHasRole;
        rolePresenter.Initialize(_character, homeworldView);
    }

    private void CharacterHasRole(ICharacter character)
    {
        _character = character;
        ShowChoiceBetweenManualAndRandom(character);
    }

    private void ShowChoiceBetweenManualAndRandom(ICharacter character)
    {
        CanvasChoiceManulaAndRandom manulaAndRandom = _lvlFactory.Get(TypeScene.ChoiceBetweenManualAndRandom).GetComponent<CanvasChoiceManulaAndRandom>();
        manulaAndRandom.ShowChoose();
        manulaAndRandom.ChooseManual += ShowManual;
        manulaAndRandom.ChoseRandom += ShowRandom;
    }

    private void ShowManual(int startCharacteristic)
    {
        CharacteristicManualView characteristicView = _lvlFactory.Get(TypeScene.ManualCharacteristic).GetComponent<CharacteristicManualView>();
        CharacteristicManualPresenter characteristicPresenter = (CharacteristicManualPresenter)_presenterFactory.Get(TypeScene.ManualCharacteristic);
        characteristicPresenter.ReturnToRole += OpenRoleCanvas;
        characteristicPresenter.ReturnCharacterWithCharacteristics += CharacterHasCharacteristics;
        characteristicPresenter.Initialize(_character, characteristicView, startCharacteristic);
    }

    private void ShowRandom(int startCharacteristic)
    {
        CharacteristicRandomView characteristicRandomView = _lvlFactory.Get(TypeScene.RandomCharacteristic).GetComponent<CharacteristicRandomView>();
        CharacteristicRandomPresenter characteristicRandomPresenter = (CharacteristicRandomPresenter)_presenterFactory.Get(TypeScene.RandomCharacteristic);
        characteristicRandomPresenter.ReturnToRole += OpenRoleCanvas;
        characteristicRandomPresenter.ReturnCharacterWithCharacteristics += CharacterHasCharacteristics;
        characteristicRandomPresenter.Initialize(_character, characteristicRandomView, startCharacteristic);
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
        ShowUpgradeCharacteristics(_character);
    }

    private void ShowUpgradeCharacteristics(ICharacter character)
    {  
        UpgradeCharacteristicsView upgradeCharacteristicsView = _lvlFactory.Get(TypeScene.UpgradeCharacteristic).GetComponent<UpgradeCharacteristicsView>();
        UpgradeCharacteristicsPresenter characteristicsPresenter = (UpgradeCharacteristicsPresenter)_presenterFactory.Get(TypeScene.UpgradeCharacteristic);
        characteristicsPresenter.GoNext += ShowUpgradeSkill;
        characteristicsPresenter.ReturnToPrev += ShowChoiceBetweenManualAndRandom;
        characteristicsPresenter.Initialize(character, upgradeCharacteristicsView, true);
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
            talentPresenter.GoNext += ShowProphecy;
    }

    private void ShowPsycana(ICharacter character)
    {
        GameObject gameObject = _lvlFactory.Get(TypeScene.UpgradePsycana);
        UpgradePsycanaView upgradePsycana = gameObject.GetComponent<UpgradePsycanaView>();
        PsycanaCreatorView psycanaCreatorView = gameObject.GetComponent<PsycanaCreatorView>();
        UpgradePsycanaPresenter presenter = (UpgradePsycanaPresenter)_presenterFactory.Get(TypeScene.UpgradePsycana);
        presenter.GoNext += ShowProphecy;
        presenter.ReturnToTalent += ShowUpgradeTalent;
        presenter.Initialize(character, psycanaCreatorView, upgradePsycana);
    }

    private void ShowProphecy(ICharacter character)
    {
        _character = character;
        ProphecyView prophecyView = _lvlFactory.Get(TypeScene.Prophecy).GetComponent<ProphecyView>();
        ProphecyPresenter prophecyPresenter = (ProphecyPresenter)_presenterFactory.Get( TypeScene.Prophecy);
        prophecyPresenter.GoNext += ShowChooseName;
        prophecyPresenter.Initialize(prophecyView, character);
    }

    private void ShowChooseName(ICharacter character)
    {
        ChooseNameView chooseNameView = _lvlFactory.Get(TypeScene.Name).GetComponent<ChooseNameView>();
        ChooseNamePresenter namePresenter = (ChooseNamePresenter)_presenterFactory.Get( TypeScene.Name);

        namePresenter.GoNext += TakePictures;
        namePresenter.Initialize(chooseNameView, character);
    }

    private void TakePictures(ICharacter character)
    {
        FirstCharacterSheet firstCharacterSheet = _lvlFactory.Get(TypeScene.FirstPage).GetComponent<FirstCharacterSheet>();
        SecondCharacterSheet secondCharacterSheet = _lvlFactory.Get(TypeScene.SecondPage).GetComponent<SecondCharacterSheet>();
        ThirdCharacterSheet thirdCharacterSheet = _lvlFactory.Get(TypeScene.ThirdPage).GetComponent<ThirdCharacterSheet>();

        firstCharacterSheet.gameObject.SetActive(false);
        secondCharacterSheet.gameObject.SetActive(false);
        thirdCharacterSheet.gameObject.SetActive(false);

        TakePicturesPresenter picturesPresenter = (TakePicturesPresenter)_presenterFactory.Get(TypeScene.Pictures);
        picturesPresenter.WorkIsFinished += SaveCharacterAndExit;
        picturesPresenter.Initialize(firstCharacterSheet, secondCharacterSheet, thirdCharacterSheet, character);
    }

    private void SaveCharacterAndExit(ICharacter character)
    {
        new Save(character);
        ReturnToMenu?.Invoke();
    }

}
