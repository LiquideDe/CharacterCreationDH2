using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Role
{
    private GameStat.RoleName name;
    private List<List<GameStat.Inclinations>> inclinations = new List<List<GameStat.Inclinations>>();
    private List<string> talents = new List<string>();
    private string textBonus;

    public Role(GameStat.RoleName name, string textBonus, List<List<GameStat.Inclinations>> inclinations, List<string> talents)
    {
        this.inclinations = new List<List<GameStat.Inclinations>>(inclinations);
        this.talents = new List<string>(talents);
        this.textBonus = textBonus;
    }
}
