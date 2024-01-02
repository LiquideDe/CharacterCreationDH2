using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenshotObserver : MonoBehaviour
{
    public delegate void Finish();
    Finish finish;
    private SecondCharacterSheet second;
    private Character character;
    public void RegDelegate(Finish finish)
    {
        this.finish = finish;
    }

    public void OpenScreenShots(Character character, FirstCharacterSheet first, SecondCharacterSheet second)
    {
        this.second = second;
        this.character = character;
        FirstCharacterSheet firstScreenshot = Instantiate(first);
        firstScreenshot.RegDelegate(BetwenFirstAndSecondPause);
        firstScreenshot.FillCharacterSheet(character);
    }

    private void BetwenFirstAndSecondPause()
    {
        StartCoroutine(TakePause());
    }
    private void NextScreenshot()
    {
        Debug.Log($"Начали второй пробег");
        SecondCharacterSheet secondScreenshot = Instantiate(second);
        secondScreenshot.RegDelegate(FinishScreenShot);
        secondScreenshot.OpenSecondSheet(character);
    }

    IEnumerator TakePause()
    {
        yield return new WaitForEndOfFrame();
        NextScreenshot();
    }
    private void FinishScreenShot()
    {
        finish?.Invoke();
        Destroy(this);
    }
}
