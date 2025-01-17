using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CreatorTraits
{
    public event Action TraitsIsCreated;
    List<Trait> traits = new List<Trait>();
    private AudioManager _audioManager;
    public List<Trait> Traits { get => traits; }

    public CreatorTraits(AudioManager audioManager) => _audioManager = audioManager;

    public void StartCreating() => _audioManager.StartCoroutine(CreateTraitsCoroutine());

    public Trait GetTrait(string name)
    {
        foreach(Trait trait in traits)
        {
            if (string.Compare(name, trait.Name, true) == 0)
                return trait;
        }

        Debug.Log($"Не смогли найти feature {name}");
        return null;
    }

    private IEnumerator CreateTraitsCoroutine()
    {
        List<string> dirs = new List<string>();
        dirs.AddRange(Directory.GetDirectories($"{Application.dataPath}/StreamingAssets/Traits"));
        foreach (string path in dirs)
        {
            traits.Add(new Trait(GameStat.ReadText(path + "/Название.txt"), GameStat.ReadText(path + "/Описание.txt")));
            yield return null;
        }
        TraitsIsCreated?.Invoke();
    }
}
