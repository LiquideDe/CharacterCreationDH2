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
        canvasIntermediate.OpenIntermediatePanel(ShowMessageBeforeWorld, "��� ����� ������ �����������. ��� ��� ����� ����� ��������� ��������� ��������� �� ������� ����� �����. " +
            "����� ����� �� ������������� ��� �������������, � ����� ����� ������������ ����� �� ���������� ��������� �����. " +
            "�� � ������� ����, ������� ��������������  ����������� Ҹ���� ��� ����������. " +
            "�� � ������� ���������, �������� ������ ���� �������� � ������ ������ ���, � ������� ������� ������� ��-���������� �� ����. " +
            "���� ��������� � ����� ������� � ������ ���� ����� �� ���������� ����������. ��� ������ ���� ��� ����� �������� � �������� ������, ������� ����� ����������. " +
            "��� ������� � ��� ��������. �������� � ���������� ���������� � �����, ��� ���� ������ ����� ������, ��� ��� ������� �� ����� ������� �����. " +
            "�������� �� ��������� ��������� � ���������������, ��� � ������������� ����� �������� ���� ������ �����. ��� ���� ����� �����, ���� ���� �������� ����� � ����� ��� ���� ����������� �����.");
    }

    private void ShowMessageBeforeWorld()
    {
        canvasIntermediate.gameObject.SetActive(true);
        canvasIntermediate.OpenIntermediatePanel(OpenHomeWorldCanvas, "� ��������� ���� ��� ����� ������� ���� ������ ���. ��� ���� ����� �������� ���� ��������, ���� ��������� � ���������� ����. " +
            "��� �� ������ ��� ���������� ������� � ������ �������");
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
        canvasIntermediate.OpenIntermediatePanel(OpenBackgroundsCanvas, "� ��������� ���� ��� ������� ������� ���� �����������. ��� �� ���� �� ���� ��� ��������� �� ������ ����������. ���� ����� " +
            "�������� �� ��������� ����������, ������� � ����������");
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
        canvasIntermediate.OpenIntermediatePanel(OpenRoleCanvas, "� ��������� ���� ��� ������� ������� ���� ����. ��� ������ ���������������� ����� � ����� ����������� �� ������ �����������. " +
            "����� ���� ������ �� ������� � ����������.");
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
        canvasIntermediate.OpenIntermediatePanel(OpenSliderWithAverageForManual, "� ��������� ���� ��� ����� ������� ��������� ������� �������������. ��� ��� ���� ��� ������ ��������� ������� � �������. " +
            "������ ��������� ������� ������������ � �������� ����");
    }
    private void ShowMessageBeforeAverageForRandom()
    {
        canvasIntermediate.gameObject.SetActive(true);
        canvasIntermediate.OpenIntermediatePanel(OpenSliderWithAverageForRandom, "� ��������� ���� ��� ����� ������� ��������� ������� �������������. ��� ��� ���� ��� ������ ��������� ������� � �������. " +
            "������ ��������� ������� ������������ � �������� ����");
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
        canvasIntermediate.OpenIntermediatePanel(OpenManualCharacteristic, "� ��������� ���� ��� ����� ������������ 60 ����� �� ������������ �������");
    }
    private void ShowMessageBeforeGenerate(int lvl)
    {
        averageLvl = lvl;
        canvasIntermediate.gameObject.SetActive(true);
        canvasIntermediate.OpenIntermediatePanel(OpenGenerateCharacteristic, "� ��������� ���� ��� ����� ������� 2 ������ � 10 ������ � �������� ���������. " +
            "�� ����� ������ ������ �� ������ ������, �� ��� ����������� ���������, � ����� ����������� ���������� ���������� ���������������.");
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
        canvasIntermediate.OpenIntermediatePanel(Training, "� ��������� ���� ����� �� ������ ��������� ���������: ��� �������� 1000 ����� �����, ������� ����� ��������� ��� �� " +
            "��������� ������������, ��� � �� ������ � �������. �� ������ �������� ������������� ����� ����. ������ �� ����� �������������, �� ������� ��������� ��������� � ����� �����.");
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
