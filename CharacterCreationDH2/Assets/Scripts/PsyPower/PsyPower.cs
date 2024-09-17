using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PsyPower : IName
{
    private string namePower, description, action, shortDescription;
    private int cost, psyRateRequire, id, lvl, idParent, reqCorruption = 0;
    private bool isBase;
    private List<Characteristic> requireCharacteristics;
    private string textCost;
    private List<Skill> requireSkills;
    
    public PsyPower(JSONPsyReader psyReader, string path)
    {
        description = GameStat.ReadText(path + "/Описание.txt");        
        namePower = psyReader.name;
        cost = psyReader.cost;
        psyRateRequire = psyReader.psyRate;
        id = psyReader.id;
        action = psyReader.action;
        lvl = psyReader.lvl;
        idParent = psyReader.parentId;
        shortDescription = GameStat.ReadText(path + "/Кратко.txt");
        
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
                foreach (GameStat.CharacteristicName charName in Enum.GetValues(typeof(GameStat.CharacteristicName)))
                {
                    string searchFile = $"{path}/Characteristics/{charName}.txt";
                    if (File.Exists(searchFile))
                    {
                        requireCharacteristics.Add(new Characteristic(charName, int.Parse(GameStat.ReadText(searchFile))));
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
                    requireSkills.Add(new Skill(jSONSmall.name, jSONSmall.lvl));
                }
            }
            if (File.Exists(path + "/Corruption.txt"))
            {
                reqCorruption = int.Parse(GameStat.ReadText(path + "/Corruption.txt"));
            }

        }        

            SetTextCost();
    }

    public PsyPower(string name)
    {
        namePower = name;
    }

    public string Name { get => namePower; }
    public string Description { get => description; }
    public int Cost { get => cost; }
    public int PsyRateRequire { get => psyRateRequire; }
    public int Id { get => id; }
    public bool IsBase { get => isBase; }
    public string Action { get => action; }
    public int Lvl { get => lvl; }
    public int IdParent { get => idParent; }
    public List<Characteristic> RequireCharacteristics { get => requireCharacteristics; }
    public string TextCost { get => textCost; }
    public string ShortDescription { get => shortDescription; set => shortDescription = value; }
    public List<Skill> RequireSkills { get => requireSkills; }
    public int ReqCorruption { get => reqCorruption; }

    private void SetTextCost()
    {
        textCost = $"ОО {cost}, ПР{psyRateRequire}";
        if(requireCharacteristics != null)
        {
            foreach (Characteristic characteristic in requireCharacteristics)
            {
                textCost += $", {characteristic.Name} {characteristic.Amount}";
            }
        }        
    }    

}
