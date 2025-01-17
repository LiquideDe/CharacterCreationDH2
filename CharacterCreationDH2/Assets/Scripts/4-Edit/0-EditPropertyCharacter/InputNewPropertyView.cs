using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class InputNewPropertyView : AnimateShowAndHideView
{
    [SerializeField] private TextMeshProUGUI _textNameView;
    [SerializeField] private TMP_InputField _inputName;
    [SerializeField] private Button _buttonClose, _buttonDone;

    public event Action CloseInput;
    public event Action<string> ReturnThisString;

    private void OnEnable()
    {
        _buttonClose.onClick.AddListener(CloseInputPressed);
        _buttonClose.onClick.AddListener(_audio.PlayClick);
        _buttonDone.onClick.AddListener(InputDone);
        _buttonDone.onClick.AddListener(_audio.PlayCancel);
    }

    private void OnDisable()
    {
        _buttonClose.onClick.RemoveAllListeners();
        _buttonDone.onClick.RemoveAllListeners();
    }

    public void Initialize(string name) 
    {
        _textNameView.text = name;
        Show();
    }

    private void CloseInputPressed() => HideRight(CloseInput);//CloseInput?.Invoke();

    private void InputDone() => HideRight(ReturnThisString, _inputName.text);//ReturnThisString?.Invoke(_inputName.text);
}
