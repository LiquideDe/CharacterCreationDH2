using UnityEngine;

public class HomeworldPresenter : PresenterForHomeBackRole,IPresenter
{
    private HomeworldFinalPanelPresenter _finalPanelPresenter;
    private LvlFactory _lvlFactory;
    private AudioManager _audioManager;

    public HomeworldPresenter(HomeworldBackGroundRoleView view, LvlFactory lvlFactory, CreatorWorlds creatorWorld, AudioManager audioManager, 
        ICharacter character) : base (view, character, creatorWorld)
    {
        _lvlFactory = lvlFactory;
        _audioManager = audioManager;
    }

    protected override void PressShowFinal()
    {
        _view.gameObject.SetActive(false);
        HomeworldFinalPanelView finalPanelView = _lvlFactory.Get(TypeScene.HomeworldFinal).GetComponent<HomeworldFinalPanelView>();
        _finalPanelPresenter = new HomeworldFinalPanelPresenter( finalPanelView, _audioManager, _character, (Homeworld)_creator.Get(_id), _lvlFactory);
        _finalPanelPresenter.CancelChoice += CancelChoose;
        _finalPanelPresenter.CharacterIsChosen += ChooseDone;
    }

    protected override void SearchCharacter(ICharacter character)
    {
        if (character is Character)
            _character = character;

        else
            SearchCharacter(character.GetCharacter);
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
