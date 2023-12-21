using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using System.Linq;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BackGroundVisual : ToggleVisual
{
    public delegate void ChosenBack(Background chosenBack);
    private ChosenBack chosenBack;

    [SerializeField] GameObject finalPanel;
    private Background background;
    
    
    private List<string> remembers = new List<string>();
    private CreatorSkills creatorSkills;
    private CreatorTalents creatorTalents;
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

    public void SetCreators(CreatorSkills creatorSkills, CreatorTalents creatorTalents)
    {
        this.creatorSkills = creatorSkills;
        this.creatorTalents = creatorTalents;
    }
    public void ShowBackground(Background background)
    {
        Debug.Log($"Показываем следующий бэк");
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
            if(skills.Count > 1)
            {
                if (creatorSkills.IsSkillKnowledge(skills[0].Name))
                {
                    CreateToggleGroup("Знания");
                }
                else
                {
                    CreateToggleGroup("Навыки");
                }
                
                for (int i = 0; i < skills.Count; i++)
                {
                    Debug.Log($"Ищем скилл под названием {skills[i].Name}");
                    CreateToggle(skills[i].Name, i, creatorSkills.GetSkill(skills[i].Name).Description);

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
                    CreateToggle(talents[i],i,creatorTalents.GetTalent(talents[i]).ShortDescription);
                }
            }
        }

        foreach(List<Equipment> equipment in background.Equipment)
        {
            //if (equipment.Count > 1)
            //{
                CreateToggleGroup("Экипировка");
                for (int i = 0; i < equipment.Count; i++)
                {
                    if(equipment[i].TypeEq == Equipment.TypeEquipment.Weapon)
                    {
                        Weapon weapon = (Weapon)equipment[i];
                        string dopText = $"\n Урон {weapon.Damage}, БрПроб {weapon.Penetration}, Качества {weapon.Properties}";
                        CreateToggle(equipment[i].Name, i, equipment[i].Description + dopText);
                    }
                    else
                    {
                        CreateToggle(equipment[i].Name, i, equipment[i].Description);
                    }
                    
                }
            //}
        }

        CreateToggleGroup("Склонности");
        int sc = 0;
        foreach(GameStat.Inclinations inclination in background.Inclinations)
        {
            CreateToggle(GameStat.inclinationTranslate[inclination],sc, GameStat.descriptionInclination[inclination]);
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

        List<Equipment> equipment = new List<Equipment>();
        foreach(List<Equipment> eq in background.Equipment)
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
