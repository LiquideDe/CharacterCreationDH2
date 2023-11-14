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
        IEnumerable<string> imageFiles = Directory.EnumerateFiles(path, "*.jpg");
        foreach (string s in imageFiles)
        {
            images.Add(ReadImage(s));
        }
        image.sprite = images[0];
        textBonusDescr.text = ReadText(path + "/Бонус.txt");
        textDescr.text = ReadText(path + "/Описание.txt");
        textCitata.text = ReadText(path + "/Цитата.txt");
        if (images.Count > 1)
        {
            InvokeRepeating("ChangeImage", 6, 6);
        }
        gameObject.SetActive(true);
    }

    private void CreateToggles()
    {
        foreach(List<Skill> skills in background.Skills)
        {
            bool skillIsKnowledge = false;
            if(skills.Count > 1)
            {
                CreateToggleGroup();
                for (int i = 0; i < skills.Count; i++)
                {
                    Knowledge knowledge = null;
                    if (skills[i].Name == "CommonLore" || skills[i].Name == "ForbiddenLore" || skills[i].Name == "Linquistics" || skills[i].Name == "ScholasticLore" || skills[i].Name == "Trade")
                    {
                        knowledge = (Knowledge)skills[i];
                        skillIsKnowledge = true;
                    }
                    if (skillIsKnowledge)
                    {
                        CreateToggle(skills[i].Name + knowledge.NameKnowledge);
                    }
                    else
                    {
                        CreateToggle(skills[i].Name);
                    }

                }
            
            }
        }

        foreach(List<string> talents in background.Talents)
        {
            if(talents.Count > 1)
            {
                CreateToggleGroup();
                for (int i = 0; i < talents.Count; i++)
                {
                    CreateToggle(talents[i]);
                }
            }
        }

        foreach(List<string> equipment in background.Equipment)
        {
            if (equipment.Count > 1)
            {
                CreateToggleGroup();
                for (int i = 0; i < equipment.Count; i++)
                {
                    CreateToggle(equipment[i]);
                }
            }
        }

        CreateToggleGroup();
        foreach(GameStat.Inclinations inclination in background.Inclinations)
        {
            CreateToggle(inclination.ToString());
        }

        foreach(GameObject togG in toggleGroups)
        {
            int count = togG.transform.childCount;
            if(count > 4)
            {
                int mult = (int)(count / 4);
                var sizechanger = togG.GetComponent<RectTransform>();
                sizechanger.sizeDelta = new Vector2(sizechanger.sizeDelta.x, sizechanger.sizeDelta.y + sizechanger.sizeDelta.y * mult);
            }
        }

    }

    private void CreateToggleGroup()
    {
        toggleGroups.Add(Instantiate(exampleToggleGroup));
        toggleGroups[^1].SetActive(true);
        toggleGroups[^1].transform.SetParent(grid.transform);
    }

    private void CreateToggle(string name)
    {
        toggles.Add(Instantiate(toggle));
        var newToggle = toggles[^1].GetComponent<Toggle>();
        newToggle.GetComponentInChildren<Text>().text = name;
        newToggle.group = toggleGroups[^1].GetComponent<ToggleGroup>();
        newToggle.transform.SetParent(toggleGroups[^1].transform);
        newToggle.gameObject.SetActive(true);
    }

    public void BackgroundIsChosen()
    {
        foreach(GameObject ls in toggleGroups)
        {
            if(ls.transform.childCount > 1)
            {
                Debug.Log($"выбранный пункт {ls.GetComponent<ToggleGroup>().ActiveToggles().FirstOrDefault().GetComponentInChildren<Text>().text}");
            }
        }
    }
}
