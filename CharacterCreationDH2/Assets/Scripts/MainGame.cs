using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainGame : MonoBehaviour
{
    private CreatorWorlds creatorWorlds;
    private CreatorBackgrounds creatorBackgrounds;
    private CreatorRole creatorRole;

    private HomeWorldVisual homeWorldVisual;
    private BackGroundVisual backVisual;
    private RoleVisual roleVisual;
    [SerializeField] GameObject homeWorldCanvas, backgroundCanvas, roleCanvas, characteristicGenerateCanvas, characteristicPanelCanvas, 
        skillPanelCanvas, talentTrainingCanvas, firstSheet, secondSheet, canvasName;
    [SerializeField] CanvasIntermediate canvasIntermediate;
    private Character character;
    private GameObject tempGameobject;
    private void Start()
    {
        character = new Character();
        ShowMainPanel();
    }

    public void OpenHomeWorldCanvas()
    {
        canvasIntermediate.gameObject.SetActive(false);
        creatorWorlds = new CreatorWorlds();
        var visualHomeworld = Instantiate(homeWorldCanvas);
        homeWorldVisual = visualHomeworld.GetComponent<HomeWorldVisual>();
        homeWorldVisual.RegDelegate(ShowNextWorld, ShowPrevWorld);
        homeWorldVisual.regFinalDelegate(FinishChooseWorld);
        ShowNextWorld();
    }

    public void OpenBackgroundsCanvas()
    {
        canvasIntermediate.gameObject.SetActive(false);
        creatorBackgrounds = new CreatorBackgrounds();
        var visualBack = Instantiate(backgroundCanvas);
        backVisual = visualBack.GetComponent<BackGroundVisual>();
        backVisual.RegDelegate(ShowNextBack, ShowPrevBack);
        backVisual.regFinalDelegate(FinishChooseBackGround);
        ShowNextBack();
    }

    public void OpenRoleCanvas()
    {
        canvasIntermediate.gameObject.SetActive(false);
        creatorRole = new CreatorRole();
        var visualRole = Instantiate(roleCanvas);
        roleVisual = visualRole.GetComponent<RoleVisual>();
        roleVisual.RegDelegate(ShowNextRole, ShowPrevRole);
        roleVisual.regFinalDelegate(FinishChooseRole);
        ShowNextRole();
    }

    private void ShowNextWorld()
    {
        homeWorldVisual.ShowWorld(creatorWorlds.GetNextWorld());
    }

    private void ShowPrevWorld()
    {
        homeWorldVisual.ShowWorld(creatorWorlds.GetPrevWorld());
    }

    private void ShowNextBack()
    {
        backVisual.ShowBackground(creatorBackgrounds.GetNextBack());
    }

    private void ShowPrevBack()
    {
        backVisual.ShowBackground(creatorBackgrounds.GetPrevBack());
    }
    
    private void ShowNextRole()
    {
        roleVisual.ShowRole(creatorRole.GetNextRole());
    }

    private void ShowPrevRole()
    {
        roleVisual.ShowRole(creatorRole.GetPrevRole());
    }

    private void FinishChooseWorld(Homeworld world)
    {
        character.SetHomeWorld(world);
        ShowMessageBeforeBackstory();
    }

    private void FinishChooseBackGround(Background background)
    {
        character.SetBackground(background);
        ShowMessageBeforeRole();
    }

    private void FinishChooseRole(Role role)
    {
        character.SetRole(role);
        ShowMessageBeforeGenerate();
    }

    private void FinishGenerateCharacteristics(List<Characteristic> characteristics)
    {
        character.UpdateCharacteristics(characteristics);
        ShowMessageBeforeTrainingCharacteristics();
    }

    public void GenerateCharacteristic()
    {
        canvasIntermediate.gameObject.SetActive(false);
        GameObject gameObject = Instantiate(characteristicGenerateCanvas);
        var generateCanvas = gameObject.GetComponent<CharacteristicGenerateCanvas>();
        generateCanvas.RegDelegateFinish(FinishGenerateCharacteristics);
        generateCanvas.GenerateCharacteristics(character);
    }

    private void TrainingCharacteristics()
    {
        canvasIntermediate.gameObject.SetActive(false);
        GameObject gO = Instantiate(characteristicPanelCanvas);
        gO.SetActive(true);
        var characteristicCanvas = gO.GetComponent<CanvasTrainingChar>();
        characteristicCanvas.CreatePanels(character);
        characteristicCanvas.RegDelegate(TrainingSkill);
    }

    private void TrainingSkill()
    {
        GameObject gO = Instantiate(skillPanelCanvas);
        gO.SetActive(true);
        var characteristicCanvas = gO.GetComponent<SkillTrainingCanvas>();
        characteristicCanvas.CreatePanels(character);
        characteristicCanvas.RegDelegates(TrainingTalents, TrainingCharacteristics);
    }

    private void TrainingTalents()
    {
        
        GameObject gO = Instantiate(talentTrainingCanvas);
        gO.SetActive(true);
        var talentTraining = gO.GetComponent<TalentTrainingCanvas>();
        talentTraining.CreateTalentPanels(character);
        talentTraining.RegDelegates(TrainingSkill, GoToProphecy);
    }

    private void SetCharNewAmounts()
    {
        character.AddInclination(GameStat.Inclinations.Agility);
        character.AddInclination(GameStat.Inclinations.Ballistic);
        character.UpgradeSkill(new Skill( GameStat.SkillName.Psyniscience,2));
        character.AddTalent(new Talent("Амбидекстрия"));
        int k = 3;

        foreach (Characteristic characteristic in character.Characteristics)
        {
            characteristic.Amount = 35 + k;
            k += 2;
        }
    }

    private void GoToProphecy()
    {
        Prophecy prophecy = new Prophecy();
        character.Prophecy = prophecy.GenerateProphecy(character);
        character.CalculatePhysAbilities();
        Destroy(canvasIntermediate.gameObject);
        InputName();
    }

    private void InputName()
    {
        GameObject gO = Instantiate(canvasName);
        gO.SetActive(true);
        CanvasName canName = gO.GetComponent<CanvasName>();
        canName.RegDelegate(PasteName);
    }

    private void PasteName(string name)
    {
        character.Name = name;
        TakeScreenshotFirst();
    }

    private void TakeScreenshotFirst()
    {
        tempGameobject = Instantiate(firstSheet);
        tempGameobject.SetActive(true);
        FirstCharacterSheet characterSheet = tempGameobject.GetComponentInChildren<FirstCharacterSheet>();
        characterSheet.RegDelegate(TakePause);
        characterSheet.FillCharacterSheet(character);
    }

    private void TakePause()
    {
        Destroy(tempGameobject);
        StartCoroutine(TakeScreenshotSecond());
    }

    IEnumerator TakeScreenshotSecond()
    {
        yield return new WaitForSeconds(0.7f);
        GameObject gO = Instantiate(secondSheet);
        gO.SetActive(true);
        SecondCharacterSheet secondCharacter = gO.GetComponentInChildren<SecondCharacterSheet>();
        secondCharacter.RegDelegate(EndGame);
        secondCharacter.OpenSecondSheet(character);
    }

    private void EndGame()
    {
        StartCoroutine(ExitGame());
    }

    IEnumerator ExitGame()
    {
        yield return new WaitForSeconds(0.1f);
        Debug.Log($"Вышли");
        Application.OpenURL((Application.dataPath) + "/StreamingAssets/CharacterSheets");
        Application.Quit();
    }
    private void ShowMainPanel()
    {
        canvasIntermediate.gameObject.SetActive(true);
        canvasIntermediate.OpenIntermediatePanel(ShowMessageBeforeWorld, "Это сорок первое тысячелетие. Вот уже сотню веков Император недвижимо восседает на Золотом троне Земли. " +
            "Волей богов он владычествует над человечеством, и мощью своих неисчислимых армий он повелевает миллионом миров. " +
            "Он – гниющий труп, незримо поддерживаемый  могуществом Тёмной эры технологий. " +
            "Он – Великий падальщик, которому каждый день приносят в жертву тысячу душ, и которой поэтому никогда по-настоящему не умрёт. " +
            "Быть человеком в такие времена – значит быть одним из бессчётных миллиардов. Это значит жить при самом жестоком и кровавом режиме, который можно вообразить. " +
            "Эта история о тех временах. Забудьте о могуществе технологии и науки, ибо было забыто столь многое, что уже никогда не будет открыто вновь. " +
            "Забудьте об обещаниях прогресса и взаимопонимания, ибо в беспросветном мраке будущего есть только война. Нет мира среди звезд, есть лишь вечность бойни и резни под смех кровожадных богов.");
    }

    private void ShowMessageBeforeWorld()
    {
        canvasIntermediate.gameObject.SetActive(true);
        canvasIntermediate.OpenIntermediatePanel(OpenHomeWorldCanvas, "В следующем окне вам нужно выбрать свой родной мир. Тип мира будет отражать ваши привычки, вашу внешность и восприятие мира. " +
            "Так же родной мир определяет сильные и слабые стороны");
    }

    private void ShowMessageBeforeBackstory()
    {
        canvasIntermediate.gameObject.SetActive(true);
        canvasIntermediate.OpenIntermediatePanel(OpenBackgroundsCanvas, "В следующем окне вам следует выбрать свою предисторию. Кем вы были до того как поступить на службу инквизиции. Этот выбор " +
            "повлияет на стартовую экипировку, таланты и склонности");
    }

    private void ShowMessageBeforeRole()
    {
        canvasIntermediate.gameObject.SetActive(true);
        canvasIntermediate.OpenIntermediatePanel(OpenRoleCanvas, "В следующем окне вам следует выбрать свою роль. Это больше игромеханический выбор в каком направлении вы хотите развиваться. " +
            "Выбор роли влияет на таланты и склонности.");
    }

    private void ShowMessageBeforeGenerate()
    {
        canvasIntermediate.gameObject.SetActive(true);
        canvasIntermediate.OpenIntermediatePanel(GenerateCharacteristic, "В следующем окне вам нужно бросить 2 кубика в 10 граней и записать результат. " +
            "Вы также можете нажать на кнопку кубика, он сам сгенерирует результат, а затем переставить полученные результаты характеристикам.");
    }

    private void ShowMessageBeforeTrainingCharacteristics()
    {
        canvasIntermediate.gameObject.SetActive(true);
        canvasIntermediate.OpenIntermediatePanel(TrainingCharacteristics, "В следующих трех окнах вы можете прокачать персонажа: вам доступно 1000 Очков Опыта, которые можно потратить как на " +
            "улучшение храктеристик, так и на навыки и таланты. Вы можете свободно переключаться между ними. Наведя на шкалу интенсивности, вы увидите стоимость улучшения в очках опыта.");
    }
}
