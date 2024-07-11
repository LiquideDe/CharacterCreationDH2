using System;
using UnityEngine;
using Zenject;

public abstract class PresenterForHomeBackRole : IPresenter
{
    public event Action<ICharacter> ChooseIsDone;
    public event Action ReturnToPrevWindow;
    protected HomeworldBackGroundRoleView _view;
    protected HomeBackRoleFactory _homeBackRoleFactory;
    protected ICharacter _character;
    protected ICreator _creator;

    protected int _id = 0;

    protected void SetConstruct(HomeBackRoleFactory homeBackRoleFactory)
    {
        _homeBackRoleFactory = homeBackRoleFactory;
    }

    public void Initialize(ICharacter character, HomeworldBackGroundRoleView homeworldView)
    {
        SearchCharacter(character);
        SetCreator();
        _view = homeworldView;
        Subscribe();
        _view.Initialize(GetNext());
    }

    protected abstract void SearchCharacter(ICharacter character);

    protected abstract void SetCreator();

    private void Subscribe()
    {
        _view.Next += PressNext;
        _view.Prev += PressPrev;
        _view.ShowFinal += PressShowFinal;
        _view.ReturnToPrevWindow += PressReturnToPrevWindow;
    }

    private void Unscribe()
    {
        _view.Next -= PressNext;
        _view.Prev -= PressPrev;
        _view.ShowFinal -= PressShowFinal;
        _view.ReturnToPrevWindow -= PressReturnToPrevWindow;
    }

    private IHistoryCharacter GetNext()
    {
        if (_id + 1 < _creator.Count)
        {
            _id += 1;
        }
        else
        {
            _id = 0;
        }

        return _creator.Get(_id);
    }

    private IHistoryCharacter GetPrev()
    {
        if (_id - 1 < 0)
        {
            _id = _creator.Count - 1;
        }
        else
        {
            _id -= 1;
        }
        return _creator.Get(_id);
    }

    private void PressNext() => _view.Initialize(GetNext());

    private void PressPrev() => _view.Initialize(GetPrev());

    protected abstract void PressShowFinal();

    protected void ChooseThisCharacter(ICharacter character) 
    {
        Unscribe();
        ChooseIsDone?.Invoke(character);
    } 

    private void PressReturnToPrevWindow()
    {
        Unscribe();
        _view.DestroyView();
        ReturnToPrevWindow?.Invoke();
    }
    


}
