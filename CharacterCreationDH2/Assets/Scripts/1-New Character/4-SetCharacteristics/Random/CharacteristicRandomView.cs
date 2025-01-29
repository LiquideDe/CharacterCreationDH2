using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class CharacteristicRandomView : AnimateShowAndHideView
{
    [SerializeField] private 
    CharacteristicCard _weaponSkill, _ballisticSkill, _strength, _toughness, _agility, _intelligence, _perception, _willpower,
        _social, _influence;

    [SerializeField] private Button _buttonDone, _buttonPrev, _buttonGenerate;

    [SerializeField] private TMP_InputField[] _inputFields;
    [SerializeField] private CardWithNumber _cardWithNumberPrefab;
    [SerializeField] private Transform _content;
    

    public event Action ReturnToRole;
    public event Action<List<int>> ReturnCharacteristics;
    public event Action GenerateAmounts;

    private List<CardWithNumber> _cardWithNumbers = new List<CardWithNumber>();

    private void OnEnable()
    {
        _buttonGenerate.onClick.AddListener(GeneratePressed);
        _buttonDone.onClick.AddListener(DonePress);
        _buttonDone.onClick.AddListener(_audio.PlayDone);
        _buttonPrev.onClick.AddListener(PrevPress);
        _buttonPrev.onClick.AddListener(_audio.PlayCancel);
        foreach (var item in _inputFields)        
            item.onDeselect.AddListener(SetAmountFromText);
        
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

    public void SetCards(int[] ints)
    {
        if(_cardWithNumbers.Count > 0)
        {
            foreach (var item in _cardWithNumbers)
            {
                Destroy(item.gameObject);
            }
            _cardWithNumbers.Clear();

            _weaponSkill.ResetAmount();
            _ballisticSkill.ResetAmount();
            _strength.ResetAmount();
            _toughness.ResetAmount();
            _agility.ResetAmount();
            _intelligence.ResetAmount();
            _perception.ResetAmount();
            _willpower.ResetAmount();
            _social.ResetAmount();
            _influence.ResetAmount();
        }

        for (int i = 0; i < ints.Length; i++)
        {            
            _inputFields[i].gameObject.SetActive(false);
            var card = Instantiate(_cardWithNumberPrefab, _content);
            card.SetAmount(ints[i]);
            _cardWithNumbers.Add(card);
            
        }
    }

    private void SetAmountFromText(string text)
    {
        int.TryParse(text, out int amount);
        if(amount > 0)
        {
            var card = Instantiate(_cardWithNumberPrefab, _content);
            card.SetAmount(amount);
            _cardWithNumbers.Add(card);
            HideInput();
        }        
    }

    private void HideInput()
    {
        foreach (var item in _inputFields)
        {
            if(item.text.Length > 0 && item.gameObject.activeSelf == true)
            {
                item.gameObject.SetActive(false);
                break;
            }                
        }
    }

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

    private void GeneratePressed() => GenerateAmounts?.Invoke();
}
