using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using UnityEngine.UI;

public class RoleVisual : ToggleVisual
{
    public delegate void ChosenRole(Role chosenRole);
    private ChosenRole chosenRole;
    private CreatorTalents creatorTalents;
    [SerializeField] GameObject finalPanel;
    private Role role;
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

    public void regFinalDelegate(ChosenRole chosenRole, CreatorTalents creatorTalents)
    {
        this.chosenRole = chosenRole;
        this.creatorTalents = creatorTalents;
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
            //if (incl.Count > 1)
            //{
                CreateToggleGroup("Склонности");
                for (int i = 0; i < incl.Count; i++)
                {
                    CreateToggle(GameStat.inclinationTranslate[incl[i]], i, GameStat.descriptionInclination[incl[i]]);
                }
            //}
        }

        CreateToggleGroup("Таланты");
        int sc = 0;
        foreach(string talent in role.Talents)
        {
            CreateToggle(talent, sc, creatorTalents.GetTalent(talent).Description);
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
