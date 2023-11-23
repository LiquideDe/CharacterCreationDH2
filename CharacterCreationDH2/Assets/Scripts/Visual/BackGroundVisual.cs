using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using System.Linq;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BackGroundVisual : VisualCanvas
{
    public delegate void ChosenBack(Background chosenBack);
    private ChosenBack chosenBack;

    [SerializeField] GameObject finalPanel;
    private Background background;
    [SerializeField] GameObject exampleToggleGroup, toggle, grid;
    private List<GameObject> toggleGroups = new List<GameObject>();
    private List<GameObject> toggles = new List<GameObject>();
    private List<string> remembers = new List<string>();
    public void FinalTouchToBack()
    {
        finalPanel.SetActive(true);
        CreateToggles();
    }

    public void CancelChose()
    {
        finalPanel.SetActive(false);
        foreach(GameObject g in toggleGroups)
        {
            Destroy(g);
        }
        toggleGroups.Clear();
        toggles.Clear();
    }

    public void regFinalDelegate(ChosenBack chosenBack)
    {
        this.chosenBack = chosenBack;
    }

    public void ShowBackground(Background background)
    {
        path = background.PathBackground;
        textName.text = ReadText(path + "/Название.txt");
        this.background = background;
        SetImage(path);
        textBonusDescr.text = ReadText(path + "/Бонус.txt");
        background.Bonus = textBonusDescr.text;
        textDescr.text = ReadText(path + "/Описание.txt");
        textCitata.text = ReadText(path + "/Цитата.txt");
        remembers = ReadText(path + "/Remember.txt").Split(new char[] { '/' }).ToList();
        if (images.Count > 1)
        {
            InvokeRepeating("ChangeImage", 6, 6);
        }
        gameObject.SetActive(true);
    }

    private void CreateToggles()
    {
        foreach (List<Skill> skills in background.Skills)
        {
            bool skillIsKnowledge = false;
            if(skills.Count > 1)
            {
                if (skills[0].IsKnowledge())
                {
                    CreateToggleGroup("Знания");
                }
                else
                {
                    CreateToggleGroup("Навыки");
                }
                
                for (int i = 0; i < skills.Count; i++)
                {
                    Knowledge knowledge = null;
                    if (skills[i].IsKnowledge())
                    {
                        knowledge = (Knowledge)skills[i];
                        skillIsKnowledge = true;
                    }
                    if (skillIsKnowledge)
                    {
                        CreateToggle(skills[i].Name + knowledge.NameKnowledge,i);
                    }
                    else
                    {
                        CreateToggle(skills[i].Name,i);
                    }

                }
            
            }
        }

        foreach(List<string> talents in background.Talents)
        {
            if(talents.Count > 1)
            {
                CreateToggleGroup("Таланты");
                for (int i = 0; i < talents.Count; i++)
                {
                    CreateToggle(talents[i],i);
                }
            }
        }

        foreach(List<string> equipment in background.Equipment)
        {
            if (equipment.Count > 1)
            {
                CreateToggleGroup("Экипировка");
                for (int i = 0; i < equipment.Count; i++)
                {
                    CreateToggle(equipment[i],i);
                }
            }
        }

        CreateToggleGroup("Склонности");
        int sc = 0;
        foreach(GameStat.Inclinations inclination in background.Inclinations)
        {
            CreateToggle(GameStat.inclinationTranslate[inclination],sc);
            sc++;
        }

        foreach(GameObject togG in toggleGroups)
        {
            int count = togG.transform.childCount;
            if(count > 4)
            {
                int mult = (int)(count / 4);
                var sizechanger = togG.GetComponent<RectTransform>();
                //sizechanger.sizeDelta = new Vector2(sizechanger.sizeDelta.x, sizechanger.sizeDelta.y + sizechanger.sizeDelta.y * mult);
                sizechanger.sizeDelta = new Vector2(sizechanger.sizeDelta.x, sizechanger.sizeDelta.y * mult);
            }
        }

    }

    private void CreateToggleGroup(string nameGroup)
    {
        toggleGroups.Add(Instantiate(exampleToggleGroup));
        toggleGroups[^1].SetActive(true);
        toggleGroups[^1].transform.SetParent(grid.transform);
        toggleGroups[^1].GetComponentInChildren<TextMeshProUGUI>().text = nameGroup;
    }

    private void CreateToggle(string name, int id)
    {
        toggles.Add(Instantiate(toggle));
        var newToggle = toggles[^1].GetComponent<MyToggle>();
        newToggle.Text.text = name;
        newToggle.group = toggleGroups[^1].GetComponent<ToggleGroup>();
        newToggle.transform.SetParent(toggleGroups[^1].transform);
        newToggle.gameObject.SetActive(true);
        newToggle.Id = id;
    }

    public void BackgroundIsChosen()
    {
        int sch = 0;
        
        List<Skill> skills = new List<Skill>();
        foreach (List<Skill> sk in background.Skills)
        {
            if (sk.Count > 1)
            {
                skills.Add(sk[toggleGroups[sch].GetComponent<ToggleGroup>().ActiveToggles().FirstOrDefault().GetComponent<MyToggle>().Id]);
                sch++;
            }
            else
            {
                skills.Add(sk[0]);
            }
        }

        List<string> talents = new List<string>();
        foreach(List<string> tal in background.Talents)
        {
            if(tal.Count > 1)
            {
                talents.Add(tal[toggleGroups[sch].GetComponent<ToggleGroup>().ActiveToggles().FirstOrDefault().GetComponent<MyToggle>().Id]);
                sch++;
            }
            else
            {
                talents.Add(tal[0]);
            }
        }

        List<string> equipment = new List<string>();
        foreach(List<string> eq in background.Equipment)
        {
            if(eq.Count > 1)
            {
                equipment.Add(eq[toggleGroups[sch].GetComponent<ToggleGroup>().ActiveToggles().FirstOrDefault().GetComponent<MyToggle>().Id]);
                sch++;
            }
            else
            {
                equipment.Add(eq[0]);
            }
        }

        GameStat.Inclinations inclination = background.Inclinations[toggleGroups[sch].GetComponent<ToggleGroup>().ActiveToggles().FirstOrDefault().GetComponent<MyToggle>().Id];
        System.Random random = new System.Random();
        string rememberThing = remembers[random.Next(0, remembers.Count-1)];
        background.SetChosen(skills, talents, equipment, inclination, rememberThing);
        chosenBack?.Invoke(background);
        Destroy(gameObject);
    }
}
