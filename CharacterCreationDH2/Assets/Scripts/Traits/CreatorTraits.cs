using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Cysharp.Threading.Tasks;
public class CreatorTraits
{
    public event Action TraitsIsCreated;
    List<Trait> traits = new List<Trait>();
    public List<Trait> Traits { get => traits; }

    public void StartCreating() => CreateTraits().Forget();

    public Trait GetTrait(string name)
    {
        foreach(Trait trait in traits)
        {
            if (string.Compare(name, trait.Name, true) == 0)
                return trait;
        }

        Debug.Log($"Не смогли найти trait {name}");
        return null;
    }

    private async UniTask CreateTraits()
    {
        List<string> dirs = new List<string>();
        dirs.AddRange(Directory.GetDirectories($"{Application.dataPath}/StreamingAssets/Traits"));
        foreach (string path in dirs)
        {
            traits.Add(new Trait(GameStat.ReadText(path + "/Название.txt"), GameStat.ReadText(path + "/Описание.txt")));
            await UniTask.Yield();
        }
        TraitsIsCreated?.Invoke();
    }
}
