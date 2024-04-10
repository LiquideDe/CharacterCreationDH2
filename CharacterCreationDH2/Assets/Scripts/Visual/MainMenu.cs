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
    [SerializeField] AudioWork audioWork;
    bool isEdit;

    public void CreateNewCharacter()
    {
        audioWork.PlayClick();
        StartCoroutine(LoadMainGame());
    }

    IEnumerator LoadMainGame()
    {
        audioWork.PlayClick();
        GameObject simpleSpinner = Instantiate(spinnerExample);
        yield return new WaitForSeconds(0.1f);
        canvasMainMenu.SetActive(false);
        MainGame mainGame = Instantiate(createNewCharacter);
        mainGame.ShowMainPanel(ReturnToMenu, audioWork);
        yield return new WaitForSeconds(0.1f);
        Destroy(simpleSpinner);
    }

    public void EditCharacter()
    {
        audioWork.PlayClick();
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
        audioWork.PlayCancel();
        canvasMainMenu.SetActive(true);
    }

    private void ShowLoads()
    {
        CanvasLoads loads = Instantiate(canvasLoads);
        loads.ShowLoads(ReturnToMenu, GetPath, audioWork); ;
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
        //audioWork.PlayClick();
        GameObject simpleSpinner = Instantiate(spinnerExample);
        yield return new WaitForSeconds(0.1f);
        EditCharacter edit = Instantiate(editCharacter);
        edit.RegDelegate(ReturnToMenu, audioWork);
        edit.ShowEditMenu(path);
        yield return new WaitForSeconds(0.1f);
        Destroy(simpleSpinner);
    }

    IEnumerator StartUpgradeCharacter(string path)
    {
        //audioWork.PlayClick();
        GameObject simpleSpinner = Instantiate(spinnerExample);
        yield return new WaitForSeconds(0.1f);
        UpgradeCharacter upgrade = Instantiate(upgradeCharacter);
        upgrade.RegDelegate(ReturnToMenu, audioWork);
        upgrade.ShowUpgrade(path);
        yield return new WaitForSeconds(0.1f);
        Destroy(simpleSpinner);
    }

}
