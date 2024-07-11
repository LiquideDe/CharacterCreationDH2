using System;
using UnityEngine;
using Zenject;

public class HomeworldPresenter : PresenterForHomeBackRole,IPresenter
{
    private HomeworldFinalPanelPresenter _finalPanelPresenter;
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
        HomeworldFinalPanelView finalPanelView = _lvlFatcory.Get(TypeScene.HomeworldFinal).GetComponent<HomeworldFinalPanelView>();
        _finalPanelPresenter = (HomeworldFinalPanelPresenter)_presenterFactory.Get(TypeScene.HomeworldFinal);
        _finalPanelPresenter.CancelChoice += CancelChoose;
        _finalPanelPresenter.CharacterIsChosen += ChooseDone;
        _finalPanelPresenter.Initialize(finalPanelView, _character, (Homeworld)_creator.Get(_id));
    }

    protected override void SearchCharacter(ICharacter character)
    {
        if (character is Character)
            _character = character;

        else
            SearchCharacter(character.GetCharacter);
    }
    protected override void SetCreator()
    {
        _creator = _homeBackRoleFactory.Get(TypeCreator.Homeworld);
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
