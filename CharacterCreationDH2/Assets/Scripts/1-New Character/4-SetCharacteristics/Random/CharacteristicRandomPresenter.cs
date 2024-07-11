using System;
using System.Collections.Generic;
using Zenject;

public class CharacteristicRandomPresenter : IPresenter
{
    public event Action<ICharacter> ReturnCharacterWithCharacteristics;
    public event Action ReturnToRole;
    private GameStat.CharacteristicName _advantageFirst, _advantageSecond, _disadvantage;
    private ICharacter _character;
    private CharacteristicRandomView _view;
    private int _baseAmount;
    private AudioManager _audioManager;

    [Inject]
    private void Construct(AudioManager audioManager) => _audioManager = audioManager;

    public void Initialize(ICharacter character, CharacteristicRandomView view, int baseAmount)
    {
        _character = character;
        _view = view;
        Subscribe();
        SearchCharacter(_character);
        SearchChracteristics(_character);
        _baseAmount = baseAmount;
        SetAmountCharacteristics();
    }

    private void Subscribe()
    {
        _view.ReturnToRole += ReturnToRolePressed;
        _view.ReturnCharacteristics += ReturnCharacteristics;
    }

    private void Unscribe()
    {
        _view.ReturnToRole -= ReturnToRolePressed;
        _view.ReturnCharacteristics -= ReturnCharacteristics;
    }

    protected void SearchCharacter(ICharacter character)
    {
        if (character is CharacterWithRole)
            _character = character;

        else
            SearchCharacter(character.GetCharacter);
    }

    private void SearchChracteristics(ICharacter character)
    {
        if (character is CharacterWithHomeworld)
        {
            CharacterWithHomeworld characterWithHomeworld = (CharacterWithHomeworld)character;
            _advantageFirst = characterWithHomeworld.AdvantageCharacteristicFirst;
            _advantageSecond = characterWithHomeworld.AdvantageCharacteristicSecond;
            _disadvantage = characterWithHomeworld.DisadvantageCharacteristic;
        }

        else
            SearchChracteristics(character.GetCharacter);
    }

    private void SetAmountCharacteristics()
    {
        _view.SetWeapon(_baseAmount + CheckAdvantage(GameStat.CharacteristicName.WeaponSkill));
        _view.SetBallistic(_baseAmount + CheckAdvantage(GameStat.CharacteristicName.BallisticSkill));
        _view.SetStrength(_baseAmount + CheckAdvantage(GameStat.CharacteristicName.Strength));
        _view.SetToughness(_baseAmount + CheckAdvantage(GameStat.CharacteristicName.Toughness));
        _view.SetAgility(_baseAmount + CheckAdvantage( GameStat.CharacteristicName.Agility));
        _view.SetIntelligence(_baseAmount + CheckAdvantage( GameStat.CharacteristicName.Intelligence));
        _view.SetPerception(_baseAmount + CheckAdvantage( GameStat.CharacteristicName.Perception));
        _view.SetWillPower(_baseAmount + CheckAdvantage(GameStat.CharacteristicName.Willpower));
        _view.SetSocial(_baseAmount + CheckAdvantage( GameStat.CharacteristicName.Fellowship));
        _view.SetInfluence(_baseAmount + CheckAdvantage( GameStat.CharacteristicName.Influence));
    }

    private int CheckAdvantage(GameStat.CharacteristicName characteristic)
    {
        if (characteristic == _advantageFirst || characteristic == _advantageSecond)
            return 5;

        if (characteristic == _disadvantage)
            return -5;

        return 0;
    }

    private void ReturnToRolePressed()
    {
        _audioManager.PlayCancel();
        Unscribe();
        _view.DestroyView();
        ReturnToRole?.Invoke();
    }

    private void ReturnCharacteristics(List<int> characteristics)
    {
        _audioManager.PlayDone();
        CharacterWithCharacteristics character = new CharacterWithCharacteristics(_character);
        character.SetCharacteristics(characteristics);
        ReturnCharacterWithCharacteristics?.Invoke(character);
        Unscribe();
        _view.DestroyView();
    }
}
