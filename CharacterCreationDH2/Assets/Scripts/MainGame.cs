using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGame : MonoBehaviour
{
    private CreatorWorlds creatorWorlds;
    private CreatorBackgrounds creatorBackgrounds;
    private HomeWorldVisual homeWorldVisual;
    private BackGroundVisual backVisual;
    [SerializeField] GameObject homeWorldCanvas, backgroundCanvas;
    private Character character;
    private void Start()
    {
        character = new Character();
        /*
        creatorWorlds = new CreatorWorlds();
        var visualHomeworld = Instantiate(homeWorldCanvas);
        homeWorldVisual = visualHomeworld.GetComponent<HomeWorldVisual>();
        homeWorldVisual.RegDelegate(ShowNextWorld, ShowPrevWorld);
        homeWorldVisual.regFinalDelegate(FinishChooseWorld);
        ShowNextWorld();*/

        creatorBackgrounds = new CreatorBackgrounds();
        var visualBack = Instantiate(backgroundCanvas);
        backVisual = visualBack.GetComponent<BackGroundVisual>();
        backVisual.RegDelegate(ShowNextBack, ShowPrevBack);

        ShowNextBack();
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
        backVisual.ShowBackground(creatorBackgrounds.GetNextWorld());
    }

    private void ShowPrevBack()
    {
        backVisual.ShowBackground(creatorBackgrounds.GetPrevWorld());
    }
    

    private void FinishChooseWorld(Homeworld world)
    {
        Debug.Log($"Выбрана планета {world}");
        character.SetHomeWorld(world);
    }
}
