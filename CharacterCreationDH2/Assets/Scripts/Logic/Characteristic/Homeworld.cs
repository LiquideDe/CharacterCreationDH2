using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System.Linq;
using System;

public class Homeworld 
{
    private string pathHomeworld;
    private int fatepoint;
    private int porogFatepoint;
    private GameStat.CharacterName[] advantageCharacteristics = new GameStat.CharacterName[2];
    private GameStat.CharacterName disadvantageCharacteristic;
    private GameStat.Inclinations inclination;
    private int wound;
    private List<string> talentsName = new List<string>();
    private List<string> skills = new List<string>();
    private string age, hair, eyes, skeen, remember, body, traditions, phys;

    public Homeworld(string name)
    {
        //pathHomeworld = $"{Application.dataPath}/Images/Worlds/{name}/";
        pathHomeworld = name;
        List<string> parameters = new List<string>();
        parameters = ReadText(pathHomeworld + "/Parameters.txt").Split(new char[] { '/' }).ToList();
        advantageCharacteristics[0] = (GameStat.CharacterName)Enum.Parse(typeof(GameStat.CharacterName), parameters[0]);
        advantageCharacteristics[1] = (GameStat.CharacterName)Enum.Parse(typeof(GameStat.CharacterName), parameters[1]);
        disadvantageCharacteristic = (GameStat.CharacterName)Enum.Parse(typeof(GameStat.CharacterName), parameters[2]);
        fatepoint = int.Parse(parameters[3]);
        PorogFatepoint = int.Parse(parameters[4]);        
        inclination = (GameStat.Inclinations)Enum.Parse(typeof(GameStat.Inclinations), parameters[5]);
        wound = int.Parse(parameters[6]);
        if (File.Exists(pathHomeworld + "/Skills.txt"))
        {
            skills = ReadText(pathHomeworld + "/Skills.txt").Split(new char[] { '/' }).ToList();
        }

        if (File.Exists(pathHomeworld + "/Talents.txt"))
        {
            talentsName = ReadText(pathHomeworld + "/Talents.txt").Split(new char[] { '/' }).ToList();
        }
    }

    public List<string> GetSkills()
    {
        if (skills.Count > 0)
        {
            return skills;
        }
        else
        {
            return null;
        }
    }

    public List<string> GetTalents()
    {
        if(talentsName.Count > 0)
        {
            return talentsName;
        }
        else
        {
            return null;
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

    public int IsBonusFate(int bonus)
    {
        if(bonus >= PorogFatepoint)
        {
            return fatepoint + 1;
        }
        else
        {
            return fatepoint;
        }
    }

    public string PathHomeworld { get => pathHomeworld;}
    public int Fatepoint { get => fatepoint; set => fatepoint = value; }
    public GameStat.CharacterName[] AdvantageCharacteristics { get => advantageCharacteristics;}
    public GameStat.CharacterName DisadvantageCharacteristic { get => disadvantageCharacteristic;}
    public GameStat.Inclinations Inclination { get => inclination;}
    public int Wound { get => wound; set => wound = value; }
    public string Age { get => age; set => age = value; }
    public string Hair { get => hair; set => hair = value; }
    public string Eyes { get => eyes; set => eyes = value; }
    public string Skeen { get => skeen; set => skeen = value; }
    public string Remember { get => remember; set => remember = value; }
    public string Body { get => body; set => body = value; }
    public string Traditions { get => traditions; set => traditions = value; }
    public string Phys { get => phys; set => phys = value; }
    public int PorogFatepoint { get => porogFatepoint; set => porogFatepoint = value; }
}
