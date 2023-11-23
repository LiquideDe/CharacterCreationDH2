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
        character.AddTalent(new Talent("������������"));
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
        Debug.Log($"�����");
        Application.OpenURL((Application.dataPath) + "/StreamingAssets/CharacterSheets");
        Application.Quit();
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

    private void ShowMessageBeforeBackstory()
    {
        canvasIntermediate.gameObject.SetActive(true);
        canvasIntermediate.OpenIntermediatePanel(OpenBackgroundsCanvas, "� ��������� ���� ��� ������� ������� ���� �����������. ��� �� ���� �� ���� ��� ��������� �� ������ ����������. ���� ����� " +
            "�������� �� ��������� ����������, ������� � ����������");
    }

    private void ShowMessageBeforeRole()
    {
        canvasIntermediate.gameObject.SetActive(true);
        canvasIntermediate.OpenIntermediatePanel(OpenRoleCanvas, "� ��������� ���� ��� ������� ������� ���� ����. ��� ������ ���������������� ����� � ����� ����������� �� ������ �����������. " +
            "����� ���� ������ �� ������� � ����������.");
    }

    private void ShowMessageBeforeGenerate()
    {
        canvasIntermediate.gameObject.SetActive(true);
        canvasIntermediate.OpenIntermediatePanel(GenerateCharacteristic, "� ��������� ���� ��� ����� ������� 2 ������ � 10 ������ � �������� ���������. " +
            "�� ����� ������ ������ �� ������ ������, �� ��� ����������� ���������, � ����� ����������� ���������� ���������� ���������������.");
    }

    private void ShowMessageBeforeTrainingCharacteristics()
    {
        canvasIntermediate.gameObject.SetActive(true);
        canvasIntermediate.OpenIntermediatePanel(TrainingCharacteristics, "� ��������� ���� ����� �� ������ ��������� ���������: ��� �������� 1000 ����� �����, ������� ����� ��������� ��� �� " +
            "��������� ������������, ��� � �� ������ � �������. �� ������ �������� ������������� ����� ����. ������ �� ����� �������������, �� ������� ��������� ��������� � ����� �����.");
    }
}
