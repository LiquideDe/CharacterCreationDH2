using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundObserver : MonoBehaviour
{
    public delegate void FinishChooseBackground(Background background);
    private CreatorBackgrounds creatorBackgrounds;
    private BackGroundVisual backVisual;
    private FinishChooseBackground finishChooseBackground;

    public void OpenBackgroundCanvas(BackGroundVisual backVisual, CreatorEquipment creatorEq, CreatorSkills creatorSkills, CreatorTalents creatorTalents)
    {
        creatorBackgrounds = new CreatorBackgrounds(creatorEq);
        this.backVisual = Instantiate(backVisual);
        this.backVisual.RegDelegate(ShowNextBack, ShowPrevBack);
        this.backVisual.regFinalDelegate(FinishChooseBackGround);
        this.backVisual.SetCreators(creatorSkills, creatorTalents);
        ShowNextBack();
    }

    public void RegDelegate(FinishChooseBackground finishChooseBackground)
    {
        this.finishChooseBackground = finishChooseBackground;
    }

    private void FinishChooseBackGround(Background chosenBack)
    {
        finishChooseBackground?.Invoke(chosenBack);
        Destroy(this);
    }

    private void ShowPrevBack()
    {        
        backVisual.ShowBackground(creatorBackgrounds.GetPrevBack());
    }

    private void ShowNextBack()
    {
        Debug.Log($"Следующий");
        backVisual.ShowBackground(creatorBackgrounds.GetNextBack());
    }
}
