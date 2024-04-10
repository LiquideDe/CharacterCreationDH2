using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CreatorBackgrounds
{
    private List<Background> backgrounds = new List<Background>();
    private int id;

    public CreatorBackgrounds()
    {
        List<string> dirs = new List<string>();
        dirs.AddRange(Directory.GetDirectories($"{Application.dataPath}/StreamingAssets/Backgrounds"));
        for (int i = 0; i < dirs.Count; i++)
        {
            backgrounds.Add(new Background(dirs[i]));
        }
        
    }

    public Background GetNextBack()
    {
        if (id + 1 < backgrounds.Count)
        {
            id += 1;
        }
        else
        {
            id = 0;
        }
        return backgrounds[id];
    }

    public Background GetPrevBack()
    {
        if (id - 1 < 0)
        {
            id = backgrounds.Count - 1;
        }
        else
        {
            id -= 1;
        }
        return backgrounds[id];
    }
}
