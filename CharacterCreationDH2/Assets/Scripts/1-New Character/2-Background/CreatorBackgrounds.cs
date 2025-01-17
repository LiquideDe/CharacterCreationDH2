using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CreatorBackgrounds : ICreator
{
    public event Action CreateBackgroundIsDone;
    private List<Background> _backgrounds = new List<Background>();

    public CreatorBackgrounds(CreatorSkills creatorSkills, CreatorTalents creatorTalents, CreatorTraits creatorTraits, CreatorImplant creatorImplant,
        AudioManager audioManager)
    {
        audioManager.StartCoroutine(CreateBackgroundCoroutine(creatorSkills, creatorTalents, creatorTraits, creatorImplant));
        
    }

    public int Count => _backgrounds.Count;

    IHistoryCharacter ICreator.Get(int id)
    {
        return _backgrounds[id];
    }

    private IEnumerator CreateBackgroundCoroutine(CreatorSkills creatorSkills, CreatorTalents creatorTalents, CreatorTraits creatorTraits, CreatorImplant creatorImplant)
    {
        List<string> dirs = new List<string>();
        dirs.AddRange(Directory.GetDirectories($"{Application.dataPath}/StreamingAssets/Backgrounds"));
        for (int i = 0; i < dirs.Count; i++)
        {
            _backgrounds.Add(new Background(dirs[i], creatorSkills, creatorTalents, creatorTraits, creatorImplant));
            yield return null;
        }
        CreateBackgroundIsDone?.Invoke();
    }
}
