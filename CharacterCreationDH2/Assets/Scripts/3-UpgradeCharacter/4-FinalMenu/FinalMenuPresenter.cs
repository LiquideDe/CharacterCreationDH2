using System;
using Zenject;

public class FinalMenuPresenter : IPresenter
{
    public event Action ReturnToMenu, Exit;
    public event Action<ICharacter> SaveAndReturn, SaveAndExit;

    private AudioManager _audioManager;
    private FinalMenuView _view;
    private ICharacter _character;

    [Inject]
    private void Construct(AudioManager audioManager) => _audioManager = audioManager;

    public void Initialize(FinalMenuView view, ICharacter character)
    {
        _view = view;
        _character = character;
        Subscribe();
    }

    private void Subscribe()
    {
        _view.Exit += ExitDown;
        _view.ExitToMenu += ExitToMenuDown;
        _view.SaveAndExit += SaveAndExitDown;
        _view.SaveAndExitToMenu += SaveAndExitToMenuDown;
    }

    private void ExitDown()
    {
        SayGoodbay();
        Exit?.Invoke();
    }

    private void ExitToMenuDown()
    {
        SayGoodbay();
        ReturnToMenu?.Invoke();
    }

    private void SaveAndExitDown()
    {
        SayGoodbay();
        new Save(_character);
        SaveAndExit?.Invoke(_character);
    }

    private void SaveAndExitToMenuDown()
    {
        SayGoodbay();
        new Save(_character);
        SaveAndReturn?.Invoke(_character);
    }

    private void Unscribe()
    {
        _view.Exit -= ExitDown;
        _view.ExitToMenu -= ExitToMenuDown;
        _view.SaveAndExit -= SaveAndExitDown;
        _view.SaveAndExitToMenu -= SaveAndExitToMenuDown;
    }

    private void SayGoodbay()
    {
        _audioManager.PlayClick();
        Unscribe();
        _view.DestroyView();
    }
}
