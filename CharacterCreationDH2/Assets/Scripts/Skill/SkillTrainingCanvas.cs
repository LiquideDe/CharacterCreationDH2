using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SkillTrainingCanvas : MonoBehaviour
{
    public delegate void NextPanelTalents();
    NextPanelTalents nextPanelTalents;
    public delegate void PrevPanelChar();
    PrevPanelChar prevPanelChar;
    private int exp;
    private Character character;
    private List<SkillPanel> SkillPanels = new List<SkillPanel>();
    [SerializeField] GameObject skillPanel, grid, knowledgePanel;
    [SerializeField] TextMeshProUGUI textExp;
    [SerializeField] GameObject[] lorePanels;
    [SerializeField] GameObject[] gridLorePanels;
    private bool isCommon, isForbidden, isLinquistic, isScholastic, isTrade, isEdit;

    public void CreatePanels(Character character, bool isEdit = false)
    {
        this.character = character;
        exp = character.ExperienceUnspent;
        this.isEdit = isEdit;
        UpdateExpText();
        int sk = 0;
        
        foreach (Skill skill in character.Skills)
        {
            if (skill.IsKnowledge)
            {
                switch (skill.InternalName)
                {
                    case "CommonLore":
                        if (!isCommon)
                        {
                            CreateButtonToList("Общие знания", 0);
                            CreateKnowledgePanel(skill, 0, sk);
                            isCommon = true;
                            sk++;
                        }
                        else
                        {
                            CreateKnowledgePanel(skill, 0, sk);
                            sk++;
                        }
                        break;
                    case "ForbiddenLore":
                        if (!isForbidden)
                        {
                            CreateButtonToList("Запретные знания", 1);
                            CreateKnowledgePanel(skill, 1, sk);
                            isForbidden = true;
                            sk++;
                        }
                        else
                        {
                            CreateKnowledgePanel(skill, 1, sk);
                            sk++;
                        }
                        break;
                    case "Linquistics":
                        if (!isLinquistic)
                        {
                            CreateButtonToList("Языки", 2);
                            CreateKnowledgePanel(skill, 2, sk);
                            isLinquistic = true;
                            sk++;
                        }
                        else
                        {
                            CreateKnowledgePanel(skill, 2, sk);
                            sk++;
                        }
                        break;
                    case "ScholasticLore":
                        if (!isScholastic)
                        {
                            CreateButtonToList("Ученые знания", 3);
                            CreateKnowledgePanel(skill, 3, sk);
                            isScholastic = true;
                            sk++;
                        }
                        else
                        {
                            CreateKnowledgePanel(skill, 3, sk);
                            sk++;
                        }
                        break;
                    case "Trade":
                        if (!isTrade)
                        {
                            CreateButtonToList("Ремесло", 4);
                            CreateKnowledgePanel(skill, 4, sk);
                            isTrade = true;
                            sk++;
                        }
                        else
                        {
                            CreateKnowledgePanel(skill, 4, sk);
                            sk++;
                        }
                        break;
                }
            }
            else
            {
                GameObject gO = Instantiate(skillPanel);
                gO.SetActive(true);
                gO.transform.SetParent(grid.transform);
                SkillPanels.Add(gO.GetComponent<SkillPanel>());
                SkillPanels[^1].CreateSkill(skill.Name, skill.CalculateInclinations(character.Inclinations), skill.LvlLearned, sk, skill.Description);
                SkillPanels[^1].RegDelegate(CheckExp);
                sk++;
            }
        }
    }

    private void CreateKnowledgePanel(Skill skill, int idPanel, int id)
    {
        GameObject gO = Instantiate(skillPanel);
        gO.SetActive(true);
        gO.transform.SetParent(gridLorePanels[idPanel].transform);
        SkillPanels.Add(gO.GetComponent<SkillPanel>());
        Knowledge knowledge = (Knowledge)skill;
        SkillPanels[^1].CreateSkill(knowledge.NameKnowledge, skill.CalculateInclinations(character.Inclinations), skill.LvlLearned, id, skill.Description);
        SkillPanels[^1].RegDelegate(CheckExp);
    }

    private void CreateButtonToList(string textName, int idPanel)
    {
        GameObject kP = Instantiate(knowledgePanel);
        kP.SetActive(true);
        kP.transform.SetParent(grid.transform);
        ButtonToList buttonTo = kP.GetComponent<ButtonToList>();
        buttonTo.TextName = textName;
        buttonTo.SetPanel(lorePanels[idPanel]);
    }

    private bool CheckExp(int cost, int id)
    {
        if (cost > exp && !isEdit)
        {
            return false;
        }
        else if(isEdit)
        {
            character.UpgradeSkill(null, SkillPanels[id].Name);
            return true;
        }
        else
        {
            exp -= cost;
            UpdateExpText();
            character.UpgradeSkill(null, SkillPanels[id].Name);
            character.ExperienceSpent += cost;
            character.ExperienceTotal += cost;
            character.ExperienceUnspent -= cost;
            return true;
        }
    }

    private void UpdateExpText()
    {
        if (isEdit)
        {
            textExp.text = $"Бесконечно";
        }
        else
        {
            textExp.text = $"ОО - {exp}";
        }
        
    }

    public void RegDelegates(NextPanelTalents nextPanelTalents, PrevPanelChar prevPanelChar)
    {
        this.nextPanelTalents = nextPanelTalents;
        this.prevPanelChar = prevPanelChar;
    }

    public void NextButton()
    {
        nextPanelTalents?.Invoke();
        Destroy(gameObject);
    }

    public void PrevButton()
    {
        prevPanelChar?.Invoke();
        Destroy(gameObject);
    }
}
