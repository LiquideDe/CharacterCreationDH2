using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Zenject;
using TMPro;

public class CharacteristicManualView : CanDestroyView
{
    [SerializeField]
    Button _buttonPlusWeapon, _buttonPlusBallistic, _buttonPlusStrength, _buttonPlusToughness, _buttonPlusAgility, _buttonPlusIntelligence,
        _buttonPlusPerception, _buttonPlusWillpower, _buttonPlusFellowship, _buttonPlusInfluence;

    [SerializeField]
    Button _buttonMinusWeapon, _buttonMinusBallistic, _buttonMinusStrength, _buttonMinusToughness, _buttonMinusAgility, _buttonMinusIntelligence,
        _buttonMinusPerception, _buttonMinusWillpower, _buttonMinusFellowship, _buttonMinusInfluence;

    [SerializeField] TextMeshProUGUI _textWeapon, _textBallistic, _textStrength, _textToughness, _textAgility, _textIntelligence,
        _textPerception, _textWillpower, _textFellowship, _textInfluence;

    [SerializeField] TextMeshProUGUI _textAmountPoints;

    [SerializeField] Button _buttonDone, _buttonPrev;

    public event Action Done;
    public event Action GoToPrev;
    public event Action<int> ChangeWeapon;
    public event Action<int> ChangeBallistic;
    public event Action<int> ChangeStrength;
    public event Action<int> ChangeToughness;
    public event Action<int> ChangeAgility;
    public event Action<int> ChangeIntelligence;
    public event Action<int> ChangePerception;
    public event Action<int> ChangeWillpower;
    public event Action<int> ChangeFellowship;
    public event Action<int> ChangeInfluence;

    private void OnEnable()
    {
        _buttonPlusWeapon.onClick.AddListener(PlusWeapon);
        _buttonPlusBallistic.onClick.AddListener(PlusBallistic);
        _buttonPlusStrength.onClick.AddListener(PlusStrength);
        _buttonPlusToughness.onClick.AddListener(PlusToughness);
        _buttonPlusAgility.onClick.AddListener(PlusAgility);
        _buttonPlusIntelligence.onClick.AddListener(PlusIntelligence);
        _buttonPlusPerception.onClick.AddListener(PlusPerception);
        _buttonPlusWillpower.onClick.AddListener(PlusWillpower);
        _buttonPlusFellowship.onClick.AddListener(PlusFellowship);
        _buttonPlusInfluence.onClick.AddListener(PlusInfluence);        

        _buttonMinusWeapon.onClick.AddListener(MinusWeapon);
        _buttonMinusBallistic.onClick.AddListener(MinusBallistic);
        _buttonMinusStrength.onClick.AddListener(MinusStrength);
        _buttonMinusToughness.onClick.AddListener(MinusToughness);
        _buttonMinusAgility.onClick.AddListener(MinusAgility);
        _buttonMinusIntelligence.onClick.AddListener(MinusIntelligence);
        _buttonMinusPerception.onClick.AddListener(MinusPerception);
        _buttonMinusWillpower.onClick.AddListener(MinusWillpower);
        _buttonMinusFellowship.onClick.AddListener(MinusFellowship);
        _buttonMinusInfluence.onClick.AddListener(MinusInfluence);

        _buttonDone.onClick.AddListener(DonePress);
        _buttonPrev.onClick.AddListener(PrevPress);
    }

    private void OnDisable()
    {
        _buttonPlusWeapon.onClick.RemoveAllListeners();
        _buttonPlusBallistic.onClick.RemoveAllListeners();
        _buttonPlusStrength.onClick.RemoveAllListeners();
        _buttonPlusToughness.onClick.RemoveAllListeners();
        _buttonPlusAgility.onClick.RemoveAllListeners();
        _buttonPlusIntelligence.onClick.RemoveAllListeners();
        _buttonPlusPerception.onClick.RemoveAllListeners();
        _buttonPlusWillpower.onClick.RemoveAllListeners();
        _buttonPlusFellowship.onClick.RemoveAllListeners();
        _buttonPlusInfluence.onClick.RemoveAllListeners();

        _buttonMinusWeapon.onClick.RemoveAllListeners();
        _buttonMinusBallistic.onClick.RemoveAllListeners();
        _buttonMinusStrength.onClick.RemoveAllListeners();
        _buttonMinusToughness.onClick.RemoveAllListeners();
        _buttonMinusAgility.onClick.RemoveAllListeners();
        _buttonMinusIntelligence.onClick.RemoveAllListeners();
        _buttonMinusPerception.onClick.RemoveAllListeners();
        _buttonMinusWillpower.onClick.RemoveAllListeners();
        _buttonMinusFellowship.onClick.RemoveAllListeners();
        _buttonMinusInfluence.onClick.RemoveAllListeners();

        _buttonDone.onClick.RemoveAllListeners();
        _buttonPrev.onClick.RemoveAllListeners();
    }


