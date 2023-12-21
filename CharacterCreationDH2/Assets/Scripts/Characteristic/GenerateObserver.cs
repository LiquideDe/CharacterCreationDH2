using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateObserver : MonoBehaviour
{
    public delegate void FinishGenerated(List<Characteristic> characteristics);
    private CharacteristicGenerateCanvas characteristicGenerateCanvas;
    private FinishGenerated finishGenerated;

    public void RegDelegate(FinishGenerated finishGenerated)
    {
        this.finishGenerated = finishGenerated;
    }

    public void OpenGenerateCharacteristic(CharacteristicGenerateCanvas characteristicGenerateCanvas, Character character)
    {
        this.characteristicGenerateCanvas = Instantiate(characteristicGenerateCanvas);
        this.characteristicGenerateCanvas.RegDelegateFinish(FinishGenerateCharacteristics);
        this.characteristicGenerateCanvas.GenerateCharacteristics(character);
    }

    private void FinishGenerateCharacteristics(List<Characteristic> characteristics)
    {
        finishGenerated?.Invoke(characteristics);
        Destroy(this);
    }
}
