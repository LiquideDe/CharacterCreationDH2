using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background 
{
    private GameStat.BackgroundName name;
    private List<List<Skill>> skills = new List<List<Skill>>();
    private List<List<string>> talents = new List<List<string>>();
    private List<List<string>> equipment = new List<List<string>>();
    private List<GameStat.Inclinations> inclinations = new List<GameStat.Inclinations>();
    private string bonusText;
    private MechImplants mechImplants;

    public Background(GameStat.BackgroundName name, List<List<Skill>> skills, List<List<string>> talents, List<List<string>> equipment, List<GameStat.Inclinations> inclinations, 
        string bonusText, MechImplants mechImplants = null)
    {
        this.name = name;
        this.skills = new List<List<Skill>>(skills);
        this.talents = new List<List<string>>(talents);
        this.equipment = new List<List<string>>(equipment);
        this.inclinations = new List<GameStat.Inclinations>(inclinations);
        this.bonusText = bonusText;
        this.mechImplants = mechImplants;
    }
}
