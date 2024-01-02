using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingClass : MonoBehaviour
{
    public delegate void FinishTraining();
    private CanvasTrainingChar characteristicPanel;
    private SkillTrainingCanvas skillTrainingCanvas;
    private TalentTrainingCanvas talentTrainingCanvas;
    private PsyCanvas psyCanvas;
    private CreatorPsyPowers creatorPsyPowers;
    private Character character;
    private FinishTraining finishTraining;
    private CreatorTalents creatorTalents;

    public void RegDelegate(FinishTraining finishTraining)
    {
        this.finishTraining = finishTraining;
    }
    public void Finish()
    {
        finishTraining?.Invoke();     
        Destroy(this);
    }

    public void LoadVideo(GameObject video)
    {
        GameObject videoPlayer = Instantiate(video);
        videoPlayer.SetActive(true);
    }
    public void OpenTraining(CanvasTrainingChar characteristicPanel, SkillTrainingCanvas skillTrainingCanvas, TalentTrainingCanvas talentTrainingCanvas, PsyCanvas psyCanvas, Character character, 
        CreatorTalents creatorTalents)
    {
        this.characteristicPanel = characteristicPanel;
        this.skillTrainingCanvas = skillTrainingCanvas;
        this.talentTrainingCanvas = talentTrainingCanvas;
        this.psyCanvas = psyCanvas;
        this.character = character;
        this.creatorTalents = creatorTalents;
        creatorPsyPowers = new CreatorPsyPowers(character.PsyPowers);
        OpenCharacteristicTraining();        
    }

    private void OpenCharacteristicTraining()
    {
        CanvasTrainingChar charPanel = Instantiate(characteristicPanel);
        charPanel.gameObject.SetActive(true);
        charPanel.ShowCharacteristicPanels(character);
        charPanel.RegDelegate(OpenSkillTraining);
    }

    private void OpenSkillTraining()
    {
        SkillTrainingCanvas skillTraining = Instantiate(skillTrainingCanvas);
        skillTraining.gameObject.SetActive(true);
        skillTraining.CreatePanels(character);
        skillTraining.RegDelegates(OpenTalentTraining, OpenCharacteristicTraining);
    }

    private void OpenTalentTraining()
    {
        TalentTrainingCanvas talentTraining = Instantiate(talentTrainingCanvas);
        
        if (character.PsyRating > 0)
        {
            talentTraining.RegDelegates(OpenSkillTraining, OpenTrainingPsy);
            talentTraining.ShowTalentPanels(character, creatorTalents,false);
        }
        else
        {
            talentTraining.RegDelegates(OpenSkillTraining, Finish);
            talentTraining.ShowTalentPanels(character, creatorTalents,true);
        }
    }

    private void OpenTrainingPsy()
    {
        PsycanaObserver psycanaObserver = gameObject.AddComponent<PsycanaObserver>();
        psycanaObserver.RegDelegate(OpenTalentTraining, Finish);
        psycanaObserver.ShowPsyPowers(psyCanvas, creatorPsyPowers, character);
    }
    

}
