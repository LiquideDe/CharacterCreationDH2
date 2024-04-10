using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeWorldObserver : MonoBehaviour
{
    public delegate void FinishChooseWorld(Homeworld world);
    private CreatorWorlds creatorWorlds;
    private HomeWorldVisual homeWorldVisual;
    private FinishChooseWorld finishChooseWorld;

    public void OpenHomeWorldCanvas(HomeWorldVisual homeWorldVisual, AudioWork audioWork)
    {
        creatorWorlds = new CreatorWorlds();
        this.homeWorldVisual = Instantiate(homeWorldVisual);
        this.homeWorldVisual.RegDelegate(ShowNextWorld, ShowPrevWorld);
        this.homeWorldVisual.regFinalDelegate(Finish);
        this.homeWorldVisual.SetAudio(audioWork);
        ShowNextWorld();
    }

    public void RegDelegate(FinishChooseWorld finishChooseWorld)
    {
        this.finishChooseWorld = finishChooseWorld;
    }
    private void ShowNextWorld()
    {
        homeWorldVisual.ShowWorld(creatorWorlds.GetNextWorld());
    }

    private void ShowPrevWorld()
    {
        homeWorldVisual.ShowWorld(creatorWorlds.GetPrevWorld());
    }

    private void Finish(Homeworld world)
    {
        finishChooseWorld?.Invoke(world);
        Destroy(this);
    }
}
