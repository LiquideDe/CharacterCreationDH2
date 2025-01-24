using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;

public class CreatorTalents
{
    public event Action CreateTalentIsDone;

    private List<Talent> talents = new List<Talent>();
    private AudioManager _audioManager;

    public List<Talent> Talents { get => talents; }

    public CreatorTalents(AudioManager audioManager) => _audioManager = audioManager;        
    

    public void StartCreating() => _audioManager.StartCoroutine(CreateTalentCoroutine());
    

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

    private IEnumerator CreateTalentCoroutine()
    {
        List<string> dirs = new List<string>();
        dirs.AddRange(Directory.GetDirectories($"{Application.dataPath}/StreamingAssets/Talents"));        
        for (int i = 0; i < dirs.Count; i++)
        {
            if (!dirs[i].Contains("Elite") && !dirs[i].Contains("Example"))
            {
                talents.Add(new Talent(dirs[i], true));
                yield return null;
            }
        }
        CreateTalentIsDone?.Invoke();
    }
}
