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

    public void Done()
    {
        finish?.Invoke((int)slider.value);
        Destroy(gameObject);
    }

    public void ShowChooseAverage(Finish finish)
    {
        gameObject.SetActive(true);
        this.finish = finish;
    }

    public void SliderChange()
    {
        textLvl.text = $"Стартовый уровень характеристики: {slider.value}";
    }
}
