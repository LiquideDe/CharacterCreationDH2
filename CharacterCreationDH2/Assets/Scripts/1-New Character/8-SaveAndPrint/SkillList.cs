using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillList : MonoBehaviour
{
    [SerializeField] private GameObject[] points;
    [SerializeField] private string skillName;
    [SerializeField] private TextMeshProUGUI textLore;

    public void SetLvlLearned(int lvlLearned)
    {
        for(int i = 0; i < lvlLearned; i++)
        {
            points[i].GetComponent<Image>().enabled = true;
        }
    }

    public string SkillName { get => skillName.ToString(); }
    public string KnowledgeTextName { get => textLore.text; set => textLore.text = value; }
}
