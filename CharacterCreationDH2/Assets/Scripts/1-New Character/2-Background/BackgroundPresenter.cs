using System;
using UnityEngine;
using Zenject;

public class BackgroundPresenter : PresenterForHomeBackRole,IPresenter
{
    private BackgroundFinalPanelPresenter _finalPanelPresenter;
    private LvlFactory _lvlFatcory;
    private PresenterFactory _presenterFactory;

    [Inject]
    private void Construct(HomeBackRoleFactory homeBackRoleFactory, LvlFactory lvlFatcory, PresenterFactory presenterFactory)
    {
        SetConstruct(homeBackRoleFactory);
        _lvlFatcory = lvlFatcory;
        _presenterFactory = presenterFactory;
    }

    protected override void PressShowFinal()
    {
        _view.gameObject.SetActive(false);
        _finalPanelPresenter = (BackgroundFinalPanelPresenter)_presenterFactory.Get(TypeScene.BackgroundFinal);
        _finalPanelPresenter.CancelChoice += CancelChoose;
        _finalPanelPresenter.CharacterIsChosen += ChooseDone;
        _finalPanelPresenter.Initialize(_lvlFatcory.Get(TypeScene.BackgroundFinal), _character, (Background)_creator.Get(_id));
    }

    protected override void SearchCharacter(ICharacter character)
    {
        if (character is CharacterWithHomeworld)
            _character = character;

        else
            SearchCharacter(character.GetCharacter);
    }

    protected override void SetCreator()
    {
        _creator = _homeBackRoleFactory.Get(TypeCreator.Background);
    }

    private void CancelChoose()
    {
        _finalPanelPresenter.CancelChoice -= CancelChoose;
        _finalPanelPresenter.CharacterIsChosen -= ChooseDone;
        _view.gameObject.SetActive(true);
    }
    
    private void ChooseDone(ICharacter character)
    {
        _finalPanelPresenter.CancelChoice -= CancelChoose;
        _finalPanelPresenter.CharacterIsChosen -= ChooseDone;
        ChooseThisCharacter(character);
        _view.DestroyView();
    }
    
}
