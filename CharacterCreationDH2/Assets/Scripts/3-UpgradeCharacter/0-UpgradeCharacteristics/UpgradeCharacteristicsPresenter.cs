using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Zenject;

public class UpgradeCharacteristicsPresenter : IPresenter
{
    public event Action<ICharacter> ReturnToPrev;
    public event Action<ICharacter> GoNext;
    private ICharacter _character;
    private UpgradeCharacteristicsView _view;
    private AudioManager _audioManager;
    private readonly List<float> _multCostWithZeroInclinations = new List<float>() { 2, 3, 4, 6, 10 };
    private readonly List<float> _multCostWithOneInclinations = new List<float>() { 1, 2, 3, 4, 6 };
    private readonly List<float> _multCostWithTwoInclinations = new List<float>() { 0.4f, 1, 2, 3, 5 };

    private List<List<float>> _listWithMultsForCost = new List<List<float>>();
    private bool _isEdit = false;

    [Inject]
    private void Construct(AudioManager audioManager) => _audioManager = audioManager;

    public void Initialize(ICharacter character, UpgradeCharacteristicsView view, bool isNewCharacter)
    {
        _listWithMultsForCost.Add(_multCostWithZeroInclinations);
        _listWithMultsForCost.Add(_multCostWithOneInclinations);
        _listWithMultsForCost.Add(_multCostWithTwoInclinations);
        _character = character;
        _view = view;
        _view.SetVisibleButtonReturnBack(isNewCharacter);
        UpdatePanelText();
        Subcribe();
    }

    public void SetEdit()
    {
        _isEdit = true;
        _view.SetVisibleButtonReturnBack(_isEdit);
    }

    private void UpdatePanelText()
    {
        _view.SetExperience($"Очков опыта: {_character.ExperienceUnspent}");

        _view.SetWeapon(_character.Characteristics[0].Amount, _character.Characteristics[0].LvlLearned,
            ChooseTextByLvlLearned(_character.Characteristics[0]));

        _view.SetBallistic(_character.Characteristics[1].Amount, _character.Characteristics[1].LvlLearned,
            ChooseTextByLvlLearned(_character.Characteristics[1]));

        _view.SetStrength(_character.Characteristics[2].Amount, _character.Characteristics[2].LvlLearned,
            ChooseTextByLvlLearned(_character.Characteristics[2]));

        _view.SetToughness(_character.Characteristics[3].Amount, _character.Characteristics[3].LvlLearned,
            ChooseTextByLvlLearned(_character.Characteristics[3]));

        _view.SetAgility(_character.Characteristics[4].Amount, _character.Characteristics[4].LvlLearned,
            ChooseTextByLvlLearned(_character.Characteristics[4]));

        _view.SetIntelligence(_character.Characteristics[5].Amount, _character.Characteristics[5].LvlLearned,
            ChooseTextByLvlLearned(_character.Characteristics[5]));

        _view.SetPerception(_character.Characteristics[6].Amount, _character.Characteristics[6].LvlLearned,
            ChooseTextByLvlLearned(_character.Characteristics[6]));

        _view.SetWillpower(_character.Characteristics[7].Amount, _character.Characteristics[7].LvlLearned,
            ChooseTextByLvlLearned(_character.Characteristics[7]));

        _view.SetFellowship(_character.Characteristics[8].Amount, _character.Characteristics[8].LvlLearned,
            ChooseTextByLvlLearned(_character.Characteristics[8]));
    }

    private string ChooseTextByLvlLearned(Characteristic characteristic)
    {
        if (characteristic.LvlLearned < 5)
            return $"Следующий уровень будет стоить в {CalculateCost(characteristic)} ОО";

        return $"Достигнут максимум";
    }

    private int CalculateCost(Characteristic characteristic)
    {
        if (_isEdit)
        {
            return 0;
        }

        int sumInclinations = 0;
        foreach (GameStat.Inclinations incl in _character.Inclinations)
        {
            if (incl == characteristic.Inclinations[0] || incl == characteristic.Inclinations[1])
            {
                sumInclinations++;
            }
        }

        return (int)(250 * _listWithMultsForCost[sumInclinations][characteristic.LvlLearned]);
    }

