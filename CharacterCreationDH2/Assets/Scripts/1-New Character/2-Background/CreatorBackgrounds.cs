using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Zenject;

public class CreatorBackgrounds : ICreator
{
    private List<Background> _backgrounds = new List<Background>();

    public CreatorBackgrounds(CreatorSkills creatorSkills, CreatorTalents creatorTalents, CreatorTraits creatorTraits, CreatorImplant creatorImplant)
    {
        List<string> dirs = new List<string>();
        dirs.AddRange(Directory.GetDirectories($"{Application.dataPath}/StreamingAssets/Backgrounds"));
        for (int i = 0; i < dirs.Count; i++)
        {
            _backgrounds.Add(new Background(dirs[i],creatorSkills, creatorTalents, creatorTraits, creatorImplant));
        }
        
    }

    public int Count => _backgrounds.Count;

    IHistoryCharacter ICreator.Get(int id)
    {
        return _backgrounds[id];
    }
}
