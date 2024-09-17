using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CreatorPsyPowers
{
    private List<List<PsyPower>> psyPowers = new List<List<PsyPower>>();
    private List<string> schoolNames = new List<string>();
    private List<List<Connection>> connections = new List<List<Connection>>();
    private List<JSONSizeSpacing> sizeSpacings = new List<JSONSizeSpacing>();

    public CreatorPsyPowers()
    {
        List<string> dirs = new List<string>();
        dirs.AddRange(Directory.GetDirectories($"{Application.dataPath}/StreamingAssets/PsyPowers"));
        int index = 0;
        foreach(string dir in dirs)
        {
            psyPowers.Add(CreatePowers(dir));
            schoolNames.Add(GameStat.ReadText(dir + "/Название.txt"));
            connections.Add(CreateConnection(index));
            if (File.Exists(dir + "/sizeSpacing.JSON"))
            {
                string[] jSonData = File.ReadAllLines(dir + "/sizeSpacing.JSON");
                JSONSizeSpacing jSONSize = JsonUtility.FromJson<JSONSizeSpacing>(jSonData[0]);
                sizeSpacings.Add(jSONSize);
            }
            index++;
        }
    }

    public List<PsyPower> GetPowers(int school)
    {
        return psyPowers[school];
    }

    public List<Connection> GetConnections(int school)
    {
        return connections[school];
    }

    public int CountSchools()
    {
        return psyPowers.Count;
    }

    public string GetNameSchool(int school)
    {
        return schoolNames[school];
    }

    public List<string> GetNamesSchool() => schoolNames;

    public JSONSizeSpacing GetSizeSpacing(int school)
    {
        return sizeSpacings[school];
    }

    public PsyPower GetPsyPower(string name, int school)
    {
        foreach (PsyPower psy in psyPowers[school])
        {
            if (string.Compare(name, psy.Name) == 0)
            {
                return psy;
            }
        }

        throw new System.Exception($"Не смогли найти пси силу под именем {name}");
    }

    public PsyPower GetPsyPower(string name)
    {
        for(int i = 0; i < schoolNames.Count; i++)        
            foreach (PsyPower psyPower in psyPowers[i])
                if (string.Compare(name, psyPower.Name) == 0)
                    return psyPower;

        throw new System.Exception($"Не смогли найти пси силу под именем {name}");
    }

    public PsyPower GetPsyPowerById(int school, int id)
    {
        foreach (PsyPower psy in psyPowers[school])
        {
            if (psy.Id == id)
            {
                return psy;
            }
        }

        Debug.Log($"!!!! Не смогли найти пси силы школы № {school}, id = {id}");
        return null;
    }

    private List<PsyPower> CreatePowers(string dir)
    {
        List<PsyPower> powers = new List<PsyPower>();
        List<string> dirs = new List<string>();
        dirs.AddRange(Directory.GetDirectories($"{dir}"));
        
        foreach (string psyDir in dirs)
        {            
            powers.Add(CreatePsy(psyDir));
        }
        powers.Sort(
            delegate (PsyPower cb1, PsyPower cb2)
            {
                return cb1.Id.CompareTo(cb2.Id);
            }
            );
        return powers;
    }

    private PsyPower CreatePsy(string dir)
    {
        string[] data = File.ReadAllLines(dir + "/Param.JSON");
        JSONPsyReader psyReader = JsonUtility.FromJson<JSONPsyReader>(data[0]);
        PsyPower psyPower = new PsyPower(psyReader, dir);
        return psyPower;
    }

    private List<Connection> CreateConnection(int school)
    {
        List<Connection> con = new List<Connection>();
        foreach(PsyPower psy in psyPowers[school])
        {
            if(psy.Lvl != 0 )
            {
                con.Add(new Connection(GetPsyPowerById(school,psy.IdParent), psy));
            }
        }
        return con;
    }
  
}
