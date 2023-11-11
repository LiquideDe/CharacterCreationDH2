using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGame : MonoBehaviour
{
    private CreatorWorlds creatorWorlds;
    private HomeWorldVisual homeWorldVisual;
    [SerializeField] GameObject homeWorldCanvas;
    private Character character;
    private void Start()
    {
        character = new Character();
        creatorWorlds = new CreatorWorlds();
        var visual = Instantiate(homeWorldCanvas);
        homeWorldVisual = visual.GetComponent<HomeWorldVisual>();
        homeWorldVisual.RegDelegate(ShowNextWorld, ShowPrevWorld);
        homeWorldVisual.regFinalDelegate(FinishChooseWorld);
        ShowNextWorld();
    }

    public void ShowNextWorld()
    {
        homeWorldVisual.ShowWorld(creatorWorlds.GetNextWorld());
    }

    public void ShowPrevWorld()
    {
        homeWorldVisual.ShowWorld(creatorWorlds.GetPrevWorld());
    }

    private void FinishChooseWorld(Homeworld world, int fate, int wounds)
    {
        Debug.Log($"Выбрана планета {world}, очки судьбы {fate}, раны {wounds}");
        character.SetHomeWorld(world, fate, wounds);
    }
}
