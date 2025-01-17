using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MainMenuView : AnimateShowAndHideView
{
    [SerializeField] private Button _buttonNewCharacter, _buttonEditCharacter, _buttonUpgradeCharacter, _buttonExit;    
    private AudioManager _audioManager;
    public event Action NewCharacter, EditCharacter, UpgradeCharacter;

    [Inject]
    private void Construct(AudioManager audioManager) => _audioManager = audioManager;

    private void OnEnable()
    {
        _buttonNewCharacter.onClick.AddListener(PressNewCharacter);
        _buttonNewCharacter.onClick.AddListener(_audioManager.PlayClick);
        _buttonEditCharacter.onClick.AddListener(PressEditCharacter);
        _buttonEditCharacter.onClick.AddListener(_audioManager.PlayClick);
        _buttonUpgradeCharacter.onClick.AddListener(PressUpgradeCharacter);
        _buttonUpgradeCharacter.onClick.AddListener(_audioManager.PlayClick);
        _buttonExit.onClick.AddListener(Exit);
        _buttonExit.onClick.AddListener(_audioManager.PlayClick);
    }

    private void OnDisable()
    {
        _buttonNewCharacter.onClick.RemoveAllListeners();
        _buttonEditCharacter.onClick.RemoveAllListeners();
        _buttonUpgradeCharacter.onClick.RemoveAllListeners();
        _buttonExit.onClick.RemoveAllListeners();
    }

    private void PressNewCharacter() => Hide(NewCharacter);

    private void PressEditCharacter() => Hide(EditCharacter); 

    private void PressUpgradeCharacter() => Hide(UpgradeCharacter);

    private void Exit()
    {
        Application.OpenURL((Application.dataPath) + "/StreamingAssets/CharacterSheets");
        Application.Quit();
    }


}
