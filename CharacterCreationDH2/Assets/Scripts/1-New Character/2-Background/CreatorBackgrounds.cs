using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Zenject;

public class CreatorBackgrounds : ICreator
{
    private List<Background> _backgrounds = new List<Background>();
    private int _id;
    private CreatorSkills _creatorSkills;
    private CreatorTalents _creatorTalents;

    public CreatorBackgrounds(CreatorSkills creatorSkills, CreatorTalents creatorTalents)
    {
        _creatorSkills = creatorSkills;
        _creatorTalents = creatorTalents;
        List<string> dirs = new List<string>();
        dirs.AddRange(Directory.GetDirectories($"{Application.dataPath}/StreamingAssets/Backgrounds"));
        for (int i = 0; i < dirs.Count; i++)
        {
            _backgrounds.Add(new Background(dirs[i],_creatorSkills, _creatorTalents));
        }
        
    }

    public int Count => _backgrounds.Count;

    IHistoryCharacter ICreator.Get(int id)
    {
        return _backgrounds[id];
    }
}
