using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill
{
    protected GameStat.SkillName name;
    private int lvlLearned;
    private GameStat.Inclinations[] inclinations = new GameStat.Inclinations[2];

    public int LvlLearned { get { return lvlLearned; } }
    public GameStat.Inclinations[] Inclinations { get { return inclinations; } }
    public string Name { get { return name.ToString(); } }

    public Skill(GameStat.SkillName name, GameStat.Inclinations firstInclination, GameStat.Inclinations secondInclination)
    {
        this.name = name;
        inclinations[0] = firstInclination;
        inclinations[1] = secondInclination;
    }

    public Skill(GameStat.SkillName name, int lvlLearned)
    {
        this.name = name;
        this.lvlLearned = lvlLearned;
    }
    public int SetNewLvl()
    {
        Mathf.Clamp(lvlLearned + 1, 0, 4);
        return lvlLearned;
    }

    public int CancelNewLvl()
    {
        Mathf.Clamp(lvlLearned - 1, 0, 4);
        return lvlLearned;
    }
}
