using System.Collections.Generic;
using System;

public class TalentList : UniversalList
{
    public event Action<Talent> ShowThisTalent;

    private List<Talent> _talents;
    private List<int> _costs;
    private List<bool> _isCanTaken;
    private List<TalentPanel> _talentPanels = new List<TalentPanel>();

    public void Initialize(List<Talent> talents, List<int> costs, List<bool> isCanTaken)
    {
        if (_talents != null)
        {
            ClearList();
            _talents.Clear();
            _costs.Clear();
            _isCanTaken.Clear();
            _talentPanels.Clear();
        }            

        _talents = new List<Talent>(talents);
        _costs = new List<int>(costs);
        _isCanTaken = new List<bool>(isCanTaken);

        base.Initialize(_talents.Count);
    }
    protected override void SetTasksAndAnotherToItem(IItemForList itemForList, int index)
    {
        TalentPanel talentPanel = (TalentPanel)itemForList;
        talentPanel.ShowThisTalent += TalentItemWasPressed;
        talentPanel.Initialize(_talents[index], _costs[index], _isCanTaken[index]);
        _talentPanels.Add(talentPanel);
    }

    protected override void UpdateParametersItem(int oldIndex, int newIndex)
    {
        _talentPanels[oldIndex].Initialize(_talents[newIndex], _costs[newIndex], _isCanTaken[newIndex]);
    }

    private void TalentItemWasPressed(string name)
    {
        foreach(Talent talent in _talents)
        {
            if (string.Compare(talent.Name, name, true) == 0)
            {
                ShowThisTalent?.Invoke(talent);
                return;
            }                
        }

        throw new Exception($"Не нашли талант с именем {name}");
    }
}
