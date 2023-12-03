using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TalentTrainingCanvas : MonoBehaviour
{
    public delegate void BackToSkill();
    BackToSkill backToSkill;
    public delegate void GetToTheNext();
    GetToTheNext getToTheNext;
    [SerializeField] GameObject talentPanelG, content;
    [SerializeField] TextMeshProUGUI textExp;
    private List<TalentPanel> talentPanels = new List<TalentPanel>();
    private CreatorTalents creatorTalents;
    private Character character;
    int exp, cost, idPanel;
    bool isChangeTalent;

    public void CreateTalentPanels(Character character, CreatorTalents creatorTalents)
    {
        this.character = character;
        exp = character.ExperienceUnspent;
        this.creatorTalents = creatorTalents;
        creatorTalents.CalculationCost(character.Inclinations);
        foreach(Talent talent in creatorTalents.Talents)
        {
            if (talent.IsTalentAvailable(character.Characteristics, character.Skills, character.Implants, character.Talents))
            {
                GameObject gO = Instantiate(talentPanelG);
                gO.SetActive(true);
                gO.transform.SetParent(content.transform);


                talentPanels.Add(gO.GetComponent<TalentPanel>());
                talentPanels[^1].CreatePanel(talent.Name, talent.Description, talent.Cost, talentPanels.Count - 1, ThatPanelShowTalent);
            }
            else
            {
                talentPanels.Add(null);
            }            
        }
        UpdateExpText();
    }

    public void CheckExp()
    {
        if (cost > exp)
        {
            talentPanels[idPanel].CancelOperation();
        }
        else if(isChangeTalent)
        {
            exp -= cost;
            UpdateExpText();
            character.AddTalent(creatorTalents.Talents[idPanel]);
            character.ExperienceSpent += cost;
            character.ExperienceTotal += cost;
            character.ExperienceUnspent -= cost;
            talentPanels[idPanel].Deactivate();
            isChangeTalent = false;
        }
    }

    private void ThatPanelShowTalent(int idPanel, int cost)
    {
        this.idPanel = idPanel;
        this.cost = cost;
        isChangeTalent = true;
    }

    private void UpdateExpText()
    {
        textExp.text = $"нн - {exp}";
    }

    public void RegDelegates(BackToSkill backToSkill, GetToTheNext getToTheNext)
    {
        this.backToSkill = backToSkill;
        this.getToTheNext = getToTheNext;
    }

    public void ButtonBack()
    {
        backToSkill?.Invoke();
        Destroy(gameObject);
    }

    public void ButtonNext()
    {
        getToTheNext?.Invoke();
        Destroy(gameObject);
    }
}
