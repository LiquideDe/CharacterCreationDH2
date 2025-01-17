using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System;
using System.Collections;

public class CreatorWorlds : ICreator
{
    public event Action CreateWorldIsFinished;
    private List<Homeworld> homeworlds = new List<Homeworld>();

    public CreatorWorlds(CreatorSkills creatorSkills, AudioManager audioManager)
    {
        audioManager.StartCoroutine(CreateWorldsCoroutine(creatorSkills));
    }

    public int Count => homeworlds.Count;

    public IHistoryCharacter Get(int id)
    {
        return homeworlds[id];
    }
    
    private IEnumerator CreateWorldsCoroutine(CreatorSkills creatorSkills)
    {
        List<string> dirs = new List<string>();
        dirs.AddRange(Directory.GetDirectories($"{Application.dataPath}/StreamingAssets/Worlds"));
        for (int i = 0; i < dirs.Count; i++)
        {
            homeworlds.Add(new Homeworld(dirs[i], creatorSkills));
            yield return null;
        }
        CreateWorldIsFinished?.Invoke();
    }
}
