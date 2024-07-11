using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CharacteristicManualPresenter : IPresenter
{
    public event Action<ICharacter> ReturnCharacterWithCharacteristics;
    public event Action ReturnToRole;
    private GameStat.CharacteristicName _advantageFirst, _advantageSecond, _disadvantage;
    private ICharacter _character;
    private CharacteristicManualView _view;
    private int _baseAmount, _allPoints = 60;
    private AudioManager _audioManager;
    private int _weapon, _ballistic, _strength, _toughness, _agility, _intelligence, _perception, _willpower, _fellowship, _influence;
    private const int _maxCharacteristic = 45;

    [Inject]
    private void Construct(AudioManager audioManager) => _audioManager = audioManager;

    public void Initialize(ICharacter character, CharacteristicManualView view, int baseAmount)
    {
        _character = character;
        _view = view;
        Subscribe();
        SearchCharacter(_character);
        SearchChracteristics(_character);        
        _baseAmount = baseAmount;
        SetAmountCharacteristics();
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

    protected void SearchCharacter(ICharacter character)
    {
        if (character is CharacterWithRole)
            _character = character;

        else
            SearchCharacter(character.GetCharacter);
    }

    private void SetAmountCharacteristics()
    {
        _weapon = GetAmountDependsOnAdvantagesAndDisadvantage(GameStat.CharacteristicName.WeaponSkill);
        _ballistic = GetAmountDependsOnAdvantagesAndDisadvantage(GameStat.CharacteristicName.BallisticSkill);
        _strength = GetAmountDependsOnAdvantagesAndDisadvantage(GameStat.CharacteristicName.Strength);
        _toughness = GetAmountDependsOnAdvantagesAndDisadvantage(GameStat.CharacteristicName.Toughness);
        _agility = GetAmountDependsOnAdvantagesAndDisadvantage(GameStat.CharacteristicName.Agility);
        _intelligence = GetAmountDependsOnAdvantagesAndDisadvantage(GameStat.CharacteristicName.Intelligence);
        _perception = GetAmountDependsOnAdvantagesAndDisadvantage(GameStat.CharacteristicName.Perception);
        _willpower = GetAmountDependsOnAdvantagesAndDisadvantage(GameStat.CharacteristicName.Willpower);
        _fellowship = GetAmountDependsOnAdvantagesAndDisadvantage(GameStat.CharacteristicName.Fellowship);
        _influence = GetAmountDependsOnAdvantagesAndDisadvantage(GameStat.CharacteristicName.Influence);

        UpdateText();
    }

    private int GetAmountDependsOnAdvantagesAndDisadvantage(GameStat.CharacteristicName characteristicName)
    {
        int amount = _baseAmount;
        if (characteristicName == _advantageFirst || characteristicName == _advantageSecond)
            amount += 5;

        if (characteristicName == _disadvantage)
            amount -= 5;

        return amount;
    }

    private void Subscribe()
    {
        _view.ChangeAgility += ChangeAgility;
        _view.ChangeBallistic += ChangeBallistic;
        _view.ChangeFellowship += ChangeFellowship;
        _view.ChangeInfluence += ChangeInfluence;
        _view.ChangeIntelligence += ChangeIntelligence;
        _view.ChangePerception += ChangePerception;
        _view.ChangeStrength += ChangeStrength;
        _view.ChangeToughness += ChangeToughness;
        _view.ChangeWeapon += ChangeWeapon;
        _view.ChangeWillpower += ChangeWillpower;
        _view.Done += DoneDown;
        _view.GoToPrev += ReturnToPrevDown;
    }

    private void Unscribe()
    {
        _view.ChangeAgility -= ChangeAgility;
        _view.ChangeBallistic -= ChangeBallistic;
        _view.ChangeFellowship -= ChangeFellowship;
        _view.ChangeInfluence -= ChangeInfluence;
        _view.ChangeIntelligence -= ChangeIntelligence;
        _view.ChangePerception -= ChangePerception;
        _view.ChangeStrength -= ChangeStrength;
        _view.ChangeToughness -= ChangeToughness;
        _view.ChangeWeapon -= ChangeWeapon;
        _view.ChangeWillpower -= ChangeWillpower;
        _view.Done -= DoneDown;
        _view.GoToPrev -= ReturnToPrevDown;
    }

    

    private void ChangeWeapon(int amount) => PlusOrMinusCharacteristic(GameStat.CharacteristicName.WeaponSkill, ref _weapon, amount);

    private void ChangeBallistic(int amount) => PlusOrMinusCharacteristic(GameStat.CharacteristicName.BallisticSkill, ref _ballistic, amount);

    private void ChangeStrength(int amount) => PlusOrMinusCharacteristic(GameStat.CharacteristicName.Strength, ref _strength, amount);

    private void ChangeToughness(int amount) => PlusOrMinusCharacteristic(GameStat.CharacteristicName.Toughness, ref _toughness, amount);

    private void ChangeAgility(int amount) => PlusOrMinusCharacteristic(GameStat.CharacteristicName.Agility, ref _agility, amount);

    private void ChangeIntelligence(int amount) => PlusOrMinusCharacteristic(GameStat.CharacteristicName.Intelligence, ref _intelligence, amount);

    private void ChangePerception(int amount) => PlusOrMinusCharacteristic(GameStat.CharacteristicName.Perception, ref _perception, amount);

    private void ChangeWillpower(int amount)  => PlusOrMinusCharacteristic(GameStat.CharacteristicName.Willpower, ref _willpower, amount);

    private void ChangeFellowship(int amount) => PlusOrMinusCharacteristic(GameStat.CharacteristicName.Fellowship, ref _fellowship, amount);    

    private void ChangeInfluence(int amount) => PlusOrMinusCharacteristic(GameStat.CharacteristicName.Influence, ref _influence, amount);
    

    private void PlusOrMinusCharacteristic(GameStat.CharacteristicName characteristicName, ref int characteristic, int amount)
    {
        if ((characteristic + amount > GetAmountDependsOnAdvantagesAndDisadvantage(characteristicName) && characteristic + amount <= _maxCharacteristic) && _allPoints > 0)
        {
            _audioManager.PlayClick();
            characteristic += amount;
            if (amount > 0)
                _allPoints--;
            if (amount < 0)
                _allPoints++;

            UpdateText();
        }
        else
            _audioManager.PlayWarning();
    }

    private void UpdateText()
    {
        _view.SetTextWeapon(_weapon.ToString(), _allPoints.ToString());
        _view.SetTextBallistic(_ballistic.ToString(), _allPoints.ToString());
        _view.SetTextStrength(_strength.ToString(), _allPoints.ToString());
        _view.SetTextToughness(_toughness.ToString(), _allPoints.ToString());
        _view.SetTextAgility(_agility.ToString(), _allPoints.ToString());
        _view.SetTextIntelligence(_intelligence.ToString(), _allPoints.ToString());
        _view.SetTextPerception(_perception.ToString(), _allPoints.ToString());
        _view.SetTextWillpower(_willpower.ToString(), _allPoints.ToString());
        _view.SetTextFellowship(_fellowship.ToString(), _allPoints.ToString());
        _view.SetTextInfluence(_influence.ToString(), _allPoints.ToString());
    }

    private void DoneDown()
    {
        if (_allPoints == 0)
        {
            _audioManager.PlayDone();
            CharacterWithCharacteristics character = new CharacterWithCharacteristics(_character);
            List<int> characteristics = new List<int>() { _weapon, _ballistic, _strength, _toughness, _agility, _intelligence, _perception, _willpower, _fellowship, _influence };
            character.SetCharacteristics(characteristics);
            Unscribe();
            _view.DestroyView();
            ReturnCharacterWithCharacteristics?.Invoke(character);
        }
        else
            _audioManager.PlayWarning();
    }

    private void ReturnToPrevDown()
    {
        _audioManager.PlayCancel();
        Unscribe();
        _view.DestroyView();
        ReturnToRole?.Invoke();
    }
}
