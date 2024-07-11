using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SkillPanel : MonoBehaviour
{
    public event Action<string> ShowDescription;
    public event Action<Skill, int> UpgradeSkill;
    [SerializeField] TextMeshProUGUI _textName, _textCost;
    [SerializeField] Button _buttonUpgrade, _buttonDescription;
    [SerializeField] Image[] images;
    [SerializeField] Sprite _activeSprite;
    private Skill _skill;
    private int _cost;

    public Skill Skill => _skill;
    public int Cost => _cost;

    private void OnEnable()
    {
        _buttonUpgrade.onClick.AddListener(UpgradeSkillPress);
        _buttonDescription.onClick.AddListener(ShowDescriptionPress);
    }

    private void OnDisable()
    {
        _buttonUpgrade.onClick.RemoveAllListeners();
        _buttonDescription.onClick.RemoveAllListeners();
    }

    public void Initialize(Skill skill, int cost)
    {
        gameObject.SetActive(true);
        _skill = skill;
        _cost = cost;

        _textName.text = skill.Name;

        if (skill.LvlLearned < 4)
            _textCost.text = $"Улучшение будет стоить {cost} ОО";
        else
            _textCost.text = "Максимальный";

        for (int i = 0; i < skill.LvlLearned; i++)
        {
            images[i].sprite = _activeSprite;
        }
        if (skill.LvlLearned > 3)
            _buttonUpgrade.enabled = false;

    }

    public void DestroySkillPanel() => Destroy(gameObject);

    private void UpgradeSkillPress() => UpgradeSkill?.Invoke(_skill, _cost);

    private void ShowDescriptionPress() => ShowDescription?.Invoke(_skill.Description);
}
