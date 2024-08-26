using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UpgradeCharacteristicsView : CanDestroyView
{
    [SerializeField]
    Button _buttonIncreaseWeapon, _buttonIncreaseBallistic, _buttonIncreaseStrength, _buttonIncreaseToughness,
        _buttonIncreaseAgility, _buttonIncreaseIntelligence, _buttonIncreasePerception, _buttonIncreaseWillpower, _buttonIncreaseFellowship;

    [SerializeField] Button _buttonNext, _buttonPrev, _buttonCancelUpgrade;

    [SerializeField] TextMeshProUGUI _textAmountWeapon, _textAmountBallistic, _textAmountStrength, _textAmountToughness,
        _textAmountAgility, _textAmountIntelligence, _textAmountPerception, _textAmountWillpower, _textAmountFellowship;

    [SerializeField]
    TextMeshProUGUI _textCostWeapon, _textCostBallistic, _textCostStrength, _textCostToughness,
        _textCostAgility, _textCostIntelligence, _textCostPerception, _textCostWillpower, _textCostFellowship;

    [SerializeField] List<Image> _listImagesWeapon, _listImagesBallistic, _listImagesStrength, _listImagesToughness,
        _listImagesAgility, _listImagesIntelligence, _listImagesPerception, _listImagesWillpower, _listImagesFellowship;

    [SerializeField] TextMeshProUGUI _textExperience;
    [SerializeField] Sprite _activeLvl, _nonactiveLvl;

    public event Action ReturnToPrev;
    public event Action Next;
    public event Action CancelUpgrade;
    public event Action UpgradeWeapon;
    public event Action UpgradeBallistic;
    public event Action UpgradeStrength;
    public event Action UpgradeToughness;
    public event Action UpgradeAgility;
    public event Action UpgradeIntelligence;
    public event Action UpgradePerception;
    public event Action UpgradeWillpower;
    public event Action UpgradeFellowship;

    private void OnEnable()
    {
        _buttonIncreaseWeapon.onClick.AddListener(IncreaseWeapon);
        _buttonIncreaseBallistic.onClick.AddListener(IncreaseBallistic);
        _buttonIncreaseStrength.onClick.AddListener(IncreaseStrength);
        _buttonIncreaseToughness.onClick.AddListener(IncreaseToughness);
        _buttonIncreaseAgility.onClick.AddListener(IncreaseAgility);
        _buttonIncreaseIntelligence.onClick.AddListener(IncreaseIntelligence);
        _buttonIncreasePerception.onClick.AddListener(IncreasePerception);
        _buttonIncreaseWillpower.onClick.AddListener(IncreaseWillpower);
        _buttonIncreaseFellowship.onClick.AddListener(IncreaseFellowship);

        _buttonNext.onClick.AddListener(DoneDown);
        _buttonPrev.onClick.AddListener(ReturnToPrevDown);
        _buttonCancelUpgrade.onClick.AddListener(CancelUpgradeDown);
    }

    private void OnDisable()
    {
        _buttonIncreaseWeapon.onClick.RemoveAllListeners();
        _buttonIncreaseBallistic.onClick.RemoveAllListeners();
        _buttonIncreaseStrength.onClick.RemoveAllListeners();
        _buttonIncreaseToughness.onClick.RemoveAllListeners();
        _buttonIncreaseAgility.onClick.RemoveAllListeners();
        _buttonIncreaseIntelligence.onClick.RemoveAllListeners();
        _buttonIncreasePerception.onClick.RemoveAllListeners();
        _buttonIncreaseWillpower.onClick.RemoveAllListeners();
        _buttonIncreaseFellowship.onClick.RemoveAllListeners();

        _buttonNext.onClick.RemoveAllListeners();
        _buttonPrev.onClick.RemoveAllListeners();
        _buttonCancelUpgrade.onClick.RemoveAllListeners();
    }

    public void SetExperience(string text) => _textExperience.text = text;
    public void SetWeapon(int amount, int lvlLearned, string cost) => SetParametersToPanel(_listImagesWeapon, lvlLearned, amount, cost, 
        _textAmountWeapon, _textCostWeapon, _buttonIncreaseWeapon);
    public void SetBallistic(int amount, int lvlLearned, string cost) => SetParametersToPanel(_listImagesBallistic, lvlLearned, amount, cost,
        _textAmountBallistic, _textCostBallistic, _buttonIncreaseBallistic);
    public void SetStrength(int amount, int lvlLearned, string cost) => SetParametersToPanel(_listImagesStrength, lvlLearned, amount, cost,
        _textAmountStrength, _textCostStrength, _buttonIncreaseStrength);
    public void SetToughness(int amount, int lvlLearned, string cost) => SetParametersToPanel(_listImagesToughness, lvlLearned, amount, cost,
        _textAmountToughness, _textCostToughness, _buttonIncreaseToughness);
    public void SetAgility(int amount, int lvlLearned, string cost) => SetParametersToPanel(_listImagesAgility, lvlLearned, amount, cost,
        _textAmountAgility, _textCostAgility, _buttonIncreaseAgility);
    public void SetIntelligence(int amount, int lvlLearned, string cost) => SetParametersToPanel(_listImagesIntelligence, lvlLearned, amount, cost,
        _textAmountIntelligence, _textCostIntelligence, _buttonIncreaseIntelligence);
    public void SetPerception(int amount, int lvlLearned, string cost) => SetParametersToPanel(_listImagesPerception, lvlLearned, amount, cost,
        _textAmountPerception, _textCostPerception, _buttonIncreasePerception);
    public void SetWillpower(int amount, int lvlLearned, string cost) => SetParametersToPanel(_listImagesWillpower, lvlLearned, amount, cost,
        _textAmountWillpower, _textCostWillpower, _buttonIncreaseWillpower);
    public void SetFellowship(int amount, int lvlLearned, string cost) => SetParametersToPanel(_listImagesFellowship, lvlLearned, amount, cost,
        _textAmountFellowship, _textCostFellowship, _buttonIncreaseFellowship);

    public void SetVisibleButtonReturnBack(bool isActive) => _buttonPrev.gameObject.SetActive(isActive);

    private void SetParametersToPanel(List<Image> images, int lvlLearned, int amount, string cost, TextMeshProUGUI textCharacteristic, TextMeshProUGUI textCost, Button buttonIncrease)
    {
        if(images != null)
        {
            ResetImages(images);
            for (int i = 0; i < lvlLearned; i++)
            {
                images[i].sprite = _activeLvl;
            }
        }

        if (lvlLearned > 4)
            buttonIncrease.gameObject.SetActive(false);
        else
            buttonIncrease.gameObject.SetActive(true);

        textCharacteristic.text = amount.ToString();
        textCost.text = cost;
    }

    private void ResetImages(List<Image> images)
    {
        for (int i = 0; i < images.Count; i++)
        {
            images[i].sprite = _nonactiveLvl;
        }
    }

    private void IncreaseWeapon() => UpgradeWeapon?.Invoke();
    private void IncreaseBallistic() => UpgradeBallistic?.Invoke();
    private void IncreaseStrength() => UpgradeStrength?.Invoke();
    private void IncreaseToughness() => UpgradeToughness?.Invoke();
    private void IncreaseAgility() => UpgradeAgility?.Invoke();
    private void IncreaseIntelligence() => UpgradeIntelligence?.Invoke();
    private void IncreasePerception() => UpgradePerception?.Invoke();
    private void IncreaseWillpower() => UpgradeWillpower?.Invoke();
    private void IncreaseFellowship() => UpgradeFellowship?.Invoke();
    private void ReturnToPrevDown() => ReturnToPrev?.Invoke();
    private void DoneDown() => Next?.Invoke();
    private void CancelUpgradeDown() => CancelUpgrade?.Invoke();
}
