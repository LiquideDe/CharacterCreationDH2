using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class CanvasChoiceManulaAndRandom : MonoBehaviour
{
    public delegate void ChooseManual();
    public delegate void ChooseRandom();
    ChooseManual chooseManual;
    ChooseRandom chooseRandom;
    AudioWork audioWork;

    public void ShowChoose(ChooseManual chooseManual, ChooseRandom chooseRandom, AudioWork audioWork)
    {
        gameObject.SetActive(true);
        this.chooseRandom = chooseRandom;
        this.chooseManual = chooseManual;
        this.audioWork = audioWork;
    }
    public void ChoosedRandom()
    {
        audioWork.PlayDone();
        chooseRandom?.Invoke();
        Destroy(gameObject);
    }

    public void ChoosedManual()
    {
        audioWork.PlayDone();
        chooseManual?.Invoke();
        Destroy(gameObject);
    }
}
