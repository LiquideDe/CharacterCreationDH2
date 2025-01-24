using UnityEngine;
using System;
using System.IO;

public class CharacterLoadsPresenter : IPresenter
{
    public event Action<ICharacter> ReturnCharacter;
    public event Action Cancel;
    private AudioManager _audiomanager;
    private CharacterLoadsView _view;
    private CharacterFactory _characterFactory;

    public CharacterLoadsPresenter(AudioManager audiomanager, CharacterLoadsView view, CharacterFactory characterFactory)
    {
        _audiomanager = audiomanager;
        _view = view;
        _characterFactory = characterFactory;
        Subscribe();
        string[] loads = Directory.GetDirectories($"{Application.dataPath}/StreamingAssets/CharacterSheets");
        _view.Initialize(loads);
    }

    private void Subscribe()
    {
        _view.Cancel += CancelDown;
        _view.OpenThisPath += ReadSaveAndCreateCharacter;
    }

    private void ReadSaveAndCreateCharacter(string path)
    {
        //_audiomanager.PlayDone();
        Load load = new Load();
        Character character = _characterFactory.Get();
        load.LoadCharacter(character, path);
        ReturnCharacter?.Invoke(character);
        Unscribe();
        _view.DestroyView();
    }

    private void CancelDown(CanDestroyView view)
    {
        //_audiomanager.PlayCancel();
        Cancel?.Invoke();
        Unscribe();
        view.DestroyView();
    }

    private void Unscribe()
    {
        _view.Cancel -= CancelDown;
        _view.OpenThisPath -= ReadSaveAndCreateCharacter;
    }



}
