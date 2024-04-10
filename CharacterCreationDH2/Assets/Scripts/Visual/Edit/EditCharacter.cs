using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class EditCharacter : OperationWithCharacter
{
    [SerializeField] CanvasEditMenu editMenu;
    [SerializeField] EditPropertyCharacter editProperty;

    public void ShowEditMenu(string path)
    {
        InitialCreators(path);
        OpenEditProperty();
    }

    private void OpenEditProperty()
    {
        var edProp = Instantiate(editProperty);
        edProp.SetParams(character, creatorFeatures, OpenEditCharacteristics, audioWork);
    }

    private void OpenEditCharacteristics()
    {
        CanvasEditMenu edMenu = Instantiate(editMenu);
        edMenu.ShowEditor(character, creatorEquipment, creatorImplant,OpenEditSkill, OpenEditProperty, Finish, audioWork);
    }
    private void OpenEditSkill()
    {
        SkillTrainingCanvas skillTr = Instantiate(skillTrainingCanvas);
        skillTr.gameObject.SetActive(true);
        skillTr.CreatePanels(character, audioWork,true);
        skillTr.RegDelegates(OpenEditTalent, OpenEditCharacteristics);
    }

    private void OpenEditTalent()
    {
        TalentTrainingCanvas talentTr = Instantiate(talentTrainingCanvas);
        talentTr.gameObject.SetActive(true);
        talentTr.RegDelegates(OpenEditSkill, OpenEditPsy);
        talentTr.ShowTalentPanels(character, creatorTalents, false,audioWork, true);        
    }

    private void OpenEditPsy()
    {
        PsycanaObserver psycanaObserver = gameObject.AddComponent<PsycanaObserver>();
        psycanaObserver.RegDelegate(OpenEditTalent, Finish);
        psycanaObserver.ShowPsyPowers(psyCanvas, creatorPsyPowers, character, audioWork,true);
    }

    

    
}
