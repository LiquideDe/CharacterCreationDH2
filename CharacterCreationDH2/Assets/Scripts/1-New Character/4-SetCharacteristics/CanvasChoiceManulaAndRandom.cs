using UnityEngine;
using TMPro;
using Zenject;
using UnityEngine.UI;
using System;

public class CanvasChoiceManulaAndRandom : MonoBehaviour
{
    public event Action<int> ChooseManual;
    public event Action<int> ChoseRandom;
    [SerializeField] private Slider _slider;
    [SerializeField] TextMeshProUGUI _textSliderValue;
    [SerializeField] Button _buttonManual, _buttonRandom;
    AudioManager _audioManager;  


    [Inject]
    private void Construct(AudioManager audioManager) => _audioManager = audioManager;
    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(ChangedSlider);
        _buttonManual.onClick.AddListener(ChoosedManual);
        _buttonRandom.onClick.AddListener(ChoosedRandom);
    }

    public void ShowChoose()
    {
        gameObject.SetActive(true);
    }
    private void ChoosedRandom()
    {
        _audioManager.PlayDone();
        ChoseRandom?.Invoke((int)_slider.value);
        Destroy(gameObject);
    }

    private void ChoosedManual()
    {
        _audioManager.PlayDone();
        ChooseManual?.Invoke((int)_slider.value);
        Destroy(gameObject);
    }

    private void ChangedSlider(float value)
    {
        _textSliderValue.text = $"Стартовый уровень характеристик = {(int)value}";
    }


}
