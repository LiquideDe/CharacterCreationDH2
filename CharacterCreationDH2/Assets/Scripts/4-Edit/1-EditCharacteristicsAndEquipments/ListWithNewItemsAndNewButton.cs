using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ListWithNewItemsAndNewButton : ListWithNewItems
{
    [SerializeField] Button _buttonAddNewItem;
    public event Action AddNewItem;

    private void OnEnable() => _buttonAddNewItem.onClick.AddListener(AddNewItemPressed);

    private void OnDisable() => _buttonAddNewItem.onClick.RemoveAllListeners();

    private void AddNewItemPressed() => AddNewItem?.Invoke();
}
