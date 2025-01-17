public class RolePresenter : PresenterForHomeBackRole, IPresenter
{
    private RoleFinalPresenter _finalPanelPresenter;
    private LvlFactory _lvlFatcory;
    private AudioManager _audioManager;

    public RolePresenter(LvlFactory lvlFatcory,HomeworldBackGroundRoleView view, CreatorRole creatorRole, ICharacter character, AudioManager audioManager) : 
        base(view, character, creatorRole)
    {
        _lvlFatcory = lvlFatcory;
        _audioManager = audioManager;
        _creator = creatorRole;
    }

    protected override void PressShowFinal()
    {
        _view.gameObject.SetActive(false);
        BackgroundFinalPanelView view = _lvlFatcory.Get(TypeScene.RoleFinal).GetComponent<BackgroundFinalPanelView>();
        _finalPanelPresenter = new RoleFinalPresenter(view, _audioManager, _character, (Role)_creator.Get(_id));
        _finalPanelPresenter.CancelChoice += CancelChoose;
        _finalPanelPresenter.CharacterIsChosen += ChooseDone;
    }

    protected override void SearchCharacter(ICharacter character)
    {
        if (character is CharacterWithBackground)
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
