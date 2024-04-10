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
    bool isNBpush;
    AudioWork audioWork;

    public void ShowPsyPowers(PsyCanvas psyCanvas, CreatorPsyPowers creatorPsyPowers, Character character, AudioWork audioWork,bool isEdit = false)
    {
        this.audioWork = audioWork;
        this.psyCanvas = psyCanvas;
        this.creatorPsyPowers = creatorPsyPowers;
        this.character = character;
        this.isEdit = isEdit;
        psycana = Instantiate(psyCanvas);
        psycana.gameObject.SetActive(true);
        psycana.RegDelegate(CheckReqForPsyPower, GetPsyPower, SetNewPsyLvl);
        psycana.RegDelegateNextPrev(NextPsySchool, PrevPsySchool);
        psycana.SetAudio(audioWork);
        psycana.CreatePsyPanels(creatorPsyPowers.GetPowers(0), creatorPsyPowers.GetConnections(0), 0, character.ExperienceUnspent, character.PsyRating,
            creatorPsyPowers.GetNameSchool(0), creatorPsyPowers.GetSizeSpacing(0),false, isEdit);        
    }

    public void RegDelegate(PrevPage prevPage, NextPage nextPage)
    {
        this.prevPage = prevPage;
        this.nextPage = nextPage;
    }

    private void NextPsySchool(int prevSchool, PsyCanvas psycana)
    {
        if (!isNBpush && psycana.IsDone)
        {
            audioWork.PlayClick();
            isNBpush = true;
            StartCoroutine(Next(prevSchool, psycana));
        }        
    }

    IEnumerator Next(int prevSchool, PsyCanvas psycana)
    {
        yield return new WaitForSeconds(0.1f);
        Coroutine clear = StartCoroutine(psycana.ClearLists());
        yield return clear;
        if (prevSchool + 1 < creatorPsyPowers.CountSchools())
        {
            bool isFinal = false;
            if (prevSchool + 1 == creatorPsyPowers.CountSchools() - 1)
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
        yield return new WaitForEndOfFrame();
        isNBpush = false;
    }

    private void PrevPsySchool(int prevSchool, PsyCanvas psycana)
    {        
        if (!isNBpush && psycana.IsDone)
        {
            audioWork.PlayClick();
            isNBpush = true;
            StartCoroutine(Prev(prevSchool, psycana));
        }        
    }

    IEnumerator Prev(int prevSchool, PsyCanvas psycana)
    {
        yield return new WaitForSeconds(0.1f);
        Coroutine clear = StartCoroutine(psycana.ClearLists());
        yield return clear;
        if (prevSchool - 1 >= 0)
        {
            
            psycana.CreatePsyPanels(creatorPsyPowers.GetPowers(prevSchool - 1), creatorPsyPowers.GetConnections(prevSchool - 1), prevSchool - 1, character.ExperienceUnspent,
                character.PsyRating, creatorPsyPowers.GetNameSchool(prevSchool - 1), creatorPsyPowers.GetSizeSpacing(prevSchool - 1), false, isEdit);
            isNBpush = false;
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
            audioWork.PlayDone();
            PsyPower psyPower = creatorPsyPowers.GetPsyPowerById(school, id);
            character.AddPsyPower(psyPower, isEdit);
            return true;
        }
        else
        {
            audioWork.PlayWarning();
            return false;
        }
    }

    private void SetNewPsyLvl(PsyCanvas psyCanvas)
    {
        if (character.UpgradePsyRate(isEdit))
        {
            audioWork.PlayDone();
            psyCanvas.UpdateTextPsyRate(character.PsyRating);
            psyCanvas.UpdateText(character.ExperienceUnspent);
        }
        else
        {
            audioWork.PlayWarning();
        }
    }

}
