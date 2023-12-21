using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

public class Role
{
    private string name;
    private List<List<GameStat.Inclinations>> inclinations = new List<List<GameStat.Inclinations>>();
    private List<string> talents = new List<string>();
    private string pathRole;
    private List<GameStat.Inclinations> chosenInclinations = new List<GameStat.Inclinations>();
    private string chosenTalent, bonusTalent;

    public Role(string path)
    {        
        pathRole = path;
        string[] files = Directory.GetFiles(path + "/Get/Inclinations", "*.txt");
        foreach(string file in files)
        {
            string textIncl = ReadText(file);
            var inc = textIncl.Split(new char[] { '/' }).ToList();
            inclinations.Add(new List<GameStat.Inclinations>());
            foreach (string inclination in inc)
            {
                inclinations[^1].Add((GameStat.Inclinations)Enum.Parse(typeof(GameStat.Inclinations), inclination));
            }
        }

        string tl = ReadText(path + "/Get/talents.txt");
        talents.AddRange(tl.Split(new char[] { '/' }).ToList());
        name = ReadText(path + "/Название.txt");
        if(File.Exists(path + "/Get/psyker.txt"))
        {
            bonusTalent = ReadText(path + "/Get/psyker.txt");
        }
    }

    public void SetChosen(List<GameStat.Inclinations> chosenInclinations, string chosenTalent)
    {
        this.chosenInclinations = new List<GameStat.Inclinations>(chosenInclinations);
        this.chosenTalent = chosenTalent;
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

    public string PathRole { get => pathRole; }
    public List<string> Talents { get => talents; }
    public List<List<GameStat.Inclinations>> Inclinations { get => inclinations; }
    public string ChosenTalent { get => chosenTalent; }
    public List<GameStat.Inclinations> ChosenInclinations { get => chosenInclinations; }
    public string Name { get => name; }
    public string BonusTalent { get => bonusTalent; }
}
