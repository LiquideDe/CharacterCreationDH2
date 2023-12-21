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
    private List<MechImplants> mechImplants;
    private string pathBackground;
    private List<Skill> chosenSkills = new List<Skill>();
    private List<string> chosenTalents = new List<string>();
    private List<Equipment> chosenEquipments = new List<Equipment>();
    private GameStat.Inclinations chosenInclination;
    private string rememberThing, bonus;

    public Background(string path, CreatorEquipment equipment)
    {
        pathBackground = path;
        name = ReadText(path + "/Название.txt");
        if (File.Exists(path + "/Get/Inclinations.txt"))
        {
            List<string> incs = ReadText(pathBackground + "/Get/Inclinations.txt").Split(new char[] { '/' }).ToList();
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
                talents[^1].AddRange(ReadText(file).Split(new char[] { '/' }).ToList());
            }
        }

        if (Directory.Exists(path + "/Get/Equipments"))
        {
            List<string> files = new List<string>();
            files.AddRange(Directory.GetFiles($"{pathBackground}/Get/Equipments", "*.txt"));
            foreach (string file in files)
            {
                List<string> eqs = new List<string>();
                eqs.AddRange(ReadText(file).Split(new char[] { '/' }).ToList());
                equipments.Add(new List<Equipment>());
                foreach (string eq in eqs)
                {
                    equipments[^1].Add(equipment.GetEquipment(eq));
                }                
            }
        }

        if(File.Exists(path + "/Get/Implants.txt"))
        {
            mechImplants = new List<MechImplants>();
            List<string> implants = new List<string>();
            implants.AddRange(ReadText(path + "/Get/Implants.txt").Split(new char[] { '/' }).ToList());
            foreach(string implant in implants)
            {
                mechImplants.Add(new MechImplants(implant));
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
    public string PathBackground { get => pathBackground; }
    public List<List<string>> Talents { get => talents; }
    public List<List<Skill>> Skills { get => skills; }
    public List<List<Equipment>> Equipment { get => equipments; }
    public List<GameStat.Inclinations> Inclinations { get => inclinations;  }
    public List<Skill> ChosenSkills { get => chosenSkills;}
    public List<string> ChosenTalents { get => chosenTalents;}
    public List<Equipment> ChosenEquipments { get => chosenEquipments;}
    public GameStat.Inclinations ChosenInclination { get => chosenInclination;}
    public List<MechImplants> MechImplants { get => mechImplants; }
    public string Name { get => name; }
    public string RememberThing { get => rememberThing; }
    public string Bonus { get => bonus; set => bonus = value; }
}
