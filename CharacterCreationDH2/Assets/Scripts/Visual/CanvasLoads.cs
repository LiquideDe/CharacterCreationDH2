using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CanvasLoads : MonoBehaviour
{
    public delegate void JustReturnToMenu();
    public delegate void ReturnPath(string path);
    JustReturnToMenu justReturnToMenu;
    ReturnPath returnPath;
    [SerializeField] ItemListActiveButton itemExample;
    [SerializeField] Transform listWithLoads;
    AudioWork audioWork;

    public void ShowLoads(JustReturnToMenu justReturnToMenu, ReturnPath returnPath, AudioWork audioWork)
    {
        this.audioWork = audioWork;
        this.justReturnToMenu = justReturnToMenu;
        this.returnPath = returnPath;
        gameObject.SetActive(true);

        string[] loads = Directory.GetDirectories($"{Application.dataPath}/StreamingAssets/CharacterSheets");

        foreach(string load in loads)
        {
            var dir = new DirectoryInfo(load);
            ItemListActiveButton item = Instantiate(itemExample, listWithLoads);
            item.SetParams(dir.Name, ReturnPathToMain, audioWork);
        }
    }

    private void ReturnPathToMain(string name)
    {
        audioWork.PlayDone();
        returnPath?.Invoke($"{Application.dataPath}/StreamingAssets/CharacterSheets/{name}/{name}.JSON");
        Destroy(gameObject);
    }

    public void ReturnEmpty()
    {
        audioWork.PlayCancel();
        justReturnToMenu?.Invoke();
        Destroy(gameObject);
    }
}
