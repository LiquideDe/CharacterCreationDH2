using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UpgradeTalentView : CanDestroyView
{
    [SerializeField] TalentList _talentList;
    [SerializeField] Button _buttonPrev, _buttonNext, _buttonStudy, _buttonCancel, _buttonResetButtons;
    [SerializeField] ButtonWithAdditionalInformation _buttonShowUnavailable;
    [SerializeField] List<ButtonWithAdditionalInformation> _ruleButtons;
    [SerializeField] TextMeshProUGUI _textDescription, _textDescriptionButton, _textExperience;
    [SerializeField] GameObject _panelWithDescriptionButton;

    public event Action Next, Prev, Cancel;
    public event Action LearnTalent;
    public event Action<Talent> ShowThisTalent;
    public event Action ShowAllTalents;
    public event Action<GameStat.Inclinations> ShowAsDefault;
    public event Action<GameStat.Inclinations> ShowTalentsWithInclination;


    private void OnEnable()
    {
        int i = 0;
        foreach (GameStat.Inclinations inclination in Enum.GetValues(typeof(GameStat.Inclinations)))
        {
            if(inclination != GameStat.Inclinations.General && inclination != GameStat.Inclinations.None && i < _ruleButtons.Count)
            {
                _ruleButtons[i].Initialize(inclination);
                _ruleButtons[i].HidePanel += HidePanel;
                _ruleButtons[i].ShowDescription += ShowInfoForButton;
                _ruleButtons[i].ShowThisInclination += ShowTalentWithCertainInclination;
                i++;
            }            
        }

        _buttonCancel.onClick.AddListener(CancelPressed);
        _buttonNext.onClick.AddListener(NextPressed);
        _buttonPrev.onClick.AddListener(PrevPressed);
        _buttonResetButtons.onClick.AddListener(ShowAsDefaultPressed);
        _buttonResetButtons.onClick.AddListener(SetAllActive);
        _buttonShowUnavailable.onClick.AddListener(ShowAllTalentsPressed);
        _buttonShowUnavailable.ShowDescription += ShowInfoForAllButton;
        _buttonStudy.onClick.AddListener(LearnTalentPressed);
        _talentList.ShowThisTalent += ShowThisTalentPressed;
    }

    private void OnDisable()
    {
        int i = 0;
        foreach (GameStat.Inclinations inclination in Enum.GetValues(typeof(GameStat.Inclinations)))
        {
            if (inclination != GameStat.Inclinations.General && inclination != GameStat.Inclinations.None && i < _ruleButtons.Count)
            {
                _ruleButtons[i].Initialize(inclination);
                _ruleButtons[i].HidePanel -= HidePanel;
                _ruleButtons[i].ShowDescription -= ShowInfoForButton;
                _ruleButtons[i].ShowThisInclination -= ShowTalentWithCertainInclination;
                i++;
            }
        }

        _buttonCancel.onClick.RemoveAllListeners();
        _buttonNext.onClick.RemoveAllListeners();
        _buttonPrev.onClick.RemoveAllListeners();
        _buttonResetButtons.onClick.RemoveAllListeners();
        _buttonShowUnavailable.onClick.RemoveAllListeners();
        _buttonStudy.onClick.RemoveAllListeners();
        _talentList.ShowThisTalent -= ShowThisTalentPressed;
    }

    public void Initialize(List<Talent> talents, List<int> costs, List<bool> isCanTaken) => _talentList.Initialize(talents, costs, isCanTaken);    

    public void ShowTalent(Talent talent, bool isCanTaken, int cost)
    {
        _buttonStudy.gameObject.SetActive(true);
        _textDescription.text = $"{talent.Name} \n Стоимость {cost} ОО \n {talent.Description} \n {talent.ListRequirments}";
        if (isCanTaken == false)
            _buttonStudy.gameObject.SetActive(false);
    }

    public void CleanTalent()
    {
        _textDescription.text = "";
        _buttonStudy.gameObject.SetActive(false);
    }

    public void UpdateExperience(string text) => _textExperience.text = text;

    public void SetButtonShowAllActive() => _buttonShowUnavailable.SetActive();
    public void SetButtonShowAllDeactive() => _buttonShowUnavailable.SetDeactive();

    private void ShowTalentWithCertainInclination(GameStat.Inclinations inclination)
    {
        ShowTalentsWithInclination(inclination);
        foreach(ButtonWithAdditionalInformation button in _ruleButtons)
        {
            if (button.Inclinations == inclination)
                button.SetActive();
            else
                button.SetDeactive();
        }
    }

    private void ShowInfoForButton(string text)
    {
        _panelWithDescriptionButton.SetActive(true);
        _textDescriptionButton.text = text;
    }

    private void ShowInfoForAllButton(string text)
    {
        _panelWithDescriptionButton.SetActive(true);
        _textDescriptionButton.text = $"Показать/скрыть недоступные таланты.";
    }

    private void HidePanel() => _panelWithDescriptionButton.SetActive(false);

    private void NextPressed() => Next?.Invoke();

    private void PrevPressed() => Prev?.Invoke();

    private void CancelPressed() => Cancel?.Invoke();

    private void ShowThisTalentPressed(Talent talent) => ShowThisTalent?.Invoke(talent);

    private void LearnTalentPressed() => LearnTalent?.Invoke();
    

    private void ShowAllTalentsPressed() => ShowAllTalents?.Invoke();

    private void ShowAsDefaultPressed() => ShowAsDefault?.Invoke(GameStat.Inclinations.None);

    private void SetAllActive()
    {
        foreach (ButtonWithAdditionalInformation button in _ruleButtons)
            button.SetActive();                    
    }

}
