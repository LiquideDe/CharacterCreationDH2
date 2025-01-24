using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasWithSkillInfo : AnimateShowAndHideView
{
    [SerializeField] private TextMeshProUGUI _textNameSkill, _textDescriptionSkill;
    [SerializeField] private Button _buttonClose;

    private void OnDisable() => _buttonClose.onClick.RemoveAllListeners();

    public void SetSkill(Skill skill)
    {
        _textNameSkill.text = skill.Name;
        _textDescriptionSkill.text = skill.Description;
        _buttonClose.onClick.AddListener(ClosePanel);
        _buttonClose.onClick.AddListener(_audio.PlayCancel);
    }

    private void ClosePanel()
    {
        HideRight(DestroyView);
    }
}
