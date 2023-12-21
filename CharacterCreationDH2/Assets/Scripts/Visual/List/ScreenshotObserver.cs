using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenshotObserver : MonoBehaviour
{
    public delegate void Finish();
    Finish finish;
    private FirstCharacterSheet first;
    private SecondCharacterSheet second;
    private GameObject secondGO;
    private Character character;
    public void RegDelegate(Finish finish)
    {
        this.finish = finish;
    }

    public void OpenScreenshots(Character character, GameObject first, GameObject second)
    {
        var tempGameobject = Instantiate(first);
        tempGameobject.SetActive(true);
        secondGO = second;
        this.character = character;
        this.first = tempGameobject.GetComponentInChildren<FirstCharacterSheet>();
        this.first.RegDelegate(TakePause);
        this.first.FillCharacterSheet(character);   
    }

    private void TakePause()
    {
        Destroy(first);
        StartCoroutine(TakeScreenshotSecond());
    }

    IEnumerator TakeScreenshotSecond()
    {
        yield return new WaitForSeconds(0.7f);
        GameObject gO = Instantiate(secondGO);
        gO.SetActive(true);
        SecondCharacterSheet secondCharacter = gO.GetComponentInChildren<SecondCharacterSheet>();
        secondCharacter.RegDelegate(FinishScreenShot);
        secondCharacter.OpenSecondSheet(character);
    }

    private void FinishScreenShot()
    {
        finish?.Invoke();
        Destroy(this);
    }
}
