using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class CreatorWorlds
{
    private List<Homeworld> homeworlds = new List<Homeworld>();
    private int id;

    public CreatorWorlds()
    {
        List<string> dirs = new List<string>();
        dirs.AddRange(Directory.GetDirectories($"{Application.dataPath}/StreamingAssets/Worlds"));
        Debug.Log($"{dirs[0]}");
        for (int i = 0; i < dirs.Count; i++)
        {
            homeworlds.Add(new Homeworld(dirs[i]));
        }
    }

    public Homeworld GetNextWorld()
    {
        if(id + 1 < homeworlds.Count)
        {
            id += 1;
        }
        else
        {
            id = 0;
        }

        return homeworlds[id];
    }

    public Homeworld GetPrevWorld()
    {
        if(id - 1 < 0)
        {
            id = homeworlds.Count - 1;
        }
        else
        {
            id -= 1;
        }
        return homeworlds[id];
    }
}
