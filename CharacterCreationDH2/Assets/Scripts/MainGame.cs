using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class MainGame : MonoBehaviour
{    
    private CreatorSkills creatorSkills;
    private CreatorTalents creatorTalents;
    private CreatorEquipment creatorEquipment;
    private Character character;
    public delegate void ExitToMenu();
    ExitToMenu exitToMenu;
    int averageLvl;
    [SerializeField] private BackGroundVisual backVisual;
    [SerializeField] private RoleVisual roleVisual;
    [SerializeField] private HomeWorldVisual homeWorldVisual;
    [SerializeField] private CharacteristicGenerateCanvas characteristicGenerateCanvas;
    [SerializeField] private CanvasTrainingChar charTrainingCanvas;
    [SerializeField] private SkillTrainingCanvas skillTrainingCanvas;
    [SerializeField] private TalentTrainingCanvas talentTrainingCanvas;
    [SerializeField] private PsyCanvas psyCanvas;
    [SerializeField] private ProphecyCanvas prophecyCanvas;
    [SerializeField] GameObject canvasName;
    [SerializeField] FirstCharacterSheet firstSheet;
    [SerializeField] SecondCharacterSheet secondSheet;
    [SerializeField] CanvasIntermediate canvasIntermediate;
    [SerializeField] ChooseAverageLvl chooseAverageLvl;
    [SerializeField] CanvasChoiceManulaAndRandom chooseManRan;
    [SerializeField] ManualCharacteristic manualCharacteristic;
    [SerializeField] GameObject trainingVideo, trainingVideoPsyker;
    AudioWork audioWork;

    public void ShowMainPanel(ExitToMenu exitToMenu, AudioWork audioWork)
    {
        this.exitToMenu = exitToMenu;
        this.audioWork = audioWork;
        gameObject.SetActive(true);
        creatorSkills = new CreatorSkills();
        creatorTalents = new CreatorTalents();
        creatorEquipment = new CreatorEquipment();
        character = new Character(creatorSkills.Skills, creatorEquipment);
        character.ExperienceUnspent = 1000;

        canvasIntermediate.SetAudio(audioWork);
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

    private void OpenHomeWorldCanvas()
    {
        canvasIntermediate.gameObject.SetActive(false);
        HomeWorldObserver homeWorldObserver = gameObject.AddComponent<HomeWorldObserver>();
        homeWorldObserver.RegDelegate(SetHomeWorldToCharacter);
        homeWorldObserver.OpenHomeWorldCanvas(homeWorldVisual, audioWork);
    }

    private void SetHomeWorldToCharacter(Homeworld homeworld)
    {
        character.SetHomeWorld(homeworld);
        ShowMessageBeforeBackstory();
    }

    private void ShowMessageBeforeBackstory()
    {
        canvasIntermediate.gameObject.SetActive(true);
        canvasIntermediate.OpenIntermediatePanel(OpenBackgroundsCanvas, "В следующем окне вам следует выбрать свою предисторию. Кем вы были до того как поступить на службу инквизиции. Этот выбор " +
            "повлияет на стартовую экипировку, таланты и склонности");
    }

    private void OpenBackgroundsCanvas()
    {
        canvasIntermediate.gameObject.SetActive(false);
        BackgroundObserver backgroundObserver = gameObject.AddComponent<BackgroundObserver>();
        backgroundObserver.RegDelegate(FinishChooseBackground);
        backgroundObserver.OpenBackgroundCanvas(backVisual, creatorSkills, creatorTalents, audioWork);
    }

    private void FinishChooseBackground(Background background)
    {
        character.SetBackground(background);
        ShowMessageBeforeRole();
    }

    private void ShowMessageBeforeRole()
    {
        canvasIntermediate.gameObject.SetActive(true);
        canvasIntermediate.OpenIntermediatePanel(OpenRoleCanvas, "В следующем окне вам следует выбрать свою роль. Это больше игромеханический выбор в каком направлении вы хотите развиваться. " +
            "Выбор роли влияет на таланты и склонности.");
    }

    private void OpenRoleCanvas()
    {
        canvasIntermediate.gameObject.SetActive(false);
        RoleObserver roleObserver = gameObject.AddComponent<RoleObserver>();
        roleObserver.RegDelegate(FinishChooseRole);
        roleObserver.OpenRoleCanvas(roleVisual, creatorTalents, audioWork);
    }
    private void FinishChooseRole(Role role)
    {
        character.SetRole(role);
        ShowChoiceBetweenManualAndRandom();
    }

    private void ShowChoiceBetweenManualAndRandom()
    {
        CanvasChoiceManulaAndRandom manulaAndRandom = Instantiate(chooseManRan);
        manulaAndRandom.ShowChoose(ShowMessageBeforeAverageForManual, ShowMessageBeforeAverageForRandom, audioWork);
    }

    private void ShowMessageBeforeAverageForManual()
    {
        canvasIntermediate.gameObject.SetActive(true);
        canvasIntermediate.OpenIntermediatePanel(OpenSliderWithAverageForManual, "В следующем окне вам нужно выбрать стартовый уровень характеристик. Чем они выше тем аколит считается сильнее и опытнее. " +
            "Обычно стартовый уровень обговаривает с Мастером Игры");
    }
    private void ShowMessageBeforeAverageForRandom()
    {
        canvasIntermediate.gameObject.SetActive(true);
        canvasIntermediate.OpenIntermediatePanel(OpenSliderWithAverageForRandom, "В следующем окне вам нужно выбрать стартовый уровень характеристик. Чем они выше тем аколит считается сильнее и опытнее. " +
            "Обычно стартовый уровень обговаривает с Мастером Игры");
    }

    private void OpenSliderWithAverageForManual()
    {
        canvasIntermediate.gameObject.SetActive(false);
        ChooseAverageLvl AverageLvl = Instantiate(chooseAverageLvl);
        AverageLvl.ShowChooseAverage(ShowMessageBeforeManual, audioWork);
    }
    private void OpenSliderWithAverageForRandom()
    {
        canvasIntermediate.gameObject.SetActive(false);
        ChooseAverageLvl AverageLvl = Instantiate(chooseAverageLvl);
        AverageLvl.ShowChooseAverage(ShowMessageBeforeGenerate, audioWork);
    }
    private void ShowMessageBeforeManual(int lvl)
    {
        averageLvl = lvl;
        canvasIntermediate.gameObject.SetActive(true);
        canvasIntermediate.OpenIntermediatePanel(OpenManualCharacteristic, "В следующем окне вам нужно распределить 60 очков по собственному желанию");
    }
    private void ShowMessageBeforeGenerate(int lvl)
    {
        averageLvl = lvl;
        canvasIntermediate.gameObject.SetActive(true);
        canvasIntermediate.OpenIntermediatePanel(OpenGenerateCharacteristic, "В следующем окне вам нужно бросить 2 кубика в 10 граней и записать результат. " +
            "Вы также можете нажать на кнопку кубика, он сам сгенерирует результат, а затем переставить полученные результаты характеристикам.");
    }
    
    private void OpenGenerateCharacteristic()
    {
        canvasIntermediate.gameObject.SetActive(false);
        GenerateObserver generateObserver = gameObject.AddComponent<GenerateObserver>();
        generateObserver.RegDelegate(FinishGenerateCharacteristics);
        generateObserver.OpenGenerateCharacteristic(characteristicGenerateCanvas, character, averageLvl, audioWork);
    }

    private void OpenManualCharacteristic()
    {
        canvasIntermediate.gameObject.SetActive(false);
        ManualCharacteristic manul = Instantiate(manualCharacteristic);
        manul.ShowManual(ShowMessageBeforeTrainingCharacteristics, character, averageLvl, audioWork);
    }

    private void FinishGenerateCharacteristics(List<Characteristic> characteristics)
    {
        character.UpdateCharacteristics(characteristics);
        ShowMessageBeforeTrainingCharacteristics();
    }

    private void ShowMessageBeforeTrainingCharacteristics()
    {
        canvasIntermediate.gameObject.SetActive(true);
        canvasIntermediate.OpenIntermediatePanel(Training, "В следующих трех окнах вы можете прокачать персонажа: вам доступно 1000 Очков Опыта, которые можно потратить как на " +
            "улучшение храктеристик, так и на навыки и таланты. Вы можете свободно переключаться между ними. Наведя на шкалу интенсивности, вы увидите стоимость улучшения в очках опыта.");
    }

    private void Training()
    {
        canvasIntermediate.gameObject.SetActive(false);
        TrainingClass trainingClass = gameObject.AddComponent<TrainingClass>();
        trainingClass.RegDelegate(GoToProphecy);
        trainingClass.OpenTraining(charTrainingCanvas, skillTrainingCanvas, talentTrainingCanvas, psyCanvas, character, creatorTalents, audioWork);
        if(character.PsyRating > 0)
        {
            trainingClass.LoadVideo(trainingVideoPsyker);
        }
        else
        {
            trainingClass.LoadVideo(trainingVideo);
        }
    }

    private void GoToProphecy()
    {
        ProphecyCanvas prophecy = Instantiate(prophecyCanvas);
        prophecy.gameObject.SetActive(true);
        prophecy.RegDelegate(InputName);
        prophecy.StartChoose(character, audioWork);
    }

    private void InputName()
    {
        GameObject gO = Instantiate(canvasName);
        gO.SetActive(true);
        CanvasName canName = gO.GetComponent<CanvasName>();
        canName.RegDelegate(PasteName, audioWork);
    }

    private void PasteName(string name, string gender)
    {
        character.Name = name;
        character.SetGender(gender);
        Save save = new Save(character);
        ScreenshotObserver screenshotObserver = gameObject.AddComponent<ScreenshotObserver>();
        screenshotObserver.RegDelegate(EndGame);
        screenshotObserver.OpenScreenShots(character, firstSheet, secondSheet);
    }    

    private void EndGame()
    {
        audioWork.PlayClick();
        StartCoroutine(ExitGame());
    }

    IEnumerator ExitGame()
    {
        yield return new WaitForSeconds(0.1f);        
        exitToMenu?.Invoke();
        Destroy(gameObject);
    }
}
