using System;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuView : MonoBehaviour
{
    [SerializeField] private Button _buttonNewCharacter, _buttonEditCharacter, _buttonUpgradeCharacter, _buttonExit;

    public event Action NewCharacter, EditCharacter, UpgradeCharacter;

    private void OnEnable()
    {
        _buttonNewCharacter.onClick.AddListener(PressNewCharacter);
        _buttonEditCharacter.onClick.AddListener(PressEditCharacter);
        _buttonUpgradeCharacter.onClick.AddListener(PressUpgradeCharacter);
        _buttonExit.onClick.AddListener(Exit);
    }

    private void OnDisable()
    {
        _buttonNewCharacter.onClick.RemoveAllListeners();
        _buttonEditCharacter.onClick.RemoveAllListeners();
        _buttonUpgradeCharacter.onClick.RemoveAllListeners();
        _buttonExit.onClick.RemoveAllListeners();
    }

    public void DestroyView()
    {
        Destroy(gameObject);
    }

    private void PressNewCharacter() => NewCharacter?.Invoke();

    private void PressEditCharacter() => EditCharacter?.Invoke();

    private void PressUpgradeCharacter() => UpgradeCharacter?.Invoke();

    private void Exit()
    {
        Application.OpenURL((Application.dataPath) + "/StreamingAssets/CharacterSheets");
        Application.Quit();
    }


}
