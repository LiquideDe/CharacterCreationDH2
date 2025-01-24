using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Zenject;

public class CharacteristicRandomView : AnimateShowAndHideView
{
    [SerializeField]
    CharacteristicCard _weaponSkill, _ballisticSkill, _strength, _toughness, _agility, _intelligence, _perception, _willpower,
        _social, _influence;

    [SerializeField] Button _buttonDone, _buttonPrev;

    public event Action ReturnToRole;
    public event Action<List<int>> ReturnCharacteristics;

    private void OnEnable()
    {
        _buttonDone.onClick.AddListener(DonePress);
        _buttonDone.onClick.AddListener(_audio.PlayDone);
        _buttonPrev.onClick.AddListener(PrevPress);
        _buttonPrev.onClick.AddListener(_audio.PlayCancel);
    }

    public void SetWeapon(int amount) => _weaponSkill.SetAmount(amount);
    public void SetBallistic(int amount) => _ballisticSkill.SetAmount(amount);
    public void SetStrength(int amount) => _strength.SetAmount(amount);
    public void SetToughness(int amount) => _toughness.SetAmount(amount);
    public void SetAgility(int amount) => _agility.SetAmount(amount);
    public void SetIntelligence(int amount) => _intelligence.SetAmount(amount);
    public void SetPerception(int amount) => _perception.SetAmount(amount);
    public void SetWillPower(int amount) => _willpower.SetAmount(amount);
    public void SetSocial(int amount) => _social.SetAmount(amount);
    public void SetInfluence(int amount) => _influence.SetAmount(amount);

    private void DonePress()
    {
        if (_weaponSkill.IsSetAmountFromRandomCard && _ballisticSkill.IsSetAmountFromRandomCard && _strength.IsSetAmountFromRandomCard &&
            _toughness.IsSetAmountFromRandomCard && _agility.IsSetAmountFromRandomCard && _intelligence.IsSetAmountFromRandomCard &&
            _perception.IsSetAmountFromRandomCard && _willpower.IsSetAmountFromRandomCard && _social.IsSetAmountFromRandomCard && _influence.IsSetAmountFromRandomCard)
        {
            List<int> characteristics = new List<int>
            {
                _weaponSkill.Amount,
                _ballisticSkill.Amount,
                _strength.Amount,
                _toughness.Amount,
                _agility.Amount,
                _intelligence.Amount,
                _perception.Amount,
                _willpower.Amount,
                _social.Amount,
                _influence.Amount
            };
            Hide(ReturnCharacteristics, characteristics);
        }
        else
            _audio.PlayWarning();
    }

    private void PrevPress() => ReturnToRole?.Invoke();
}
