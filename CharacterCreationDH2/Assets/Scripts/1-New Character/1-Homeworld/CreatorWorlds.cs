using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CreatorWorlds : ICreator
{
    private List<Homeworld> homeworlds = new List<Homeworld>();

    public CreatorWorlds(CreatorSkills creatorSkills)
    {
        List<string> dirs = new List<string>();
        dirs.AddRange(Directory.GetDirectories($"{Application.dataPath}/StreamingAssets/Worlds"));
        for (int i = 0; i < dirs.Count; i++)
        {
            homeworlds.Add(new Homeworld(dirs[i], creatorSkills));
        }
    }

    public int Count => homeworlds.Count;

    public IHistoryCharacter Get(int id)
    {
        return homeworlds[id];
    }
    
}
