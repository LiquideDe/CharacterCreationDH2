using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChooseAverageLvl : MonoBehaviour
{
    public delegate void Finish(int lvl);
    Finish finish;
    [SerializeField] Slider slider;
    [SerializeField] TextMeshProUGUI textLvl;
    AudioWork audioWork;

    public void Done()
    {
        audioWork.PlayDone();
        finish?.Invoke((int)slider.value);
        Destroy(gameObject);
    }

    public void ShowChooseAverage(Finish finish, AudioWork audioWork)
    {
        gameObject.SetActive(true);
        this.finish = finish;
        this.audioWork = audioWork;
    }

    public void SliderChange()
    {
        textLvl.text = $"Стартовый уровень характеристики: {slider.value}";
    }
}
