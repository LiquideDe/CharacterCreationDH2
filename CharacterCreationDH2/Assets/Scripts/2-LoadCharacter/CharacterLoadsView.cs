using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class CharacterLoadsView : MonoBehaviour
{
    [SerializeField] Button _buttonLoadPrefab, _buttonClose;
    [SerializeField] Transform listWithLoads;

    public event Action Cancel;
    public event Action<string> OpenThisPath;

    private void OnEnable() => _buttonClose.onClick.AddListener(CancelPressed);

    private void OnDisable() => _buttonClose.onClick.RemoveAllListeners();

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

    public void DestroyView() => Destroy(gameObject);

    private void SetListenerToButton(Button button, string value)
    {
        string path = value;
        button.onClick.AddListener(() => LoadCharacter(path));
    }

    private void LoadCharacter(string path) => OpenThisPath?.Invoke(path);

    private void CancelPressed() => Cancel?.Invoke();


}
