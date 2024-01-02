using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class Skill
{
    protected string name, internalName;
    private int lvlLearned;
    protected bool isKnowledge;
    private GameStat.Inclinations[] inclinations = new GameStat.Inclinations[2];
    private string description, typeSkill;
    public string Description { get => description; }
    public GameStat.Inclinations[] Inclinations { get { return inclinations; } }
    public string Name { get { return name; } }
    public string InternalName { get => internalName; }
    public int LvlLearned { get => lvlLearned; set => lvlLearned = value; }
    public bool IsKnowledge { get => isKnowledge; }
    public string TypeSkill { get => typeSkill; }

    public Skill(JSONSkillLoader skillLoader ,string path)
    {
        name = skillLoader.name;
        internalName = skillLoader.internalName;
        inclinations[0] = (GameStat.Inclinations)Enum.Parse(typeof(GameStat.Inclinations), skillLoader.firstInclination);
        inclinations[1] = (GameStat.Inclinations)Enum.Parse(typeof(GameStat.Inclinations), skillLoader.secondInclination);
        typeSkill = skillLoader.type;
        description = ReadText(path + "/Описание.txt");
    }

    public Skill(string name, int lvlLearned)
    {
        this.name = name;
        this.lvlLearned = lvlLearned;
    }

    public Skill(Skill skill, int lvlLearned)
    {
        this.name = skill.InternalName;
        this.lvlLearned = lvlLearned;
        this.description = skill.Description;
    }

    public Skill(string name, int lvl, string internalName)
    {
        this.name = name;
        this.lvlLearned = lvl;
        this.internalName = internalName;
    }
    protected string ReadText(string nameFile)
    {
        string txt;
        using (StreamReader _sw = new StreamReader(nameFile, Encoding.Default))
        {
            txt = (_sw.ReadToEnd());
            _sw.Close();
        }
        return txt;
    }
    public int SetNewLvl()
    {
        lvlLearned++;
        Mathf.Clamp(lvlLearned, 0, 4);
        return lvlLearned;
    }

    public int CancelNewLvl()
    {
        lvlLearned--;
        Mathf.Clamp(lvlLearned - 1, 0, 4);
        return lvlLearned;
    }

    public int CalculateInclinations(List<GameStat.Inclinations> charIncl)
    {
        int sumIncls = 0;
        foreach(GameStat.Inclinations incl in charIncl)
        {
            if(incl == inclinations[0] || incl == inclinations[1])
            {
                sumIncls++;
            }
        }

        return sumIncls;
        //cost = ((lvlLearned + 1) * 300) - (100 * sumIncls * (lvlLearned + 1));
    }
}
