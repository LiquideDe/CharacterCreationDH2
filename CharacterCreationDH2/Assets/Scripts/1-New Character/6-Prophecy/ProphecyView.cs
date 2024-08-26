using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ProphecyView : CanDestroyView
{
    [SerializeField] private TextMeshProUGUI textDescription;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private Button _buttonDone, _buttonGenerate;

    public event Action<string> InputNumber;
    public event Action GenerateNumber;
    public event Action Done;

    private void OnEnable()
    {
        inputField.onDeselect.AddListener(InputNumberPressed);
        _buttonDone.onClick.AddListener(DonePressed);
        _buttonGenerate.onClick.AddListener(GenerateNumberPressed);
    }

    private void OnDisable()
    {
        inputField.onDeselect.RemoveAllListeners();
        _buttonDone.onClick.RemoveAllListeners();
        _buttonGenerate.onClick.RemoveAllListeners();
    }

    public void SetText(string text)
    {
        textDescription.text = $"Ваше пророчество: {text}";
        _buttonGenerate.gameObject.SetActive(false);
        inputField.interactable = false;
    }

    private void InputNumberPressed(string value) => InputNumber?.Invoke(value);

    private void GenerateNumberPressed() => GenerateNumber?.Invoke();

    private void DonePressed() => Done?.Invoke();
}
