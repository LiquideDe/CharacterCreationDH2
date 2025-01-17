public class BackgroundPresenter : PresenterForHomeBackRole,IPresenter
{
    private BackgroundFinalPanelPresenter _finalPanelPresenter;
    private LvlFactory _lvlFactory;
    private AudioManager _audioManager;
    private CreatorEquipment _creatorEquipment;

    public BackgroundPresenter(HomeworldBackGroundRoleView view, LvlFactory lvlFatcory, CreatorBackgrounds creatorBackgrounds, 
        AudioManager audioManager, ICharacter character, CreatorEquipment creatorEquipment) : 
        base ( view, character, creatorBackgrounds)
    {
        _lvlFactory = lvlFatcory;
        _audioManager = audioManager;
        _creator = creatorBackgrounds;
        _creatorEquipment = creatorEquipment;
    }

    protected override void PressShowFinal()
    {
        BackgroundFinalPanelView view = _lvlFactory.Get(TypeScene.BackgroundFinal).GetComponent<BackgroundFinalPanelView>();
        _view.gameObject.SetActive(false);
        _finalPanelPresenter = new BackgroundFinalPanelPresenter(view,_audioManager, _character, (Background)_creator.Get(_id), _creatorEquipment);
        _finalPanelPresenter.CancelChoice += CancelChoose;
        _finalPanelPresenter.CharacterIsChosen += ChooseDone;
    }

    protected override void SearchCharacter(ICharacter character)
    {
        if (character is CharacterWithHomeworld)
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
