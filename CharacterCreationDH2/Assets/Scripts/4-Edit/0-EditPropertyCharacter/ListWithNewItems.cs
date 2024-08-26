using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class ListWithNewItems : UniversalList
{
    [SerializeField] TextMeshProUGUI _textName;
    [SerializeField] TMP_InputField _inputName;
    [SerializeField] Button _buttonClose;
    public event Action<string> ChooseThis;
    public event Action<CanDestroyView> CloseList;
    private List<string> _namesTotalList = new List<string>();
    private List<string> _namesListToView = new List<string>();
    private List<ItemInList> _itemsInList = new List<ItemInList>();
    private bool isInputEmpty = true;

    private void OnDisable()
    {
        _inputName.onValueChanged.RemoveAllListeners();
        _buttonClose.onClick.RemoveAllListeners();
    }

    public void Initialize(List<string> names, string nameForList)
    {
        _namesTotalList = new List<string>(names);
        _namesListToView = new List<string>(names);
        _textName.text = nameForList;
        _inputName.onValueChanged.AddListener(SearchByInput);
        _buttonClose.onClick.AddListener(CloseListPressed);
        base.Initialize(names.Count);
    }

    protected override void SetTasksAndAnotherToItem(IItemForList itemForList, int index)
    {
        ItemInList itemInList = (ItemInList)itemForList;
        itemInList.ChooseThis += ChooseThisItemPressed;
        itemInList.Initialize(_namesListToView[index]);
        _itemsInList.Add(itemInList);
    }

    protected override void UpdateParametersItem(int oldIndex, int newIndex)
    {
        //Debug.Log($"oldIndex = {oldIndex}, newIndex = {newIndex}. itemListCount = {_itemsInList.Count}, _namesListToViewCount{_namesListToView.Count}");
        _itemsInList[oldIndex].Initialize(_namesListToView[newIndex]);
    }

    private void ChooseThisItemPressed(string name) => ChooseThis?.Invoke(name);

    private void SearchByInput(string text)
    {
        ClearList();
        _itemsInList.Clear();
        _namesListToView.Clear();
        foreach (string name in _namesTotalList)
        {
            if (text.Length > 0)
            {
                isInputEmpty = false;
                if (name.IndexOf(text, 0, name.Length, StringComparison.OrdinalIgnoreCase) >= 0)                
                    _namesListToView.Add(name);
                
            }
            else            
                FillListWhenSearchEmpty();
            
        }
        base.Initialize(_namesListToView.Count);
    }

    private void FillListWhenSearchEmpty()
    {
        if(isInputEmpty == false)
        {
            isInputEmpty = true;
            _namesListToView.AddRange(_namesTotalList);
        }
    }

    private void CloseListPressed() => CloseList?.Invoke(this);
}
