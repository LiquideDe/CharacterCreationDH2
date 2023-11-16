using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using UnityEngine.UI;

public class RoleVisual : VisualCanvas
{
    public delegate void ChosenRole(Role chosenRole);
    private ChosenRole chosenRole;

    [SerializeField] GameObject finalPanel;
    private Role role;
    [SerializeField] GameObject exampleToggleGroup, toggle, grid;
    private List<GameObject> toggleGroups = new List<GameObject>();
    private List<GameObject> toggles = new List<GameObject>();
    private List<GameStat.Inclinations> chosenInclinations = new List<GameStat.Inclinations>();
    private string chosenTalent;

    public void FinalTouchToRole()
    {
        finalPanel.SetActive(true);
        CreateToggles();
    }

    public void CancelChose()
    {
        finalPanel.SetActive(false);
        foreach (GameObject g in toggleGroups)
        {
            Destroy(g);
        }
        toggleGroups.Clear();
        toggles.Clear();
    }

    public void regFinalDelegate(ChosenRole chosenRole)
    {
        this.chosenRole = chosenRole;
    }

    public void ShowRole(Role role)
    {
        this.role = role;
        path = role.PathRole;
        textName.text = ReadText(path + "/Название.txt");
        SetImage(path);
        textBonusDescr.text = ReadText(path + "/Бонус.txt");
        textDescr.text = ReadText(path + "/Описание.txt");
        textCitata.text = "\nСклонности: ";
        textCitata.text += ReadText(path + "/Склонности.txt");
        gameObject.SetActive(true);

    }
    private void CreateToggles()
    {
        foreach (List<GameStat.Inclinations> incl in role.Inclinations)
        {
            if (incl.Count > 1)
            {
                CreateToggleGroup();
                for (int i = 0; i < incl.Count; i++)
                {
                    CreateToggle(incl[i].ToString(), i);
                }
            }
        }

        CreateToggleGroup();
        int sc = 0;
        foreach(string talent in role.Talents)
        {
            CreateToggle(talent, sc);
            sc++;
        }

        foreach (GameObject togG in toggleGroups)
        {
            int count = togG.transform.childCount;
            if (count > 4)
            {
                int mult = (int)(count / 4);
                var sizechanger = togG.GetComponent<RectTransform>();
                //sizechanger.sizeDelta = new Vector2(sizechanger.sizeDelta.x, sizechanger.sizeDelta.y + sizechanger.sizeDelta.y * mult);
                sizechanger.sizeDelta = new Vector2(sizechanger.sizeDelta.x, sizechanger.sizeDelta.y * mult);
            }
        }
    }

    private void CreateToggleGroup()
    {
        toggleGroups.Add(Instantiate(exampleToggleGroup));
        toggleGroups[^1].SetActive(true);
        toggleGroups[^1].transform.SetParent(grid.transform);
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

    public void RoleIsChosen()
    {
        int sch = 0;
        foreach (List<GameStat.Inclinations> incl in role.Inclinations)
        {
            if (incl.Count > 1)
            {
                chosenInclinations.Add(incl[toggleGroups[sch].GetComponent<ToggleGroup>().ActiveToggles().FirstOrDefault().GetComponent<MyToggle>().Id]);
                sch++;
            }
            else
            {
                chosenInclinations.Add(incl[0]);
            }
        }

        chosenTalent = role.Talents[toggleGroups[sch].GetComponent<ToggleGroup>().ActiveToggles().FirstOrDefault().GetComponent<MyToggle>().Id];

        role.SetChosen(chosenInclinations, chosenTalent);
        chosenRole?.Invoke(role);
        Destroy(gameObject);
    }
}
