using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background 
{
    private GameStat.BackgroundName name;
    private List<List<Skill>> skills = new List<List<Skill>>();
    private List<List<string>> talents = new List<List<string>>();
    private List<List<Equipment>> equipment = new List<List<Equipment>>();
    private List<GameStat.Inclinations> inclinations = new List<GameStat.Inclinations>();
    private MechImplants mechImplants;
    private string pathBackground;
    private List<Skill> chosenSkills = new List<Skill>();
    private List<string> chosenTalents = new List<string>();
    private List<Equipment> chosenEquipments = new List<Equipment>();
    private GameStat.Inclinations chosenInclination;
    private string rememberThing, bonus;

    public Background(GameStat.BackgroundName name, List<List<Skill>> skills, List<List<string>> talents, List<List<Equipment>> equipment, List<GameStat.Inclinations> inclinations, 
        MechImplants mechImplants = null)
    {
        this.name = name;
        this.skills = new List<List<Skill>>(skills);
        this.talents = new List<List<string>>(talents);
        this.equipment = new List<List<Equipment>>(equipment);
        this.inclinations = new List<GameStat.Inclinations>(inclinations);
        this.mechImplants = mechImplants;
        pathBackground = $"{Application.dataPath}/StreamingAssets/Images/Backgrounds/{name}/";
    }

    public void SetChosen(List<Skill> chosenSkills, List<string> chosenTalents, List<Equipment> chosenEquipments, GameStat.Inclinations chosenInclination, string rememberThing)
    {
        this.chosenSkills = new List<Skill>(chosenSkills);
        this.chosenTalents = new List<string>(chosenTalents);
        this.chosenEquipments = new List<Equipment>(chosenEquipments);
        this.chosenInclination = chosenInclination;
        this.rememberThing = rememberThing;
    }

    public string PathBackground { get => pathBackground; }
    public List<List<string>> Talents { get => talents; }
    public List<List<Skill>> Skills { get => skills; }
    public List<List<Equipment>> Equipment { get => equipment; }
    public List<GameStat.Inclinations> Inclinations { get => inclinations;  }
    public List<Skill> ChosenSkills { get => chosenSkills;}
    public List<string> ChosenTalents { get => chosenTalents;}
    public List<Equipment> ChosenEquipments { get => chosenEquipments;}
    public GameStat.Inclinations ChosenInclination { get => chosenInclination;}
    public MechImplants MechImplants { get => mechImplants; set => mechImplants = value; }
    public string Name { get => GameStat.backstoryTranslation[name]; }
    public string RememberThing { get => rememberThing; }
    public string Bonus { get => bonus; set => bonus = value; }
}
