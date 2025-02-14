using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class CreatorTalents
{
    public event Action CreateTalentIsDone;

    private List<Talent> talents = new List<Talent>();
    private CreatorSkills _creatorSkills;
    private CreatorTraits _creatorTraits;

    public List<Talent> Talents { get => talents; }

    public CreatorTalents(CreatorSkills creatorSkills, CreatorTraits creatorTraits)
    {
        _creatorSkills = creatorSkills;
        _creatorTraits = creatorTraits;
    }

    public void StartCreating() => CreateTalent().Forget();
    

    public Talent GetTalent(string name)
    {
        foreach (Talent talent in talents)
        {
            if (string.Compare(talent.Name, name,true) == 0)
            {
                return talent;
            }
        }

        Debug.Log($"!!!!! Не нашли талантант !!!! Искали {name}");
        return null;
    }

    private async UniTask CreateTalent()
    {
        List<string> dirs = new List<string>();
        dirs.AddRange(Directory.GetDirectories($"{Application.dataPath}/StreamingAssets/Talents"));
        for (int i = 0; i < dirs.Count; i++)
        {
            if (!dirs[i].Contains("Elite") && !dirs[i].Contains("Example"))
            {
                talents.Add(new Talent(dirs[i], _creatorSkills, this, _creatorTraits));
                await UniTask.Yield();
            }
        }
        dirs.Clear();
        dirs.AddRange(Directory.GetDirectories($"{Application.dataPath}/StreamingAssets/Talents/Elite"));
        for (int i = 0; i < dirs.Count; i++)
        {
            if (!dirs[i].Contains("Example"))
            {
                talents.Add(new Talent(dirs[i], _creatorSkills, this, _creatorTraits));
                await UniTask.Yield();
            }
        }
        CreateTalentIsDone?.Invoke();
    }
}
