using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Zenject;
using ModestTree;

public class MyDropDown : MonoBehaviour
{
    [SerializeField] private ItemInList _itemInListPrefab;
    [SerializeField] private Transform _content;
    [SerializeField] private TextMeshProUGUI _textChooseDropDown;
    [SerializeField] private GameObject _list;
    [SerializeField] private Button _dropdown;
    List<string> _options = new List<string>();
    private AudioManager _audioManager;

    public int Value { get => _options.IndexOf(_textChooseDropDown.text); }

    [Inject]
    private void Construct(AudioManager audioManager) => _audioManager = audioManager;

    public void AddOptions(List<string> options)
    {
        _options = options;
        _textChooseDropDown.text = _options[0];
        _dropdown.onClick.AddListener(ShowList);
        foreach (var item in options)
        {
            ItemInList itemInList = Instantiate(_itemInListPrefab, _content);
            itemInList.Initialize(item);
            itemInList.ChooseThis += ChooseThisOption;
        }
    }

    private void ShowList()
    {
        _audioManager.PlayClick();
        _list.SetActive(!_list.activeSelf);
    }

    private void ChooseThisOption(string name)
    {
        _textChooseDropDown.text = name;
        _audioManager.PlayClick();
        _list.SetActive(false);
    }
}
