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

    [SerializeField] private BackGroundVisual backVisual;
    [SerializeField] private RoleVisual roleVisual;
    [SerializeField] private HomeWorldVisual homeWorldVisual;
    [SerializeField] private CharacteristicGenerateCanvas characteristicGenerateCanvas;
    [SerializeField] private CanvasTrainingChar charTrainingCanvas;
    [SerializeField] private SkillTrainingCanvas skillTrainingCanvas;
    [SerializeField] private TalentTrainingCanvas talentTrainingCanvas;
    [SerializeField] private PsyCanvas psyCanvas;
    [SerializeField] GameObject firstSheet, secondSheet, canvasName;
    [SerializeField] CanvasIntermediate canvasIntermediate;
    private void Start()
    {
        creatorSkills = new CreatorSkills();
        creatorTalents = new CreatorTalents();
        creatorEquipment = new CreatorEquipment();
        character = new Character(creatorSkills.Skills, creatorEquipment);
        CreatorRole creatorRole = new CreatorRole();
        //ShowMainPanel();
        ShowMessageBeforeBackstory();
    }

    private void ShowMainPanel()
    {
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
        homeWorldObserver.OpenHomeWorldCanvas(homeWorldVisual);
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
        backgroundObserver.OpenBackgroundCanvas(backVisual, creatorEquipment, creatorSkills, creatorTalents);
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
        roleObserver.OpenRoleCanvas(roleVisual, creatorTalents);
    }
    private void FinishChooseRole(Role role)
    {
        character.SetRole(role);
        ShowMessageBeforeGenerate();
    }
    private void ShowMessageBeforeGenerate()
    {
        canvasIntermediate.gameObject.SetActive(true);
        canvasIntermediate.OpenIntermediatePanel(OpenGenerateCharacteristic, "� ��������� ���� ��� ����� ������� 2 ������ � 10 ������ � �������� ���������. " +
            "�� ����� ������ ������ �� ������ ������, �� ��� ����������� ���������, � ����� ����������� ���������� ���������� ���������������.");
    }
    
    private void OpenGenerateCharacteristic()
    {
        canvasIntermediate.gameObject.SetActive(false);
        GenerateObserver generateObserver = gameObject.AddComponent<GenerateObserver>();
        generateObserver.RegDelegate(FinishGenerateCharacteristics);
        generateObserver.OpenGenerateCharacteristic(characteristicGenerateCanvas, character);
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
        trainingClass.OpenTraining(charTrainingCanvas, skillTrainingCanvas, talentTrainingCanvas, psyCanvas, character, creatorSkills, creatorTalents);
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
        ScreenshotObserver screenshotObserver = gameObject.AddComponent<ScreenshotObserver>();
        screenshotObserver.RegDelegate(EndGame);
        screenshotObserver.OpenScreenshots(character, firstSheet, secondSheet);
    }    

    private void EndGame()
    {
        StartCoroutine(ExitGame());
    }

    IEnumerator ExitGame()
    {
        yield return new WaitForSeconds(0.1f);
        Debug.Log($"�����");
        Application.OpenURL((Application.dataPath) + "/StreamingAssets/CharacterSheets");
        Application.Quit();
    }
}
