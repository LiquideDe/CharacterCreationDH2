using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ItemWithNumberInList : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textName;
    [SerializeField] TMP_InputField inputLvl;
    [SerializeField] Button _buttonRemove;

    public event Action<string> RemoveThisItem;
    public event Action<string, int> ChangeAmount;

    public string Name { get => textName.text; }
    public string Lvl { get => inputLvl.text; }

    private void OnEnable()
    {
        _buttonRemove.onClick.AddListener(RemoveThisPressed);
        inputLvl.onDeselect.AddListener(SetAnotherAmount);
    }

    private void OnDisable()
    {
        _buttonRemove.onClick.RemoveAllListeners();
        inputLvl.onDeselect.RemoveAllListeners();
    }

    public void Initialize(string name, int lvl)
    {
        gameObject.SetActive(true);
        textName.text = name;
        if(lvl > 0)
            inputLvl.text = $"{lvl}";
    }

    public void SetAnotherAmount(string text)
    {
        int.TryParse(text, out int lvl);
        ChangeAmount?.Invoke(Name, lvl);
    }

    public void RemoveThisPressed() => RemoveThisItem?.Invoke(Name);
}
