using UnityEngine;
using TMPro;
using Zenject;
using UnityEngine.UI;
using System;

public class CanvasChoiceManulaAndRandom : AnimateShowAndHideView
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
        _buttonManual.onClick.AddListener(ShowFinalAnimationAndChooseManual);
        _buttonRandom.onClick.AddListener(ShowFinalAnimationAndChooseRandom);
    }

    public void ShowChoose()
    {
        gameObject.SetActive(true);
    }

    private void ShowFinalAnimationAndChooseRandom()
    {
        _audioManager.PlayDone();
        Hide(ChoosedRandom);
    }

    private void ShowFinalAnimationAndChooseManual()
    {
        _audioManager.PlayDone();
        Hide(ChoosedManual);
    }

    private void ChoosedRandom()
    {        
        ChoseRandom?.Invoke((int)_slider.value);
        DestroyView();
    }

    private void ChoosedManual()
    {        
        ChooseManual?.Invoke((int)_slider.value);
        DestroyView();
    }

    private void ChangedSlider(float value)
    {
        _textSliderValue.text = $"Стартовый уровень характеристик = {(int)value}";
    }


}
