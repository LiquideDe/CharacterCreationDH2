using UnityEngine;
using TMPro;
using Zenject;
using UnityEngine.UI;
using System;

public class CanvasChoiceManulaAndRandom : AnimateShowAndHideView
{
    public event Action<int> ChooseManual;
    public event Action<int> ChoseRandom;
    public event Action<int> ChooseRuleBook;
    [SerializeField] private Slider _slider;
    [SerializeField] TextMeshProUGUI _textSliderValue;
    [SerializeField] Button _buttonManual, _buttonRandom, _buttonAsRuleBook;
    private AudioManager _audioManager;
    private int _baseAmount;


    [Inject]
    private void Construct(AudioManager audioManager) => _audioManager = audioManager;
    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(ChangedSlider);
        _buttonManual.onClick.AddListener(ShowFinalAnimationAndChooseManual);
        _buttonRandom.onClick.AddListener(ShowFinalAnimationAndChooseRandom);
        _buttonAsRuleBook.onClick.AddListener(ShowFinalAnimationAndChooseRuleBook);
    }    

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveAllListeners();
        _buttonManual.onClick.RemoveAllListeners();
        _buttonRandom.onClick.RemoveAllListeners();
        _buttonAsRuleBook.onClick.RemoveAllListeners();
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

    private void ShowFinalAnimationAndChooseRuleBook()
    {
        _audioManager.PlayDone();
        Hide(ChoosedRuleBook);
    }

    private void ChoosedRandom()
    {        
        ChoseRandom?.Invoke(_baseAmount);
        DestroyView();
    }

    private void ChoosedManual()
    {        
        ChooseManual?.Invoke(_baseAmount);
        DestroyView();
    }

    private void ChoosedRuleBook()
    {
        ChooseRuleBook?.Invoke(_baseAmount);
        DestroyView();
    }

    private void ChangedSlider(float value)
    {
        _baseAmount = 5 * (int)value + 10;
        _textSliderValue.text = $"Стартовый уровень характеристик = {_baseAmount}";
    }


}
