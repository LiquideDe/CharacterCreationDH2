using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PsycanaObserver : MonoBehaviour
{
    public delegate void PrevPage();
    public delegate void NextPage();
    PrevPage prevPage;
    NextPage nextPage;
    private PsyCanvas psyCanvas, psycana;
    private CreatorPsyPowers creatorPsyPowers;
    private Character character;
    bool isEdit;

    public void ShowPsyPowers(PsyCanvas psyCanvas, CreatorPsyPowers creatorPsyPowers, Character character, bool isEdit = false)
    {
        this.psyCanvas = psyCanvas;
        this.creatorPsyPowers = creatorPsyPowers;
        this.character = character;
        this.isEdit = isEdit;
        psycana = Instantiate(psyCanvas);
        psycana.gameObject.SetActive(true);
        psycana.CreatePsyPanels(creatorPsyPowers.GetPowers(0), creatorPsyPowers.GetConnections(0), 0, character.ExperienceUnspent, character.PsyRating,
            creatorPsyPowers.GetNameSchool(0), creatorPsyPowers.GetSizeSpacing(0),false, isEdit);
        psycana.RegDelegate(CheckReqForPsyPower, GetPsyPower, SetNewPsyLvl);
        psycana.RegDelegateNextPrev(NextPsySchool, PrevPsySchool);
    }

    public void RegDelegate(PrevPage prevPage, NextPage nextPage)
    {
        this.prevPage = prevPage;
        this.nextPage = nextPage;
    }

    private void NextPsySchool(int prevSchool, PsyCanvas psycana)
    {
        if (prevSchool + 1 < creatorPsyPowers.CountSchools())
        {
            bool isFinal = false;
            if(prevSchool + 1 == creatorPsyPowers.CountSchools() - 1)
            {
                isFinal = true;
            }
            psycana.CreatePsyPanels(creatorPsyPowers.GetPowers(prevSchool + 1), creatorPsyPowers.GetConnections(prevSchool + 1), prevSchool + 1, character.ExperienceUnspent,
                character.PsyRating, creatorPsyPowers.GetNameSchool(prevSchool + 1), creatorPsyPowers.GetSizeSpacing(prevSchool + 1), isFinal, isEdit);
        }
        else
        {
            nextPage?.Invoke();
            Destroy(psycana.gameObject);
            Destroy(this);
        }
    }

    private void PrevPsySchool(int prevSchool, PsyCanvas psycana)
    {
        if (prevSchool - 1 >= 0)
        {
            psycana.CreatePsyPanels(creatorPsyPowers.GetPowers(prevSchool - 1), creatorPsyPowers.GetConnections(prevSchool - 1), prevSchool - 1, character.ExperienceUnspent,
                character.PsyRating, creatorPsyPowers.GetNameSchool(prevSchool - 1), creatorPsyPowers.GetSizeSpacing(prevSchool - 1),false, isEdit);
        }
        else
        {
            Destroy(psycana.gameObject);
            prevPage?.Invoke();
            Destroy(this);
        }
    }

    private PsyPower GetPsyPower(int school, int id)
    {
        return creatorPsyPowers.GetPsyPowerById(school, id);
    }

    private bool CheckReqForPsyPower(int school, int id)
    {
        if (creatorPsyPowers.CheckPowerForAdding(school, id, character) || isEdit)
        {
            PsyPower psyPower = creatorPsyPowers.GetPsyPowerById(school, id);
            character.AddPsyPower(psyPower, isEdit);
            return true;
        }
        else
        {
            return false;
        }
    }

    private void SetNewPsyLvl(PsyCanvas psyCanvas)
    {
        if (character.UpgradePsyRate(isEdit))
        {
            psyCanvas.UpdateTextPsyRate(character.PsyRating);
            psyCanvas.UpdateText(character.ExperienceUnspent);
        }
    }
}
