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
    private CreatorSkills creatorSkills;
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
    public void OpenTraining(CanvasTrainingChar characteristicPanel, SkillTrainingCanvas skillTrainingCanvas, TalentTrainingCanvas talentTrainingCanvas, PsyCanvas psyCanvas, Character character, 
        CreatorSkills creatorSkills, CreatorTalents creatorTalents)
    {
        this.characteristicPanel = characteristicPanel;
        this.skillTrainingCanvas = skillTrainingCanvas;
        this.talentTrainingCanvas = talentTrainingCanvas;
        this.psyCanvas = psyCanvas;
        this.character = character;
        this.creatorSkills = creatorSkills;
        this.creatorTalents = creatorTalents;
        creatorPsyPowers = new CreatorPsyPowers();
        OpenCharacteristicTraining();
    }

    private void OpenCharacteristicTraining()
    {
        CanvasTrainingChar charPanel = Instantiate(characteristicPanel);
        charPanel.gameObject.SetActive(true);
        charPanel.CreatePanels(character);
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
        talentTraining.gameObject.SetActive(true);
        talentTraining.CreateTalentPanels(character, creatorTalents);
        if (character.PsyRating > 0)
        {
            talentTraining.RegDelegates(OpenSkillTraining, OpenTrainingPsy);
        }
        else
        {
            talentTraining.RegDelegates(OpenSkillTraining, Finish);
        }
    }

    private void OpenTrainingPsy()
    {
        PsyCanvas psyTraining = Instantiate(psyCanvas);
        psyTraining.gameObject.SetActive(true);
        psyTraining.CreatePsyPanels(creatorPsyPowers.GetPowers(0), creatorPsyPowers.GetConnections(0), 0, character.ExperienceUnspent, character.PsyRating, 
            creatorPsyPowers.GetNameSchool(0), creatorPsyPowers.GetSizeSpacing(0));
        psyTraining.RegDelegate(CheckReqForPsyPower, GetPsyPower, SetNewPsyLvl);
        psyTraining.RegDelegateNextPrev(NextPsySchool, PrevPsySchool);
    }

    private void NextPsySchool(int prevSchool, PsyCanvas psycana)
    {
        if (prevSchool + 1 < creatorPsyPowers.CountSchools())
        {
            psycana.CreatePsyPanels(creatorPsyPowers.GetPowers(prevSchool + 1), creatorPsyPowers.GetConnections(prevSchool + 1), prevSchool + 1, character.ExperienceUnspent,
                character.PsyRating, creatorPsyPowers.GetNameSchool(prevSchool + 1), creatorPsyPowers.GetSizeSpacing(prevSchool + 1));
        }
        else
        {
            Finish();
        }
    }

    private void PrevPsySchool(int prevSchool, PsyCanvas psycana)
    {
        if (prevSchool - 1 >= 0)
        {
            psycana.CreatePsyPanels(creatorPsyPowers.GetPowers(prevSchool - 1), creatorPsyPowers.GetConnections(prevSchool - 1), prevSchool - 1, character.ExperienceUnspent,
                character.PsyRating, creatorPsyPowers.GetNameSchool(prevSchool - 1), creatorPsyPowers.GetSizeSpacing(prevSchool - 1));
        }
        else
        {
            Destroy(psycana.gameObject);
            OpenTalentTraining();
        }
    }

    private PsyPower GetPsyPower(int school, int id)
    {
        return creatorPsyPowers.GetPsyPowerById(school, id);
    }

    private bool CheckReqForPsyPower(int school, int id)
    {
        if (creatorPsyPowers.CheckPowerForAdding(school, id, character))
        {
            PsyPower psyPower = creatorPsyPowers.GetPsyPowerById(school, id);
            character.AddPsyPower(psyPower);
            return true;
        }
        else
        {
            return false;
        }
    }

    private void SetNewPsyLvl(PsyCanvas psyCanvas)
    {
        if (character.UpgradePsyRate())
        {
            psyCanvas.UpdateTextPsyRate(character.PsyRating);
            psyCanvas.UpdateText(character.ExperienceUnspent);
        }
    }


}
