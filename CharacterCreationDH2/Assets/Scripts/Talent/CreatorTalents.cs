using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CreatorTalents
{
    private List<Talent> talents = new List<Talent>();

    public List<Talent> Talents { get => talents; }

    public CreatorTalents()
    {
        List<string> dirs = new List<string>();
        dirs.AddRange(Directory.GetDirectories($"{Application.dataPath}/StreamingAssets/Talents"));
        for (int i = 0; i < dirs.Count; i++)
        {
            if (!dirs[i].Contains("Elite") && !dirs[i].Contains("Example"))
            {
                talents.Add(new Talent(dirs[i], true));
            }
        }
    }

    public Talent GetTalent(string name)
    {
        foreach (Talent talent in talents)
        {
            if (talent.Name == name)
            {
                return talent;
            }
        }

        Debug.Log($"!!!!! Не нашли талантант !!!! Искали {name}");
        return null;
    }

    public void CalculationCost(List<GameStat.Inclinations> inclinations)
    {
        foreach(Talent talent in talents)
        {
            talent.CalculateCost(inclinations);
        }
    }
}
