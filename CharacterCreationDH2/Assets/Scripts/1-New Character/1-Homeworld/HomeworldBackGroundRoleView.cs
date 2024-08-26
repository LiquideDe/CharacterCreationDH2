using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Zenject;
using System;

public class HomeworldBackGroundRoleView : CanDestroyView
{
    [SerializeField] TextMeshProUGUI _textDescr, _textName, _textBonusDescr, _textCitata;
    [SerializeField] Button _buttonNext, _buttonPrev, _buttonShow, _buttonShowFinal, _buttonReturnToPrevWindow;
    [SerializeField] ImageShower _imageShower;
    [SerializeField] GameObject panelWithAdditionalInfo;

    public event Action Next, Prev, ShowFinal, ReturnToPrevWindow;

    private AudioManager _audioManager;

    private void OnEnable()
    {
        _buttonNext.onClick.AddListener(PressNext);
        _buttonPrev.onClick.AddListener(PressPrev);
        _buttonShow.onClick.AddListener(PressShow);
        _buttonShowFinal.onClick.AddListener(PressShowFinal);
        _buttonReturnToPrevWindow.onClick.AddListener(PressReturnToPrevWindow);
    }

    private void OnDisable()
    {
        _buttonNext.onClick.RemoveAllListeners();
        _buttonPrev.onClick.RemoveAllListeners();
        _buttonShow.onClick.RemoveAllListeners();
        _buttonShowFinal.onClick.RemoveAllListeners();
        _buttonReturnToPrevWindow.onClick.RemoveAllListeners();
    }

    [Inject]
    private void Construct(AudioManager audioManager)
    {
        _audioManager = audioManager;
    }

    public void Initialize(IHistoryCharacter characterHistory)
    {
        gameObject.SetActive(true);
        _imageShower.ResetImages();
        _imageShower.SetImage(characterHistory.Path);
        _textDescr.text = characterHistory.Description;
        _textName.text = characterHistory.Name;
        _textBonusDescr.text = characterHistory.BonusText;
        _textCitata.text = characterHistory.Citata;
    }

    private void PressNext()
    {
        _audioManager.PlayClick();
        panelWithAdditionalInfo.SetActive(false);
        Next?.Invoke();
    }

    private void PressPrev()
    {
        _audioManager.PlayClick();
        panelWithAdditionalInfo.SetActive(false);
        Prev?.Invoke();
    }

    private void PressReturnToPrevWindow()
    {
        _audioManager.PlayCancel();
        ReturnToPrevWindow?.Invoke();
    }

    private void PressShow()
    {
        _audioManager.PlayClick();
        panelWithAdditionalInfo.SetActive(!panelWithAdditionalInfo.activeSelf);
    }

    private void PressShowFinal()
    {
        _audioManager.PlayClick();
        ShowFinal?.Invoke();
    }
}
