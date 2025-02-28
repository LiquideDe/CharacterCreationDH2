
namespace CharacterCreation
{
    public class LvlMediator
    {
        private LvlFactory _lvlFactory;
        private LvlMediatorNewCharacter _mediatorNewCharacter;
        private LvlMediatorUpgradeCharacter _mediatorUpgrade;
        private LvlMediatorEditCharacter _mediatorEditCharacter;
        private AudioManager _audioManager;
        private CharacterFactory _characterFactory;

        public LvlMediator(LvlFactory lvlFactory, LvlMediatorNewCharacter mediatorNewCharacter, AudioManager audioManager,
            LvlMediatorUpgradeCharacter mediatorUpgrade, LvlMediatorEditCharacter mediatorEditCharacter, CharacterFactory characterFactory)
        {
            _lvlFactory = lvlFactory;
            _audioManager = audioManager;
            _mediatorNewCharacter = mediatorNewCharacter;
            _mediatorUpgrade = mediatorUpgrade;
            _mediatorEditCharacter = mediatorEditCharacter;
            _characterFactory = characterFactory;
            Subscribe();
        }

        public void MainMenu()
        {
            MainMenuView mainMenuView = _lvlFactory.Get(TypeScene.MainMenu).GetComponent<MainMenuView>();
            mainMenuView.Show();
            MainMenuPresenter mainMenuPresenter = new MainMenuPresenter(mainMenuView);
            mainMenuPresenter.NewCharacter += NewCharacterOpen;
            mainMenuPresenter.UpgradeCharacter += UpgradeCharacterOpen;
            mainMenuPresenter.EditCharacter += EditCharacterOpen;
        }
        private void Subscribe()
        {
            _mediatorNewCharacter.ReturnToMenu += MainMenu;
            _mediatorUpgrade.ReturnToMenu += MainMenu;
            _mediatorEditCharacter.ReturnToMenu += MainMenu;
        }

        private void NewCharacterOpen()
        {
            _mediatorNewCharacter.LoadNewCharacter();
        }

        private void UpgradeCharacterOpen() => ShowLoads(true);

        private void EditCharacterOpen() => ShowLoads(false);

        private void ShowLoads(bool isUpgrade)
        {
            CharacterLoadsView loadsView = _lvlFactory.Get(TypeScene.Loads).GetComponent<CharacterLoadsView>();
            CharacterLoadsPresenter loadsPresenter = new CharacterLoadsPresenter(_audioManager, loadsView, _characterFactory);
            loadsPresenter.Cancel += MainMenu;
            if (isUpgrade)
                loadsPresenter.ReturnCharacter += ShowUpgradeCharacter;
            else
                loadsPresenter.ReturnCharacter += ShowEditCharacter;

        }

        private void ShowEditCharacter(ICharacter character) => _mediatorEditCharacter.Initialize(character);

        private void ShowUpgradeCharacter(ICharacter character) => _mediatorUpgrade.Initialize(character);
    }
}

