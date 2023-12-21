using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Text;
using System;

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
            schoolNames.Add(ReadText(dir + "/Название.txt"));
            connections.Add(CreateConnection(index));
            if (File.Exists(dir + "/sizeSpacing.JSON"))
            {
                Debug.Log($"Finded");
                string[] jSonData = File.ReadAllLines(dir + "/sizeSpacing.JSON");
                JSONSizeSpacing jSONSize = JsonUtility.FromJson<JSONSizeSpacing>(jSonData[0]);
                sizeSpacings.Add(jSONSize);
            }
            index++;
        }
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

    private string ReadText(string nameFile)
    {
        string txt;
        using (StreamReader _sw = new StreamReader(nameFile, Encoding.Default))
        {
            txt = (_sw.ReadToEnd());
            _sw.Close();
        }
        return txt;
    }

    private List<Connection> CreateConnection(int school)
    {
        List<Connection> con = new List<Connection>();
        foreach(PsyPower psy in psyPowers[school])
        {
            if(psy.Id != 0 )
            {
                con.Add(new Connection(GetPsyPowerById(school,psy.IdParent), psy));
            }
        }
        return con;
    }
    private bool CheckPowerForPossibleConnect(PsyPower psy, int school)
    {
        bool answ = false;
        
        foreach (Connection connection in connections[school])
        {
            if(connection.ChildPsyPower == psy)
            {
                if (connection.ParentPsyPower.IsActive)
                {
                    answ = true;
                }
            }
            else if (psy.IsBase)
            {
                answ = true;
            }
        }

        return answ;
    }

    public PsyPower GetPsyPowerById(int school, int id)
    {
        foreach(PsyPower psy in psyPowers[school])
        {
            if(psy.Id == id)
            {
                return psy;
            }
        }

        Debug.Log($"!!!! Не смогли найти пси силы школы № {school}, id = {id}");
        return null;
    }

    public bool CheckPowerForAdding(int school, int id, Character character)
    {
        PsyPower psyPower = GetPsyPowerById(school, id);
        if(psyPower.PsyRateRequire <= character.PsyRating && psyPower.Cost <= character.ExperienceUnspent && CheckPowerForPossibleConnect(psyPower, school) &&
            CheckCharacteristics(psyPower.RequireCharacteristics, character.Characteristics) && !psyPower.IsActive && CheckSkills(character.Skills, psyPower.RequireSkills) && 
            CheckCorruption(psyPower.ReqCorruption, character.CorruptionPoints))
        {
            return true;
        }
        Debug.Log($"False");
        return false;
    }

    private bool CheckCharacteristics(List<Characteristic> psyReq, List<Characteristic> characteristics)
    {
        if (psyReq != null)
        {
            foreach (Characteristic psyReqCharacteristic in psyReq)
            {
                foreach (Characteristic characteristic in characteristics)
                {
                    if (psyReqCharacteristic.InternalName == characteristic.InternalName)
                    {
                        if (characteristic.Amount < psyReqCharacteristic.Amount)
                        {
                            return false;
                        }
                    }
                }
            }
        }        

        return true;
        
    }

    private bool CheckSkills(List<Skill> characterSkills, List<Skill> reqSkills)
    {
        if (reqSkills != null)
        {
            int sum = 0;

            if (reqSkills.Count > 0)
            {
                foreach (Skill reqSkill in reqSkills)
                {
                    foreach (Skill charSkill in characterSkills)
                    {
                        if (reqSkill.Name == charSkill.Name)
                        {
                            if (charSkill.LvlLearned >= reqSkill.LvlLearned)
                            {
                                sum++;
                            }
                        }
                    }
                }
            }
            else
            {
                return true;
            }

            if (sum == reqSkills.Count)
            {
                Debug.Log($"Сумма навыков такая же, возвращаемт тру");
                return true;
            }
            else
            {
                Debug.Log($"Сумма навыков НЕ такая же, возвращаемт false");
                return false;
            }
        }
        else
            return true;
        
    }

    private bool CheckCorruption(int reqCor, int characterCor)
    {
        if(reqCor <= characterCor)
        {
            return true;
        }
        return false;
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

    public JSONSizeSpacing GetSizeSpacing(int school)
    {
        return sizeSpacings[school];
    }
}
