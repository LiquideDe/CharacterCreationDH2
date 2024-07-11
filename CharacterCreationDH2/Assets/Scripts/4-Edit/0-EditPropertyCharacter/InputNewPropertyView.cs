using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class InputNewPropertyView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textNameView;
    [SerializeField] private TMP_InputField _inputName;
    [SerializeField] private Button _buttonClose, _buttonDone;

    public event Action CloseInput;
    public event Action<string> ReturnThisString;

    private void OnEnable()
    {
        _buttonClose.onClick.AddListener(CloseInputPressed);
        _buttonDone.onClick.AddListener(InputDone);
    }

    private void OnDisable()
    {
        _buttonClose.onClick.RemoveAllListeners();
        _buttonDone.onClick.RemoveAllListeners();
    }

    public void Initialize(string name) => _textNameView.text = name;

    public void DestroyView() => Destroy(gameObject);

    private void CloseInputPressed() => CloseInput?.Invoke();

    private void InputDone() => ReturnThisString?.Invoke(_inputName.text);
}
