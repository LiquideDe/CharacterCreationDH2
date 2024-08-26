using UnityEngine;
using UnityEngine.UI;
using System;


public class FinalMenuView : CanDestroyView
{
    [SerializeField] Button _buttonSaveAndExitToMenu, _buttonSaveAndExit, _buttonExitToMenu, _buttonExit;

    public event Action SaveAndExitToMenu, SaveAndExit, ExitToMenu, Exit;

    private void OnEnable()
    {
        _buttonSaveAndExitToMenu.onClick.AddListener(SaveAndExitToMenuPressed);
        _buttonSaveAndExit.onClick.AddListener(SaveAndExitPressed);
        _buttonExitToMenu.onClick.AddListener(ExitToMenuPressed);
        _buttonExit.onClick.AddListener(ExitPressed);
    }

    private void OnDisable()
    {
        _buttonSaveAndExitToMenu.onClick.RemoveAllListeners();
        _buttonSaveAndExit.onClick.RemoveAllListeners();
        _buttonExitToMenu.onClick.RemoveAllListeners();
        _buttonExit.onClick.RemoveAllListeners();
    }

    private void SaveAndExitToMenuPressed() => SaveAndExitToMenu?.Invoke();

    private void SaveAndExitPressed() => SaveAndExit?.Invoke();

    private void ExitToMenuPressed() => ExitToMenu?.Invoke();

    private void ExitPressed() => Exit?.Invoke();
}
