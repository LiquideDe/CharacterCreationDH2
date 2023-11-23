using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillList : MonoBehaviour
{
    [SerializeField] GameObject[] points;
    [SerializeField] GameStat.SkillName skillName;
    [SerializeField] TextMeshProUGUI textLore;

    public void SetLvlLearned(int lvlLearned)
    {
        for(int i = 0; i < lvlLearned; i++)
        {
            points[i].GetComponent<Image>().enabled = true;
        }
    }

    public GameStat.SkillName SkillName { get => skillName; }
    public string KnowledgeTextName { get => textLore.text; set => textLore.text = value; }
}
