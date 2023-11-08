using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homeworld 
{
    private string bonusHomeworld;
    private int fatepoint;
    private GameStat.WorldName name;
    private GameStat.CharacterName[] advantageCharacteristics = new GameStat.CharacterName[2];
    private GameStat.CharacterName disadvantageCharacteristic;
    private GameStat.Inclinations inclination;
    private int wound;
    private List<string> talentsName = new List<string>();
    private List<string> bonusSkills = new List<string>();

    public Homeworld(GameStat.WorldName name, GameStat.CharacterName firstAdvantage, GameStat.CharacterName secondAdvantage, GameStat.CharacterName disadvantageCharacteristic, int fatepoint, 
        string bonusHomeworld, GameStat.Inclinations inclination, int wound)
    {
        this.name = name;
        advantageCharacteristics[0] = firstAdvantage;
        advantageCharacteristics[1] = secondAdvantage;
        this.disadvantageCharacteristic = disadvantageCharacteristic;
        this.fatepoint = fatepoint;
        this.bonusHomeworld = bonusHomeworld;
        this.inclination = inclination;
        this.wound = wound;
        
    }

    public void AddTalent(string talentName)
    {
        talentsName.Add(talentName);
    }

    public void AddSkill(string skillName)
    {
        bonusSkills.Add(skillName);
    }

    public List<string> GetSkillBonus()
    {
        if (bonusSkills.Count > 0)
        {
            return bonusSkills;
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

    public string BonusHomeworld { get => bonusHomeworld;}
    public int Fatepoint { get => fatepoint;}
    public string Name { get => name.ToString();}
    public GameStat.CharacterName[] AdvantageCharacteristics { get => advantageCharacteristics;}
    public GameStat.CharacterName DisadvantageCharacteristic { get => disadvantageCharacteristic;}
    public GameStat.Inclinations Inclination { get => inclination;}
    public int Wound { get => wound;}
}
