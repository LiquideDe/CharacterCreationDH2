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
    private int wound, ageInt;
    private List<string> talentsName = new List<string>();
    private List<string> skills = new List<string>();
    private string age, hair, eyes, skeen, remember, body, traditions, phys, nameWorld, bonus;

    public Homeworld(string name)
    {
        //pathHomeworld = $"{Application.dataPath}/Images/Worlds/{name}/";
        pathHomeworld = name;
        string[] data = File.ReadAllLines(name + "/Parameters.JSON");
        HomeworldLoader worldReader = JsonUtility.FromJson<HomeworldLoader>(data[0]);
        nameWorld = GameStat.ReadText(pathHomeworld + "/Название.txt");
        advantageCharacteristics[0] = (GameStat.CharacterName)Enum.Parse(typeof(GameStat.CharacterName), worldReader.advantageCharacteristicsFirst);
        advantageCharacteristics[1] = (GameStat.CharacterName)Enum.Parse(typeof(GameStat.CharacterName), worldReader.advantageCharacteristicsSecond);
        disadvantageCharacteristic = (GameStat.CharacterName)Enum.Parse(typeof(GameStat.CharacterName), worldReader.disadvantageCharacteristic);
        fatepoint = worldReader.fatepoint;
        PorogFatepoint = worldReader.porogFatepoint;        
        inclination = (GameStat.Inclinations)Enum.Parse(typeof(GameStat.Inclinations), worldReader.inclination);
        wound = worldReader.wound;
        if (File.Exists(pathHomeworld + "/Skills.txt"))
        {
            skills = GameStat.ReadText(pathHomeworld + "/Skills.txt").Split(new char[] { '/' }).ToList();
        }

        if (File.Exists(pathHomeworld + "/Talents.txt"))
        {
            talentsName = GameStat.ReadText(pathHomeworld + "/Talents.txt").Split(new char[] { '/' }).ToList();
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
    public string NameWorld { get => nameWorld; }
    public int AgeInt { get => ageInt; set => ageInt = value; }
    public string Bonus { get => bonus; set => bonus = value; }
}
