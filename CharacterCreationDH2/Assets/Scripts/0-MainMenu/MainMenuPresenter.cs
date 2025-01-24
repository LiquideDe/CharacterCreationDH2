using System;

public class MainMenuPresenter : IPresenter
{
    public event Action NewCharacter;
    public event Action EditCharacter;
    public event Action UpgradeCharacter;

    private MainMenuView _mainMenuView;

    public MainMenuPresenter(MainMenuView mainMenuView)
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
        Unscribe();
        _mainMenuView.DestroyView();
        NewCharacter?.Invoke();
        RemoveAllListeners();
    }

    private void PressEditCharacter()
    {
        Unscribe();
        _mainMenuView.DestroyView();
        EditCharacter?.Invoke();
        RemoveAllListeners();
    }

    private void PressUpgradeCharacter()
    {
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
