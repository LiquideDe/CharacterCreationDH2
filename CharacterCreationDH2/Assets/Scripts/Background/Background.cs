using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

public class Background 
{
    private string name;
    private List<List<Skill>> skills = new List<List<Skill>>();
    private List<List<string>> talents = new List<List<string>>();
    private List<List<Equipment>> equipments = new List<List<Equipment>>();
    private List<GameStat.Inclinations> inclinations = new List<GameStat.Inclinations>();
    private List<MechImplant> mechImplants;
    private string pathBackground;
    private List<Skill> chosenSkills = new List<Skill>();
    private List<string> chosenTalents = new List<string>();
    private List<Equipment> chosenEquipments = new List<Equipment>();
    private GameStat.Inclinations chosenInclination;
    private string rememberThing, bonus;

    public Background(string path)
    {
        pathBackground = path;
        name = GameStat.ReadText(path + "/Название.txt");
        if (File.Exists(path + "/Get/Inclinations.txt"))
        {
            List<string> incs = GameStat.ReadText(pathBackground + "/Get/Inclinations.txt").Split(new char[] { '/' }).ToList();
            foreach(string incl in incs)
            {
                inclinations.Add((GameStat.Inclinations)Enum.Parse(typeof(GameStat.Inclinations), incl));
            }
        }

        if(Directory.Exists(path + "/Get/Skills"))
        {
            List<string> dirs = new List<string>();
            dirs.AddRange(Directory.GetDirectories($"{pathBackground}/Get/Skills"));
            for(int i = 0; i < dirs.Count; i++)
            {
                string[] files = Directory.GetFiles(dirs[i], "*.JSON");
                skills.Add(new List<Skill>());
                foreach (string file in files)
                {
                    string[] jSonData = File.ReadAllLines(file);
                    JSONSmallSkillLoader jSONSmall = JsonUtility.FromJson<JSONSmallSkillLoader>(jSonData[0]);
                    skills[i].Add(new Skill(jSONSmall.name, jSONSmall.lvl, jSONSmall.internalName));
                }
            }
        }

        if(Directory.Exists(path + "/Get/Talents"))
        {
            
            List<string> files = new List<string>();
            files.AddRange(Directory.GetFiles($"{pathBackground}/Get/Talents", "*.txt"));
            foreach (string file in files)
            {
                talents.Add(new List<string>());
                talents[^1].AddRange(GameStat.ReadText(file).Split(new char[] { '/' }).ToList());
            }
        }

        if (Directory.Exists(path + "/Get/Equipments"))
        {
            List<string> dirs = new List<string>();
            dirs.AddRange(Directory.GetDirectories($"{pathBackground}/Get/Equipments"));
            for (int i = 0; i < dirs.Count; i++)
            {
                string[] files = Directory.GetFiles(dirs[i], "*.JSON");
                equipments.Add(new List<Equipment>());
                foreach (string file in files)
                {
                    string[] jSonData = File.ReadAllLines(file);

                    JSONTypeReader typeReader = JsonUtility.FromJson<JSONTypeReader>(jSonData[0]);
                    if (typeReader.typeEquipment == Equipment.TypeEquipment.Thing.ToString())
                    {
                        JSONEquipmentReader jSONSmall = JsonUtility.FromJson<JSONEquipmentReader>(jSonData[0]);
                        equipments[i].Add(new Equipment(jSONSmall.name, jSONSmall.description, jSONSmall.rarity, jSONSmall.amount, jSONSmall.weight));
                    }
                    else if (typeReader.typeEquipment == Equipment.TypeEquipment.Melee.ToString())
                    {
                        JSONMeleeReader meleeReader = JsonUtility.FromJson<JSONMeleeReader>(jSonData[0]);
                        equipments[i].Add(new Weapon(meleeReader));
                    }
                    else if(typeReader.typeEquipment == Equipment.TypeEquipment.Range.ToString())
                    {
                        JSONRangeReader rangeReader = JsonUtility.FromJson<JSONRangeReader>(jSonData[0]);
                        equipments[i].Add(new Weapon(rangeReader));
                    }
                    else if (typeReader.typeEquipment == Equipment.TypeEquipment.Grenade.ToString())
                    {
                        JSONGrenadeReader grenadeReader = JsonUtility.FromJson<JSONGrenadeReader>(jSonData[0]);
                        equipments[i].Add(new Weapon(grenadeReader));
                    }
                    else if (typeReader.typeEquipment == Equipment.TypeEquipment.Armor.ToString())
                    {
                        JSONArmorReader armorReader = JsonUtility.FromJson<JSONArmorReader>(jSonData[0]);
                        equipments[i].Add(new Armor(armorReader));
                    }
                    else if (typeReader.typeEquipment == Equipment.TypeEquipment.Special.ToString())
                    {
                        JSONSpecialReader specialReader = JsonUtility.FromJson<JSONSpecialReader>(jSonData[0]);
                        equipments[i].Add(new Special(specialReader));
                    }
                    
                }
            }
        }

        if(File.Exists(path + "/Get/Implants.txt"))
        {
            mechImplants = new List<MechImplant>();
            List<string> implants = new List<string>();
            implants.AddRange(GameStat.ReadText(path + "/Get/Implants.txt").Split(new char[] { '/' }).ToList());
            foreach(string implant in implants)
            {
                mechImplants.Add(new MechImplant(implant));
            }
        }

        
    }

    public void SetChosen(List<Skill> chosenSkills, List<string> chosenTalents, List<Equipment> chosenEquipments, GameStat.Inclinations chosenInclination, string rememberThing)
    {
        this.chosenSkills = new List<Skill>(chosenSkills);
        this.chosenTalents = new List<string>(chosenTalents);
        this.chosenEquipments = new List<Equipment>(chosenEquipments);
        this.chosenInclination = chosenInclination;
        this.rememberThing = rememberThing;
    }

    public string PathBackground { get => pathBackground; }
    public List<List<string>> Talents { get => talents; }
    public List<List<Skill>> Skills { get => skills; }
    public List<List<Equipment>> Equipments { get => equipments; }
    public List<GameStat.Inclinations> Inclinations { get => inclinations;  }
    public List<Skill> ChosenSkills { get => chosenSkills;}
    public List<string> ChosenTalents { get => chosenTalents;}
    public List<Equipment> ChosenEquipments { get => chosenEquipments;}
    public GameStat.Inclinations ChosenInclination { get => chosenInclination;}
    public List<MechImplant> MechImplants { get => mechImplants; }
    public string Name { get => name; }
    public string RememberThing { get => rememberThing; }
    public string Bonus { get => bonus; set => bonus = value; }
}