    public void SetTextWeapon(string characteristicPoint, string allPoint)
    {
        _textWeapon.text = characteristicPoint;
        _textAmountPoints.text = $"Осталось очков: {allPoint}";
    }

    public void SetTextBallistic(string characteristicPoint, string allPoint)
    {
        _textBallistic.text = characteristicPoint;
        _textAmountPoints.text = $"Осталось очков: {allPoint}";
    }

    public void SetTextStrength(string characteristicPoint, string allPoint)
    {
        _textStrength.text = characteristicPoint;
        _textAmountPoints.text = $"Осталось очков: {allPoint}";
    }

    public void SetTextToughness(string characteristicPoint, string allPoint)
    {
        _textToughness.text = characteristicPoint;
        _textAmountPoints.text = $"Осталось очков: {allPoint}";
    }

    public void SetTextAgility(string characteristicPoint, string allPoint)
    {
        _textAgility.text = characteristicPoint;
        _textAmountPoints.text = $"Осталось очков: {allPoint}";
    }

    public void SetTextIntelligence(string characteristicPoint, string allPoint)
    {
        _textIntelligence.text = characteristicPoint;
        _textAmountPoints.text = $"Осталось очков: {allPoint}";
    }

    public void SetTextPerception(string characteristicPoint, string allPoint)
    {
        _textPerception.text = characteristicPoint;
        _textAmountPoints.text = $"Осталось очков: {allPoint}";
    }

    public void SetTextWillpower(string characteristicPoint, string allPoint)
    {
        _textWillpower.text = characteristicPoint;
        _textAmountPoints.text = $"Осталось очков: {allPoint}";
    }

    public void SetTextFellowship(string characteristicPoint, string allPoint)
    {
        _textFellowship.text = characteristicPoint;
        _textAmountPoints.text = $"Осталось очков: {allPoint}";
    }

    public void SetTextInfluence(string characteristicPoint, string allPoint)
    {
        _textInfluence.text = characteristicPoint;
        _textAmountPoints.text = $"Осталось очков: {allPoint}";
    }

    private void PlusWeapon() => ChangeWeapon?.Invoke(1);    

    private void MinusWeapon() => ChangeWeapon?.Invoke(-1);

    private void PlusBallistic() => ChangeBallistic?.Invoke(1);

    private void MinusBallistic() => ChangeBallistic?.Invoke(-1);

    private void PlusStrength() => ChangeStrength?.Invoke(1);

    private void MinusStrength() => ChangeStrength?.Invoke(-1);

    private void PlusToughness() => ChangeToughness?.Invoke(1);

    private void MinusToughness() => ChangeToughness?.Invoke(-1);

    private void PlusAgility() => ChangeAgility?.Invoke(1);

    private void MinusAgility() => ChangeAgility?.Invoke(-1);

    private void PlusIntelligence() => ChangeIntelligence?.Invoke(1);

    private void MinusIntelligence() => ChangeIntelligence?.Invoke(-1);

    private void PlusPerception() => ChangePerception?.Invoke(1);

    private void MinusPerception() => ChangePerception?.Invoke(-1);

    private void PlusWillpower() => ChangeWillpower?.Invoke(1);

    private void MinusWillpower() => ChangeWillpower?.Invoke(-1);

    private void PlusFellowship() => ChangeFellowship?.Invoke(1);

    private void MinusFellowship() => ChangeFellowship?.Invoke(-1);

    private void PlusInfluence() => ChangeInfluence?.Invoke(1);

    private void MinusInfluence() => ChangeInfluence?.Invoke(-1);

    private void DonePress() => Done?.Invoke();

    private void PrevPress() => GoToPrev?.Invoke();
}
