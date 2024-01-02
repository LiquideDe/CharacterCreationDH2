using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;


public class PsyPower
{
    private string namePower, description, action, shortDescription;
    private int cost, psyRateRequire, id, lvl, idParent, reqCorruption = 0;
    private bool isBase, isActive;
    private List<Characteristic> requireCharacteristics;
    private string textCost;
    private List<Skill> requireSkills;


    
    public PsyPower(JSONPsyReader psyReader, string path)
    {
        description = ReadText(path + "/Описание.txt");        
        namePower = psyReader.name;
        cost = psyReader.cost;
        psyRateRequire = psyReader.psyRate;
        id = psyReader.id;
        action = psyReader.action;
        lvl = psyReader.lvl;
        idParent = psyReader.parentId;
        shortDescription = ReadText(path + "/Кратко.txt");
        
        if (id == 0)
        {
            isBase = true;
        }
        if (Directory.Exists(path + "/Req"))
        {
            path += "/Req";
            if (Directory.Exists(path + "/Characteristics"))
            {
                requireCharacteristics = new List<Characteristic>();
                foreach (GameStat.CharacterName charName in Enum.GetValues(typeof(GameStat.CharacterName)))
                {
                    string searchFile = $"{path}/Characteristics/{charName}.txt";
                    if (File.Exists(searchFile))
                    {
                        requireCharacteristics.Add(new Characteristic(charName, int.Parse(ReadText(searchFile))));
                    }
                }
            }

            if (Directory.Exists(path + "/Skills"))
            {
                requireSkills = new List<Skill>();
                string[] files = Directory.GetFiles(path + "/Skills", "*.JSON");
                foreach (string file in files)
                {
                    string[] jSonData = File.ReadAllLines(file);
                    JSONSmallSkillLoader jSONSmall = JsonUtility.FromJson<JSONSmallSkillLoader>(jSonData[0]);
                    requireSkills.Add(new Skill(jSONSmall.name, jSONSmall.lvl, jSONSmall.internalName));
                }
            }
            if (File.Exists(path + "/Corruption.txt"))
            {
                reqCorruption = int.Parse(ReadText(path + "/Corruption.txt"));
            }

        }
        

            UpdateTextCost();
    }

    public PsyPower(string name)
    {
        namePower = name;
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
    private void UpdateTextCost()
    {
        textCost = $"ОО {cost}";
        textCost += $", ПР{psyRateRequire}";
        if(requireCharacteristics != null)
        {
            foreach (Characteristic characteristic in requireCharacteristics)
            {
                textCost += $", {characteristic.Name} {characteristic.Amount}";
            }
        }        
    }

    public string NamePower { get => namePower; }
    public string Description { get => description; }
    public int Cost { get => cost; }
    public int PsyRateRequire { get => psyRateRequire; }
    public int Id { get => id; }
    public bool IsActive { get => isActive; set => isActive = value; }
    public bool IsBase { get => isBase; }
    public string Action { get => action; }
    public int Lvl { get => lvl; }
    public int IdParent { get => idParent; }
    public List<Characteristic> RequireCharacteristics { get => requireCharacteristics; }
    public string TextCost { get => textCost; }
    public string ShortDescription { get => shortDescription; set => shortDescription = value; }
    public List<Skill> RequireSkills { get => requireSkills; }
    public int ReqCorruption { get => reqCorruption; }

    public void ActivatePower()
    {
        isActive = true;
    }

    public void DeactivatePower()
    {
        isActive = false;
    }

}
