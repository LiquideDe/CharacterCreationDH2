using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;

public class CreatorImplant
{
    public event Action CreatingImplantIsDone;
    private List<MechImplant> implants = new List<MechImplant>();
    private AudioManager _audioManager;
    public List<MechImplant> Implants { get => implants; }

    public CreatorImplant(AudioManager audioManager) => _audioManager = audioManager;

    public void StartCreate() => _audioManager.StartCoroutine(CreateImplant());

    public void AddImplant(MechImplant implant)
    {
        implants.Add(implant);
    }

    public MechImplant GetImplant(string name)
    {
        foreach(MechImplant implant in implants)
        {
            if(string.Compare(implant.Name, name, true) == 0)
            {
                return implant;
            }
        }

        Debug.Log($"!!!!ВНИМАНИЕ!!!! Не нашли имплант {name}");
        return null;
    }

    private IEnumerator CreateImplant()
    {
        string[] implantsJson = Directory.GetFiles($"{Application.dataPath}/StreamingAssets/Implants", "*.JSON");

        foreach (string implant in implantsJson)
        {
            string[] data = File.ReadAllLines(implant);
            SaveLoadImplant implantSaveLoad = JsonUtility.FromJson<SaveLoadImplant>(data[0]);
            implants.Add(new MechImplant(implantSaveLoad));
            yield return null;
        }
        CreatingImplantIsDone?.Invoke();
    }
}
