using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CreatorFeatures
{
    List<Feature> features = new List<Feature>();
    public List<Feature> Features { get => features; }

    public CreatorFeatures()
    {
        List<string> dirs = new List<string>();
        dirs.AddRange(Directory.GetDirectories($"{Application.dataPath}/StreamingAssets/Features"));
        foreach(string path in dirs)
        {
            features.Add(new Feature(GameStat.ReadText(path + "/Название.txt"),0));
        }
    }
}
