using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class Skill : IName
{
    protected string _name, _internalName;
    private int _lvlLearned;
    protected bool _isKnowledge;
    private GameStat.Inclinations[] _inclinations = new GameStat.Inclinations[2];
    private string _description, _typeSkill;
    public string Description { get => _description; }
    public GameStat.Inclinations[] Inclinations { get { return _inclinations; } }
    public string Name => _name;
    public string InternalName => _internalName; 
    public int LvlLearned { get => _lvlLearned; set => _lvlLearned = value; }
    public bool IsKnowledge  => _isKnowledge; 
    public string TypeSkill => _typeSkill; 

    public override bool Equals(object? obj)
    {
        if (obj is Skill skill) return _internalName == skill.InternalName;
        return false;
    }

    public override int GetHashCode() => _internalName.GetHashCode();

    public Skill(JSONSkillLoader skillLoader ,string path)
    {
        _name = skillLoader.name;
        _internalName = skillLoader.internalName;
        _inclinations[0] = (GameStat.Inclinations)Enum.Parse(typeof(GameStat.Inclinations), skillLoader.firstInclination);
        _inclinations[1] = (GameStat.Inclinations)Enum.Parse(typeof(GameStat.Inclinations), skillLoader.secondInclination);
        _typeSkill = skillLoader.type;
        _description = GameStat.ReadText(path + "/Описание.txt");
    }

    public Skill(Skill skill, int lvlLearned)
    {
        _name = skill.Name;
        _lvlLearned = lvlLearned;
        _internalName = skill.InternalName;
        _inclinations[0] = skill.Inclinations[0];
        _inclinations[1] = skill.Inclinations[1];
        _typeSkill = skill.TypeSkill;
        _isKnowledge = skill.IsKnowledge;
    }

    public Skill(string name, int lvl, string internalName)
    {
        _name = name;
        _lvlLearned = lvl;
        _internalName = internalName;
    }
    public int SetNewLvl()
    {
        _lvlLearned++;
        Mathf.Clamp(_lvlLearned, 0, 4);
        return _lvlLearned;
    }

    public int CancelNewLvl()
    {
        _lvlLearned--;
        Mathf.Clamp(_lvlLearned - 1, 0, 4);
        return _lvlLearned;
    }

    public int CalculateInclinations(List<GameStat.Inclinations> charIncl)
    {
        int sumIncls = 0;
        foreach(GameStat.Inclinations incl in charIncl)
        {
            if(incl == _inclinations[0] || incl == _inclinations[1])
            {
                sumIncls++;
            }
        }

        return sumIncls;
        //cost = ((lvlLearned + 1) * 300) - (100 * sumIncls * (lvlLearned + 1));
    }
}
