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
            features.Add(new Feature(GameStat.ReadText(path + "/Название.txt"), GameStat.ReadText(path + "/Описание.txt")));
        }
    }

    public Feature GetFeature(string name)
    {
        foreach(Feature feature in features)
        {
            if (string.Compare(name, feature.Name, true) == 0)
                return feature;
        }

        Debug.Log($"Не смогли найти feature {name}");
        return null;
    }
}
