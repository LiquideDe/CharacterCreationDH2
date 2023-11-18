using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGame : MonoBehaviour
{
    private CreatorWorlds creatorWorlds;
    private CreatorBackgrounds creatorBackgrounds;
    private CreatorRole creatorRole;

    private HomeWorldVisual homeWorldVisual;
    private BackGroundVisual backVisual;
    private RoleVisual roleVisual;
    [SerializeField] GameObject homeWorldCanvas, backgroundCanvas, roleCanvas, characteristicGenerateCanvas, characteristicPanelCanvas, skillPanelCanvas;
    private Character character;
    private void Start()
    {
        character = new Character();
        SetCharNewAmounts();
        /*
        creatorWorlds = new CreatorWorlds();
        var visualHomeworld = Instantiate(homeWorldCanvas);
        homeWorldVisual = visualHomeworld.GetComponent<HomeWorldVisual>();
        homeWorldVisual.RegDelegate(ShowNextWorld, ShowPrevWorld);
        homeWorldVisual.regFinalDelegate(FinishChooseWorld);
        ShowNextWorld();*/

        /*
        creatorBackgrounds = new CreatorBackgrounds();
        var visualBack = Instantiate(backgroundCanvas);
        backVisual = visualBack.GetComponent<BackGroundVisual>();
        backVisual.RegDelegate(ShowNextBack, ShowPrevBack);
        backVisual.regFinalDelegate(FinishChooseBackGround);
        ShowNextBack();*/

        /*
        creatorRole = new CreatorRole();
        var visualRole = Instantiate(roleCanvas);
        roleVisual = visualRole.GetComponent<RoleVisual>();
        roleVisual.RegDelegate(ShowNextRole, ShowPrevRole);
        roleVisual.regFinalDelegate(FinishChooseRole);
        ShowNextRole();
        */

        TrainingCharacteristics();
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
        //Создание формы для распределения сгенерированных значений
        
         /*
        GameObject gameObject = Instantiate(characteristicGenerateCanvas);
        var generateCanvas = gameObject.GetComponent<CharacteristicGenerateCanvas>();
        generateCanvas.RegDelegateFinish(FinishGenerateCharacteristics);
        generateCanvas.GenerateCharacteristics(character);*/

        
    }

    private void FinishChooseBackGround(Background background)
    {
        character.SetBackground(background);
    }

    private void FinishChooseRole(Role role)
    {
        character.SetRole(role);
    }

    private void FinishGenerateCharacteristics(List<Characteristic> characteristics)
    {
        character.UpdateCharacteristics(characteristics);
        //Создание формы для распределения очков. Здесь Характеристики
        
    }

    private void TrainingCharacteristics()
    {

        
        /*----------------------------------------------*/
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
        characteristicCanvas.RegDelegate(TrainingTalents, TrainingCharacteristics);
    }

    private void TrainingTalents()
    {

    }

    private void SetCharNewAmounts()
    {
        character.Inclinations.Add(GameStat.Inclinations.Agility);
        character.Inclinations.Add(GameStat.Inclinations.Ballistic);
        character.UpgradeSkill(new Skill( GameStat.SkillName.Psyniscience,2));
        int k = 3;
        foreach (Characteristic characteristic in character.Characteristics)
        {
            characteristic.Amount = 35 + k;
            k += 2;
        }
    }

}
