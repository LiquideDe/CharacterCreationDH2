using System;

public class SetExperiencePresenter : IPresenter
{
    public event Action<ICharacter> ReturnCharacterWithExperience;

    private AudioManager _audioManager;
    private ICharacter _character;
    private SetExperienceView _view;

    public SetExperiencePresenter(AudioManager audioManager, ICharacter character, SetExperienceView view)
    {
        _audioManager = audioManager;
        _character = character;
        _view = view;
        Subscribe();
    }

    private void Subscribe() => _view.InputDone += InputExperience;
    private void Unscribe() => _view.InputDone -= InputExperience;

    private void InputExperience(string experienceText)
    {
        int.TryParse(experienceText, out int experience);

        _audioManager.PlayDone();
        CharacterWithUpgrade character = new CharacterWithUpgrade(_character);
        character.SetExperience(experience);
        Unscribe();
        _view.DestroyView();
        ReturnCharacterWithExperience?.Invoke(character);
    }
}
