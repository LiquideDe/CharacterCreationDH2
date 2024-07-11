using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSkillCreatorView : MonoBehaviour
{
    [SerializeField] GameObject _horizontalPrefab;
    [SerializeField] SkillPanel _skillPanelPrefab;
    [SerializeField] Transform _content;
    [SerializeField] UpgradeSkillView _view;
    private List<SkillPanel> _skillPanels = new List<SkillPanel>();
    private List<GameObject> _horizontalLines = new List<GameObject>();
    private List<GameStat.Inclinations> _inclinationsCharacter;

    public void Initialize(List<Skill> skills, List<GameStat.Inclinations> inclinationsCharacter)
    {
        if (_skillPanels.Count > 0)
            ClearAll();

        _inclinationsCharacter = inclinationsCharacter;
        for ( int i = 0; i < skills.Count; i += 3)
        {
            if (i + 2 < skills.Count)
                SetSkillInHorizontal(new List<Skill>() {skills[i], skills[i+1], skills[i+ 2] });

            else if(i+ 1 < skills.Count)
                SetSkillInHorizontal(new List<Skill>() { skills[i], skills[i + 1] });
            else
                SetSkillInHorizontal(new List<Skill>() { skills[i] });
        }

        _view.Initialize(_skillPanels);
    }

    private void ClearAll()
    {
        for(int i = 0; i < _skillPanels.Count; i++)
        {
            _skillPanels[i].DestroySkillPanel();
        }

        _skillPanels.Clear();

        for(int i =0; i < _horizontalLines.Count; i++)
        {
            Destroy(_horizontalLines[i]);
        }
        _horizontalLines.Clear();
    }

    private void SetSkillInHorizontal(List<Skill> skills)
    {
        GameObject horizontal = Instantiate(_horizontalPrefab, _content);
        _horizontalLines.Add(horizontal);
        horizontal.SetActive(true);
        foreach(Skill skill in skills)
        {
            SkillPanel skillPanel = Instantiate(_skillPanelPrefab, horizontal.transform);
            skillPanel.Initialize(skill,((skill.LvlLearned + 1) * 300) - (100 * skill.CalculateInclinations(_inclinationsCharacter) * (skill.LvlLearned + 1)));

            _skillPanels.Add(skillPanel);
        }
    }
}
