using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SkillPanel : MonoBehaviour
{
    public delegate bool CheckCost(int cost, int id);
    CheckCost checkCost;
    [SerializeField] ButtonStudy[] buttonStudies;
    [SerializeField] TextMeshProUGUI textName;
    private int idSkill;
    private int lvlLearned;
    private string nameSkill;

    public string Name { get => nameSkill; }

    public void CreateSkill(string name, int amountInclinations, int lvlLearned, int id, string nameSkill)
    {
        this.nameSkill = nameSkill;
        textName.text = name;
        Debug.Log($"skill - {name}, lvlLearned = {lvlLearned}");
        this.lvlLearned = lvlLearned;
        idSkill = id;
        ActivatedTraining(lvlLearned);
        for (int i = 0; i < buttonStudies.Length; i++)
        {
            int cost = ((i + 1) * 300) - (100 * amountInclinations * (i + 1));
            buttonStudies[i].Cost = cost;
            buttonStudies[i].RegDelegate(CheckHavePoints);
        }
        buttonStudies[0].IsPrevButtActive = true;
    }

    private void ActivatedTraining(int lvlLearned)
    {
        for (int i = 0; i < lvlLearned; i++)
        {
            buttonStudies[i].Activated();
            if (i < buttonStudies.Length)
            {
                buttonStudies[i + 1].IsPrevButtActive = true;
            }
        }
    }

    public void RegDelegate(CheckCost checkCost)
    {
        this.checkCost = checkCost;
    }

    private void CheckHavePoints(int cost, int id)
    {
        if (!(bool)checkCost?.Invoke(cost, idSkill))
        {
            buttonStudies[id].CancelOperation();
        }
        else
        {
            lvlLearned += 1;
            if (id < buttonStudies.Length)
            {
                buttonStudies[id + 1].IsPrevButtActive = true;
            }
        }
    }
}
