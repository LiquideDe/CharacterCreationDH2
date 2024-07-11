using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CreatorImplant
{
    private List<MechImplant> implants = new List<MechImplant>();
    public List<MechImplant> Implants { get => implants; }

    public CreatorImplant()
    {
        string[] implantsJson = Directory.GetFiles($"{Application.dataPath}/StreamingAssets/Implants", "*.JSON");

        foreach(string implant in implantsJson)
        {
            string[] data = File.ReadAllLines(implant);
            SaveLoadImplant implantSaveLoad = JsonUtility.FromJson<SaveLoadImplant>(data[0]);
            implants.Add(new MechImplant(implantSaveLoad));
        }
    }

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
}
