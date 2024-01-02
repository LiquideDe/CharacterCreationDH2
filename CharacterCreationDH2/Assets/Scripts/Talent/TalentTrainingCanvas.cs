using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TalentTrainingCanvas : MonoBehaviour
{
    public delegate void BackToSkill();
    BackToSkill backToSkill;
    public delegate void GetToTheNext();
    GetToTheNext getToTheNext;
    [SerializeField] GameObject content, buttonBuy;
    [SerializeField] TalentPanel talentPanelG;
    [SerializeField] TextMeshProUGUI textExp;
    [SerializeField] InfoOfButton[] infoOfbuttons;
    [SerializeField] Image ImageOfButton;
    [SerializeField] Sprite finalSprite;
    private List<TalentPanel> talentPanels = new List<TalentPanel>();
    private CreatorTalents creatorTalents;
    private Character character;
    int exp, cost, idPanel;
    bool isChangeTalent, isEditor;
    private List<GameStat.Inclinations> allowedInclinations = new List<GameStat.Inclinations>();

    public void ShowTalentPanels(Character character, CreatorTalents creatorTalents,bool isFinal, bool isEditor = false)
    {
        if (isFinal)
        {
            ImageOfButton.sprite = finalSprite;
        }
        gameObject.SetActive(true);
        this.character = character;
        exp = character.ExperienceUnspent;
        this.creatorTalents = creatorTalents;
        this.isEditor = isEditor;
        creatorTalents.CalculationCost(character.Inclinations);
        foreach(Talent talent in creatorTalents.Talents)
        {
            bool isAvailable;
            if (isEditor)
            {
                isAvailable = isEditor;
            }
            else
            {
                isAvailable = talent.IsTalentAvailable(character.Characteristics, character.Skills, character.Implants, 
                    character.Talents, character.CorruptionPoints, character.InsanityPoints, character.PsyRating);
            }
            
            CreatePanel(talent, isAvailable);                 
        }
        ChangeTriggerOnControls();
        UpdateExpText();
        foreach(InfoOfButton button in infoOfbuttons)
        {
            button.RegDelegate(ChangeTriggerOnControls);
        }
    }

    public void CheckExp()
    {
        if (cost > exp && !isEditor)
        {
            talentPanels[idPanel].CancelOperation();
        }
        else if (isEditor)
        {
            character.AddTalent(creatorTalents.Talents[idPanel]);
            isChangeTalent = false;
            talentPanels[idPanel].Deactivate();
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

    private void CreatePanel(Talent talent, bool canTraining)
    {
        TalentPanel tl = Instantiate(talentPanelG, content.transform);
        tl.gameObject.SetActive(true);
        talentPanels.Add(tl);
        tl.CreatePanel(talent, talentPanels.Count - 1, ThatPanelShowTalent, canTraining, !talent.CheckTalentRepeat(character.Talents));
    }

    private void ShowOrHideTalent(bool hideOrShow)
    {
        foreach (TalentPanel panel in talentPanels)
        {
            if (!panel.HasAlready)
            {
                panel.gameObject.SetActive(hideOrShow);
            }
        }
    }

    private void ShowTalentsWithFilter()
    {
        for(int i = 0; i < talentPanels.Count; i++)
        {
            if (!talentPanels[i].HasAlready)
            {
                foreach (GameStat.Inclinations inclination in allowedInclinations)
                {
                    Talent talent = creatorTalents.Talents[i];
                    if (talent.Inclinations[0] == inclination || talent.Inclinations[1] == inclination || (infoOfbuttons[^1].IsActive && talent.IsImplant))
                    {
                        if (talentPanels[i].CanTraining)
                        {
                            
                            talentPanels[i].gameObject.SetActive(true);
                            break;
                        }
                        else
                        {
                            talentPanels[i].gameObject.SetActive(infoOfbuttons[0].IsActive);
                            break;
                        }
                    }
                }
                if (creatorTalents.Talents[i].IsImplant && infoOfbuttons[^1].IsActive)
                {
                    talentPanels[i].gameObject.SetActive(infoOfbuttons[0].IsActive);
                }
            }
            else
            {
                talentPanels[i].gameObject.SetActive(false);
            }            
        }
    }

    private void ThatPanelShowTalent(int idPanel, int cost)
    {
        if (talentPanels[idPanel].CanTraining)
        {
            this.idPanel = idPanel;
            this.cost = cost;
            isChangeTalent = true;
            buttonBuy.SetActive(true);
        }
        else
        {
            buttonBuy.SetActive(false);
        }
    }

    private void UpdateExpText()
    {
        textExp.text = $"ОО - {exp}";
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

    private void ChangeTriggerOnControls()
    {
        Debug.Log($"Перестраиваем таланты");
        ReBuildInclinationList();
        ShowOrHideTalent(false);
        ShowTalentsWithFilter();
    }

    private void ReBuildInclinationList()
    {
        allowedInclinations.Clear();
        foreach(InfoOfButton button in infoOfbuttons)
        {
            if (button.IsActive && button.Inclination != GameStat.Inclinations.None)
            {
                allowedInclinations.Add(button.Inclination);
            }
        }
    }

}