    private void Subcribe()
    {
        _view.UpgradeWeapon += UpgradeWeapon;
        _view.UpgradeBallistic += UpgradeBallistic;
        _view.UpgradeStrength += UpgradeStrength;
        _view.UpgradeToughness += UpgradeToughness;
        _view.UpgradeAgility += UpgradeAgility;
        _view.UpgradeIntelligence += UpgradeIntelligence;
        _view.UpgradePerception += UpgradePerception;
        _view.UpgradeWillpower += UpgradeWillpower;
        _view.UpgradeFellowship += UpgradeFellowship;

        _view.Next += GoToNext;
        _view.ReturnToPrev += ReturnPrev;
        _view.CancelUpgrade += CancelUpgrade;
    }

    private void Unscribe()
    {
        _view.UpgradeWeapon -= UpgradeWeapon;
        _view.UpgradeBallistic -= UpgradeBallistic;
        _view.UpgradeStrength -= UpgradeStrength;
        _view.UpgradeToughness -= UpgradeToughness;
        _view.UpgradeAgility -= UpgradeAgility;
        _view.UpgradeIntelligence -= UpgradeIntelligence;
        _view.UpgradePerception -= UpgradePerception;
        _view.UpgradeWillpower -= UpgradeWillpower;
        _view.UpgradeFellowship -= UpgradeFellowship;

        _view.Next -= GoToNext;
        _view.ReturnToPrev -= ReturnPrev;
        _view.CancelUpgrade -= CancelUpgrade;
    }

    private void UpgradeFellowship() => TryUpgradeSomeCharacteristic(_character.Characteristics[8]);

    private void UpgradeWillpower() => TryUpgradeSomeCharacteristic(_character.Characteristics[7]);

    private void UpgradePerception() => TryUpgradeSomeCharacteristic(_character.Characteristics[6]);

    private void UpgradeIntelligence() => TryUpgradeSomeCharacteristic(_character.Characteristics[5]);

    private void UpgradeAgility() => TryUpgradeSomeCharacteristic(_character.Characteristics[4]);

    private void UpgradeToughness() => TryUpgradeSomeCharacteristic(_character.Characteristics[3]);

    private void UpgradeStrength() => TryUpgradeSomeCharacteristic(_character.Characteristics[2]);

    private void UpgradeBallistic() => TryUpgradeSomeCharacteristic(_character.Characteristics[1]);

    private void UpgradeWeapon() => TryUpgradeSomeCharacteristic(_character.Characteristics[0]);

    private void TryUpgradeSomeCharacteristic(Characteristic characteristic)
    {
        int cost = CalculateCost(characteristic);
        if (_character.ExperienceUnspent >= cost)
        {
            _audioManager.PlayClick();
            CharacterWithUpgrade character = new CharacterWithUpgrade(_character);

            switch (characteristic.InternalName)
            {
                case GameStat.CharacteristicName.WeaponSkill:
                    character.UpgradeWeapon(cost);
                    break;
                case GameStat.CharacteristicName.BallisticSkill:
                    character.UpgradeBallistic(cost);
                    break;
                case GameStat.CharacteristicName.Strength:
                    character.UpgradeStrength(cost);
                    break;
                case GameStat.CharacteristicName.Toughness:
                    character.UpgradeToughness(cost);
                    break;
                case GameStat.CharacteristicName.Agility:
                    character.UpgradeAgility(cost);
                    break;
                case GameStat.CharacteristicName.Intelligence:
                    character.UpgradeIntelligence(cost);
                    break;
                case GameStat.CharacteristicName.Perception:
                    character.UpgradePerception(cost);
                    break;
                case GameStat.CharacteristicName.Willpower:
                    character.UpgradeWillpower(cost);
                    break;
                case GameStat.CharacteristicName.Fellowship:
                    character.UpgradeFellowship(cost);
                    break;

                default:
                    throw new Exception($"Нет такого типа {characteristic.InternalName}");
            }            
            _character = character;
            UpdatePanelText();
        }
        else
            _audioManager.PlayWarning();
    }

    private void ReturnPrev()
    {
        _audioManager.PlayClick();
        Unscribe();
        _view.DestroyView();
        ReturnToPrev?.Invoke(_character);
    }

    private void GoToNext()
    {
        _audioManager.PlayClick();
        Unscribe();
        _view.DestroyView();
        GoNext?.Invoke(_character);
    }

    private void CancelUpgrade()
    {
        if (_character.GetCharacter is CharacterWithUpgrade)
        {
            _audioManager.PlayCancel();
            _character = _character.GetCharacter;
            UpdatePanelText();
        }
        else
            _audioManager.PlayWarning();
    }

}
