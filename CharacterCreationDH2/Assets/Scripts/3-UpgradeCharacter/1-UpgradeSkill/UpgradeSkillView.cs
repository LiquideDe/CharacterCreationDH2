using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class UpgradeSkillView : AnimateShowAndHideView
{
    [SerializeField] TextMeshProUGUI _textExperience;
    [SerializeField] Button _buttonNext, _buttonPrev, _buttonCancel;
    [SerializeField] Button _buttonSkill, _buttonCommonLore, _buttonForbiddenLore, _buttonLuingva, _buttonSciense, _buttonTrade;
    public event Action<Skill, int> UpgradeSkill;
    public event Action NextWindow;
    public event Action PrevWindow;
    public event Action CancelUpgrade;
    public event Action ShowSkill, ShowCommonLore, ShowForbiddenlore, ShowLuingva, ShowSciense, ShowTrade;
    public event Action<Skill> ShowThisSkillInfo;
    

    private void OnEnable()
    {
        _buttonCancel.onClick.AddListener(CancelUpgradePress);
        _buttonNext.onClick.AddListener(NextPress);
        _buttonNext.onClick.AddListener(_audio.PlayClick);
        _buttonPrev.onClick.AddListener(PrevPress);
        _buttonPrev.onClick.AddListener(_audio.PlayClick);
        _buttonSkill.onClick.AddListener(ShowSkillPressed);
        _buttonCommonLore.onClick.AddListener(ShowCommonLorePressed);
        _buttonForbiddenLore.onClick.AddListener(ShowForbiddenLorePressed);
        _buttonLuingva.onClick.AddListener(ShowLuingvaPressed);
        _buttonSciense.onClick.AddListener(ShowSciensePressed);
        _buttonTrade.onClick.AddListener(ShowTradePressed);
    }

    private void OnDisable()
    {
        _buttonCancel.onClick.RemoveAllListeners();
        _buttonNext.onClick.RemoveAllListeners();
        _buttonPrev.onClick.RemoveAllListeners();
        _buttonSkill.onClick.RemoveAllListeners();
        _buttonCommonLore.onClick.RemoveAllListeners();
        _buttonForbiddenLore.onClick.RemoveAllListeners();
        _buttonLuingva.onClick.RemoveAllListeners();
        _buttonSciense.onClick.RemoveAllListeners();
        _buttonTrade.onClick.RemoveAllListeners();
    }
    public void Initialize(List<SkillPanel> skillPanels)
    {
        foreach(SkillPanel skillPanel in skillPanels)
        {
            skillPanel.ShowDescription += ShowDescription;
            skillPanel.UpgradeSkill += UpgradeSkillPressed;
        }
    }

    public void UpgradeExpireinceText(string exp)
    {
        _textExperience.text = exp;
    }

    private void UpgradeSkillPressed(Skill skill, int cost) => UpgradeSkill?.Invoke(skill, cost);

    private void ShowDescription(Skill skill) => ShowThisSkillInfo?.Invoke(skill);

    private void CancelUpgradePress() => CancelUpgrade?.Invoke();

    private void NextPress() => Hide(NextWindow);//NextWindow?.Invoke();

    private void PrevPress() => HideRight(PrevWindow);

    private void ShowSkillPressed() => ShowSkill.Invoke();

    private void ShowCommonLorePressed() => ShowCommonLore?.Invoke();

    private void ShowForbiddenLorePressed() => ShowForbiddenlore?.Invoke();

    private void ShowLuingvaPressed() => ShowLuingva?.Invoke();

    private void ShowSciensePressed() => ShowSciense?.Invoke();

    private void ShowTradePressed() => ShowTrade?.Invoke();


}
