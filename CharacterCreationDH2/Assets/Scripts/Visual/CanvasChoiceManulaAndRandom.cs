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

    public void ShowChoose(ChooseManual chooseManual, ChooseRandom chooseRandom)
    {
        gameObject.SetActive(true);
        this.chooseRandom = chooseRandom;
        this.chooseManual = chooseManual;
    }
    public void ChoosedRandom()
    {
        chooseRandom?.Invoke();
        Destroy(gameObject);
    }

    public void ChoosedManual()
    {
        chooseManual?.Invoke();
        Destroy(gameObject);
    }
}
