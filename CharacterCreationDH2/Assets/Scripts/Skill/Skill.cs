using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill
{
    protected GameStat.SkillName name;
    private int lvlLearned;
    private int cost;
    private GameStat.Inclinations[] inclinations = new GameStat.Inclinations[2];
    private string description;
    public string Description { get => description; }
    public GameStat.Inclinations[] Inclinations { get { return inclinations; } }
    public string Name { get { return GameStat.skillTranslate[name]; } }
    public GameStat.SkillName InternalName { get => name; }

    public int Cost { get => cost; }
    public int LvlLearned { get => lvlLearned; }

    public Skill(GameStat.SkillName name, GameStat.Inclinations firstInclination, GameStat.Inclinations secondInclination, string description)
    {
        this.name = name;
        inclinations[0] = firstInclination;
        inclinations[1] = secondInclination;
        this.description = description;
    }

    public Skill(GameStat.SkillName name, int lvlLearned)
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

    public bool IsKnowledge()
    {
        if (InternalName == GameStat.SkillName.CommonLore || InternalName == GameStat.SkillName.ForbiddenLore ||
                        InternalName == GameStat.SkillName.Linquistics || InternalName == GameStat.SkillName.ScholasticLore || InternalName == GameStat.SkillName.Trade)
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }
}