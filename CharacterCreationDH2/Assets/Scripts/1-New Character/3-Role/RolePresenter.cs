using Zenject;

public class RolePresenter : PresenterForHomeBackRole, IPresenter
{
    private RoleFinalPresenter _finalPanelPresenter;
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
        _finalPanelPresenter = (RoleFinalPresenter)_presenterFactory.Get(TypeScene.RoleFinal);
        _finalPanelPresenter.CancelChoice += CancelChoose;
        _finalPanelPresenter.CharacterIsChosen += ChooseDone;
        _finalPanelPresenter.Initialize(_lvlFatcory.Get(TypeScene.RoleFinal), _character, (Role)_creator.Get(_id));
    }

    protected override void SearchCharacter(ICharacter character)
    {
        if (character is CharacterWithBackground)
            _character = character;

        else
            SearchCharacter(character.GetCharacter);
    }

    protected override void SetCreator()
    {
        _creator = _homeBackRoleFactory.Get(TypeCreator.Role);
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