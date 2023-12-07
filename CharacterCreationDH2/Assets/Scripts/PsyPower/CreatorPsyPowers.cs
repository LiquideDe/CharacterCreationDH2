using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.IO;
using System.Text;
using System.Linq;
using System;

public class CreatorPsyPowers
{
    private List<List<PsyPower>> psyPowers = new List<List<PsyPower>>();
    private List<string> schoolNames = new List<string>();
    private List<List<Connection>> connections = new List<List<Connection>>();
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
        var namePsy = psyReader.name;
        var description = ReadText(dir + "/Описание.txt");
        var action = psyReader.action;
        Characteristic[] characteristics = new Characteristic[9];
        characteristics[0] = new Characteristic(GameStat.CharacterName.WeaponSkill, SetAmountForReqCharacteristic(dir + "/WS.txt"));
        characteristics[1] = new Characteristic(GameStat.CharacterName.BallisticSkill, SetAmountForReqCharacteristic(dir + "/BS.txt"));
        characteristics[2] = new Characteristic(GameStat.CharacterName.Strength, SetAmountForReqCharacteristic(dir + "/S.txt"));
        characteristics[3] = new Characteristic(GameStat.CharacterName.Toughness, SetAmountForReqCharacteristic(dir + "/T.txt"));
        characteristics[4] = new Characteristic(GameStat.CharacterName.Agility, SetAmountForReqCharacteristic(dir + "/A.txt"));
        characteristics[5] = new Characteristic(GameStat.CharacterName.Intelligence, SetAmountForReqCharacteristic(dir + "/I.txt"));
        characteristics[6] = new Characteristic(GameStat.CharacterName.Perception, SetAmountForReqCharacteristic(dir + "/P.txt"));
        characteristics[7] = new Characteristic(GameStat.CharacterName.Willpower, SetAmountForReqCharacteristic(dir + "/W.txt"));
        characteristics[8] = new Characteristic(GameStat.CharacterName.Fellowship, SetAmountForReqCharacteristic(dir + "/F.txt"));
        
        PsyPower psyPower = new PsyPower(namePsy, description, psyReader.cost, psyReader.psyRate, psyReader.id, psyReader.lvl, action, psyReader.parentId, characteristics);
        psyPower.ShortDescription = ReadText(dir + "/Кратко.txt");
        string searchDir = "";
        foreach(GameStat.SkillName skillName in Enum.GetValues(typeof(GameStat.SkillName)))
        {
            searchDir = dir + "/" + skillName.ToString() + ".txt";
            if (File.Exists(searchDir))
            {
                int lvl = int.Parse(ReadText(searchDir));
                psyPower.AddReqSkill(new Skill(skillName, lvl));
            }
        }
        return psyPower;
    }

    private int SetAmountForReqCharacteristic(string path)
    {
        if (File.Exists(path))
        {
            return int.Parse(ReadText(path));
        }
        else
        {
            return 0;
        }
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
            CheckCharacteristics(psyPower.RequireCharacteristics, character.Characteristics) && !psyPower.IsActive && CheckSkills(character.Skills, psyPower.RequireSkills))
        {
            return true;
        }
        Debug.Log($"False");
        return false;
    }

    private bool CheckCharacteristics(Characteristic[] psyReq, List<Characteristic> characteristics)
    {
        foreach(Characteristic psyReqCharacteristic in psyReq)
        {
            foreach(Characteristic characteristic in characteristics)
            {
                if(psyReqCharacteristic.InternalName == characteristic.InternalName)
                {
                    if (characteristic.Amount < psyReqCharacteristic.Amount)
                    {
                        return false;
                    }
                }
            }
        }

        return true;
        
    }

    private bool CheckSkills(List<Skill> characterSkills, List<Skill> reqSkills)
    {
        int sum = 0;
        if (reqSkills.Count > 0)
        {
            foreach (Skill reqSkill in reqSkills)
            {
                foreach (Skill charSkill in characterSkills)
                {
                    if (reqSkill.InternalName == charSkill.InternalName)
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

        if(sum == reqSkills.Count)
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
}
