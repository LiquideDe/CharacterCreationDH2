using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] EditCharacter editCharacter;
    [SerializeField] MainGame createNewCharacter;
    [SerializeField] GameObject canvasMainMenu;
    [SerializeField] CanvasLoads canvasLoads;
    [SerializeField] UpgradeCharacter upgradeCharacter;
    bool isEdit;

    public void CreateNewCharacter()
    {
        canvasMainMenu.SetActive(false);
        MainGame mainGame = Instantiate(createNewCharacter);
        mainGame.ShowMainPanel(ReturnToMenu);
    }

    public void EditCharacter()
    {
        canvasMainMenu.SetActive(false);
        isEdit = true;
        ShowLoads();
    }

    public void UpgradeCharacter()
    {
        canvasMainMenu.SetActive(false);
        ShowLoads();
    }

    public void JustExit()
    {
        Application.OpenURL((Application.dataPath) + "/StreamingAssets/CharacterSheets");
        Application.Quit();
    }

    private void ReturnToMenu()
    {
        canvasMainMenu.SetActive(true);
    }

    private void ShowLoads()
    {
        CanvasLoads loads = Instantiate(canvasLoads);
        loads.ShowLoads(ReturnToMenu, GetPath);
    }

    private void GetPath(string path)
    {
        if (isEdit)
        {
            StartEditCharacter(path);
        }
        else
        {
            StartUpgradeCharacter(path);
        }
    }

    private void StartEditCharacter(string path)
    {
        EditCharacter edit = Instantiate(editCharacter);
        edit.RegDelegate(ReturnToMenu);
        edit.ShowEditMenu(path);
    }

    private void StartUpgradeCharacter(string path)
    {
        UpgradeCharacter upgrade = Instantiate(upgradeCharacter);
        upgrade.RegDelegate(ReturnToMenu);
        upgrade.ShowUpgrade(path);
    }
}
