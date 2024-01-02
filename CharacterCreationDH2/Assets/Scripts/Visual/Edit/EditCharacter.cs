using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class EditCharacter : OperationWithCharacter
{
    [SerializeField] CanvasEditMenu editMenu;      

    public void ShowEditMenu(string path)
    {
        InitialCreators(path);
        OpenEditCharacteristics();
    }

    private void OpenEditCharacteristics()
    {
        CanvasEditMenu edMenu = Instantiate(editMenu);
        edMenu.ShowEditor(character, creatorEquipment, OpenEditSkill);
    }
    private void OpenEditSkill()
    {
        SkillTrainingCanvas skillTr = Instantiate(skillTrainingCanvas);
        skillTr.gameObject.SetActive(true);
        skillTr.CreatePanels(character, true);
        skillTr.RegDelegates(OpenEditTalent, OpenEditCharacteristics);
    }

    private void OpenEditTalent()
    {
        TalentTrainingCanvas talentTr = Instantiate(talentTrainingCanvas);
        talentTr.gameObject.SetActive(true);
        talentTr.RegDelegates(OpenEditSkill, OpenEditPsy);
        talentTr.ShowTalentPanels(character, creatorTalents, false, true);        
    }

    private void OpenEditPsy()
    {
        PsycanaObserver psycanaObserver = gameObject.AddComponent<PsycanaObserver>();
        psycanaObserver.RegDelegate(OpenEditTalent, Finish);
        psycanaObserver.ShowPsyPowers(psyCanvas, creatorPsyPowers, character, true);
    }

    

    
}
