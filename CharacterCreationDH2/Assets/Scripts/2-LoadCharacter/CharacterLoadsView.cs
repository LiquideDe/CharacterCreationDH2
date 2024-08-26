using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class CharacterLoadsView : ViewWithButtonsDoneAndCancel
{
    [SerializeField] Button _buttonLoadPrefab;
    [SerializeField] Transform listWithLoads;

    public event Action<string> OpenThisPath;

    public void Initialize(string[] loads)
    {
        foreach(string load in loads)
        {
            var dir = new DirectoryInfo(load);
            Button button = Instantiate(_buttonLoadPrefab, listWithLoads);
            TextMeshProUGUI textMesh = button.GetComponentInChildren<TextMeshProUGUI>();
            textMesh.text = dir.Name;
            SetListenerToButton(button, dir.FullName);
            button.gameObject.SetActive(true);
        }
    }

    private void SetListenerToButton(Button button, string value)
    {
        string path = value;
        button.onClick.AddListener(() => LoadCharacter(path));
    }

    private void LoadCharacter(string path) => OpenThisPath?.Invoke(path);

}
