using System;
using UnityEngine;
using Zenject;

public class MainMenuPresenter : IPresenter
{
    public event Action NewCharacter;
    public event Action EditCharacter;
    public event Action UpgradeCharacter;

    private AudioManager _audioManager;
    private MainMenuView _mainMenuView;

    [Inject]
    public void Construct(AudioManager audioManager)
    {
        _audioManager = audioManager;
    }

    public void Initialize(MainMenuView mainMenuView)
    {
        _mainMenuView = mainMenuView;
        Subscribe();
    }

    private void Subscribe()
    {
        _mainMenuView.NewCharacter += PressNewCharacter;
        _mainMenuView.EditCharacter += PressEditCharacter;
        _mainMenuView.UpgradeCharacter += PressUpgradeCharacter;
    }

    private void Unscribe()
    {
        _mainMenuView.NewCharacter -= PressNewCharacter;
        _mainMenuView.EditCharacter -= PressEditCharacter;
        _mainMenuView.UpgradeCharacter -= PressUpgradeCharacter;
    }

    private void PressNewCharacter()
    {
        _audioManager.PlayClick();
        Unscribe();
        _mainMenuView.DestroyView();
        NewCharacter?.Invoke();
        RemoveAllListeners();
    }

    private void PressEditCharacter()
    {
        _audioManager.PlayClick();
        Unscribe();
        _mainMenuView.DestroyView();
        EditCharacter?.Invoke();
        RemoveAllListeners();
    }

    private void PressUpgradeCharacter()
    {
        _audioManager.PlayClick();
        Unscribe();
        _mainMenuView.DestroyView();
        UpgradeCharacter?.Invoke();
        RemoveAllListeners();
    }

    private void RemoveAllListeners()
    {
        NewCharacter = null;
        EditCharacter = null;
        UpgradeCharacter = null;
    }
}
