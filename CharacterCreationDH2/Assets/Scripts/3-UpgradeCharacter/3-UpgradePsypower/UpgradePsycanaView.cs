using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UpgradePsycanaView : CanDestroyView
{
    [SerializeField] TextMeshProUGUI _textExperience, _textSchool, _textRequirementForPsyrate, _textPsyrate;
    [SerializeField] Button _buttonNext, _buttonPrev, _buttonClosePanel, _buttonBuyPsyrate, _buttonBuyPsyPower, _buttonCancel;
    [SerializeField] GameObject _panelWithInfoAboutPsyPower;
    [SerializeField] TextMeshProUGUI _textNamePsyPower, _textActionPsypower, _textCostPsypower, _textDescription;
    [SerializeField] Button _buttonSchoolPrefab;
    [SerializeField] Transform _content;
    public event Action Next, Prev, ClosePanel, Cancel, BuyPsyrate, BuyPsyPower;
    public event Action<string> ShowThisPsyPower;
    public event Action<int> ShowThisSchool;

    private void OnEnable()
    {
        _buttonNext.onClick.AddListener(NextPressed);
        _buttonPrev.onClick.AddListener(PrevPressed);
        _buttonClosePanel.onClick.AddListener(ClosePanelPressed);
        _buttonBuyPsyrate.onClick.AddListener(BuyPsyratePressed);
        _buttonBuyPsyPower.onClick.AddListener(BuyPsyPowerPressed);
        _buttonCancel.onClick.AddListener(CancelPressed);
    }

    private void OnDisable()
    {
        _buttonNext.onClick.RemoveAllListeners();
        _buttonPrev.onClick.RemoveAllListeners();
        _buttonClosePanel.onClick.RemoveAllListeners();
        _buttonBuyPsyrate.onClick.RemoveAllListeners();
        _buttonBuyPsyPower.onClick.RemoveAllListeners();
        _buttonCancel.onClick.RemoveAllListeners();
    }

    public void BuildSchoolViewList(List<string> schools)
    {
        int i = 0;
        foreach (string school in schools)
        {
            Button button = Instantiate(_buttonSchoolPrefab, _content);
            TextMeshProUGUI textMesh = button.GetComponentInChildren<TextMeshProUGUI>();
            textMesh.text = school;
            SetListenerToButton(button,i);
            button.gameObject.SetActive(true);
            i++;
        }
    }

    public void Initialize(List<PsyPanel> psyPanels)
    {
        foreach(PsyPanel psyPanel in psyPanels)
        {
            psyPanel.ShowThisPsyPower += ShowThisPsyPowerPressed;
        }
    }

    public void SetExperience(string experience, string psyRate, string reqUpdatePsyrate, string nameSchool)
    {
        _textExperience.text = experience;
        _textPsyrate.text = psyRate;
        _textRequirementForPsyrate.text = reqUpdatePsyrate;
        _textSchool.text = nameSchool;
    }

    public void ShowPsyPower(PsyPower psyPower, bool isPossibleToBuy)
    {
        _panelWithInfoAboutPsyPower.SetActive(true);
        _textNamePsyPower.text = psyPower.Name;
        _textActionPsypower.text = psyPower.Action;
        _textCostPsypower.text = psyPower.TextCost;
        _textDescription.text = psyPower.Description;        
        _buttonBuyPsyPower.enabled = isPossibleToBuy;
    }

    public void ClosePanelWithInformation() => _panelWithInfoAboutPsyPower.SetActive(false);

    private void ClosePanelPressed() => ClosePanel?.Invoke();    

    private void ShowThisPsyPowerPressed(string name) => ShowThisPsyPower?.Invoke(name);

    private void NextPressed() => Next?.Invoke();
    private void PrevPressed() => Prev?.Invoke();    

    private void CancelPressed() => Cancel?.Invoke();

    private void BuyPsyratePressed() => BuyPsyrate?.Invoke();
    private void BuyPsyPowerPressed() => BuyPsyPower?.Invoke();

    private void ShowThisSchoolPressed(int id) => ShowThisSchool?.Invoke(id);

    private void SetListenerToButton(Button button,int i)
    {
        int id = i;
        button.onClick.AddListener(() => ShowThisSchoolPressed(id));
    }
}
