using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Role
{
    private GameStat.RoleName name;
    private List<List<GameStat.Inclinations>> inclinations = new List<List<GameStat.Inclinations>>();
    private List<string> talents = new List<string>();
    private string pathRole;
    private List<GameStat.Inclinations> chosenInclinations = new List<GameStat.Inclinations>();
    private string chosenTalent;

    public Role(GameStat.RoleName name, List<List<GameStat.Inclinations>> inclinations, List<string> talents)
    {
        this.inclinations = new List<List<GameStat.Inclinations>>(inclinations);
        this.talents = new List<string>(talents);
        this.name = name;
        pathRole = $"{Application.dataPath}/StreamingAssets/Images/Roles/{name}/";
    }

    public void SetChosen(List<GameStat.Inclinations> chosenInclinations, string chosenTalent)
    {
        this.chosenInclinations = new List<GameStat.Inclinations>(chosenInclinations);
        this.chosenTalent = chosenTalent;
    }

    public string PathRole { get => pathRole; }
    public List<string> Talents { get => talents; }
    public List<List<GameStat.Inclinations>> Inclinations { get => inclinations; }
    public string ChosenTalent { get => chosenTalent; }
    public List<GameStat.Inclinations> ChosenInclinations { get => chosenInclinations; }
    public string Name { get => GameStat.roleTranslation[name]; }
}
