using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ItemInList : MonoBehaviour, IItemForList
{
    [SerializeField] private TextMeshProUGUI textName;
    [SerializeField] private Button _buttonRemove;

    public event Action<string> ChooseThis;

    private void OnEnable() => _buttonRemove.onClick.AddListener(ChooseThisPressed);

    private void OnDisable() => _buttonRemove.onClick.RemoveAllListeners();

    public void Initialize(string name)
    {
        textName.text = name;
        gameObject.SetActive(true);
    }

    private void ChooseThisPressed() => ChooseThis?.Invoke(textName.text);

}
