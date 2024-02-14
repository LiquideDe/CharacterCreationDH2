using Assets.SimpleSpinner;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] EditCharacter editCharacter;
    [SerializeField] MainGame createNewCharacter;
    [SerializeField] GameObject canvasMainMenu, spinnerExample;
    [SerializeField] CanvasLoads canvasLoads;
    [SerializeField] UpgradeCharacter upgradeCharacter;
    bool isEdit;

    public void CreateNewCharacter()
    {
        StartCoroutine(LoadMainGame());
    }

    IEnumerator LoadMainGame()
    {
        GameObject simpleSpinner = Instantiate(spinnerExample);
        yield return new WaitForSeconds(0.1f);
        canvasMainMenu.SetActive(false);
        MainGame mainGame = Instantiate(createNewCharacter);
        mainGame.ShowMainPanel(ReturnToMenu);
        yield return new WaitForSeconds(0.1f);
        Destroy(simpleSpinner);
    }

    public void EditCharacter()
    {
        canvasMainMenu.SetActive(false);
        isEdit = true;
        ShowLoads();
    }

    public void UpgradeCharacter()
    {
        isEdit = false;
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
            StartCoroutine(StartEditCharacter(path));
        }
        else
        {
            StartCoroutine(StartUpgradeCharacter(path));
        }
    }

    IEnumerator StartEditCharacter(string path)
    {
        GameObject simpleSpinner = Instantiate(spinnerExample);
        yield return new WaitForSeconds(0.1f);
        EditCharacter edit = Instantiate(editCharacter);
        edit.RegDelegate(ReturnToMenu);
        edit.ShowEditMenu(path);
        yield return new WaitForSeconds(0.1f);
        Destroy(simpleSpinner);
    }

    IEnumerator StartUpgradeCharacter(string path)
    {
        GameObject simpleSpinner = Instantiate(spinnerExample);
        yield return new WaitForSeconds(0.1f);
        UpgradeCharacter upgrade = Instantiate(upgradeCharacter);
        upgrade.RegDelegate(ReturnToMenu);
        upgrade.ShowUpgrade(path);
        yield return new WaitForSeconds(0.1f);
        Destroy(simpleSpinner);
    }

}
