using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGame : MonoBehaviour
{
    private CreatorWorlds creatorWorlds;
    private CreatorBackgrounds creatorBackgrounds;
    private CreatorRole creatorRole;

    private HomeWorldVisual homeWorldVisual;
    private BackGroundVisual backVisual;
    private RoleVisual roleVisual;
    [SerializeField] GameObject homeWorldCanvas, backgroundCanvas, roleCanvas;
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

        /*
        creatorBackgrounds = new CreatorBackgrounds();
        var visualBack = Instantiate(backgroundCanvas);
        backVisual = visualBack.GetComponent<BackGroundVisual>();
        backVisual.RegDelegate(ShowNextBack, ShowPrevBack);
        backVisual.regFinalDelegate(FinishChooseBackGround);
        ShowNextBack();*/

        /*
        creatorRole = new CreatorRole();
        var visualRole = Instantiate(roleCanvas);
        roleVisual = visualRole.GetComponent<RoleVisual>();
        roleVisual.RegDelegate(ShowNextRole, ShowPrevRole);
        roleVisual.regFinalDelegate(FinishChooseRole);
        ShowNextRole();
        */
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
        backVisual.ShowBackground(creatorBackgrounds.GetNextBack());
    }

    private void ShowPrevBack()
    {
        backVisual.ShowBackground(creatorBackgrounds.GetPrevBack());
    }
    
    private void ShowNextRole()
    {
        roleVisual.ShowRole(creatorRole.GetNextRole());
    }

    private void ShowPrevRole()
    {
        roleVisual.ShowRole(creatorRole.GetPrevRole());
    }

    private void FinishChooseWorld(Homeworld world)
    {
        character.SetHomeWorld(world);
    }

    private void FinishChooseBackGround(Background background)
    {
        character.SetBackground(background);
    }

    private void FinishChooseRole(Role role)
    {
        character.SetRole(role);
    }
}
