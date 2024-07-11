using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Role : IHistoryCharacter
{
    private string _name;
    private List<List<GameStat.Inclinations>> inclinations = new List<List<GameStat.Inclinations>>();
    private List<Talent> _talents = new List<Talent>();
    private string _pathRole;
    private string _bonusTalent, _textBonusDescr, _textDescription, _textCitata;
    private CreatorTalents _creatorTalents;

    public Role(string path, CreatorTalents creatorTalents)
    {
        _creatorTalents = creatorTalents;
        _pathRole = path;
        string[] files = Directory.GetFiles(path + "/Get/Inclinations", "*.txt");
        foreach(string file in files)
        {
            string textIncl = GameStat.ReadText(file);
            var inc = textIncl.Split(new char[] { '/' }).ToList();
            inclinations.Add(new List<GameStat.Inclinations>());
            foreach (string inclination in inc)
            {
                inclinations[^1].Add((GameStat.Inclinations)Enum.Parse(typeof(GameStat.Inclinations), inclination));
            }
        }

        string tl = GameStat.ReadText(path + "/Get/talents.txt");
        List<string> talents = new List<string>();
        talents.AddRange(tl.Split(new char[] { '/' }).ToList());

        foreach(string talent in talents)
        {
            _talents.Add(_creatorTalents.GetTalent(talent));
        }

        _name = GameStat.ReadText(path + "/Название.txt");
        if(File.Exists(path + "/Get/psyker.txt"))
        {
            _bonusTalent = GameStat.ReadText(path + "/Get/psyker.txt");
        }
        else
        {
            _bonusTalent = "";
        }

        _textBonusDescr = GameStat.ReadText(path + "/Бонус.txt");
        _textDescription = GameStat.ReadText(path + "/Описание.txt");
        _textCitata = "\nСклонности: ";
        _textCitata += GameStat.ReadText(path + "/Склонности.txt");
    }
    public List<Talent> Talents { get => _talents; }
    public List<List<GameStat.Inclinations>> Inclinations { get => inclinations; }
    public string Name { get => _name; }
    public string BonusTalent { get => _bonusTalent; }

    public string Description => _textDescription;

    public string Citata => _textCitata;

    public string BonusText => _textBonusDescr;

    public string Path => _pathRole;
}
