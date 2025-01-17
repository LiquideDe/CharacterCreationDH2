using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using Directory = System.IO.Directory;
using File = System.IO.File;

public class Background : IHistoryCharacter
{
    private string _name;
    private List<List<Skill>> _skills = new List<List<Skill>>();
    private List<List<Talent>> _talents = new List<List<Talent>>();
    private List<List<Equipment>> _equipments = new List<List<Equipment>>();
    private List<GameStat.Inclinations> _inclinations = new List<GameStat.Inclinations>();
    private List<List<MechImplant>> _mechImplants = new List<List<MechImplant>>();
    private List<List<Trait>> _traits = new List<List<Trait>>();
    private string _pathBackground;
    private string  _bonus;
    private List<string> _rememberThings = new List<string>();
    private string _description, _citata;
    private CreatorSkills _creatorSkills;
    private CreatorTalents _creatorTalents;
    private CreatorTraits _creatorTraits;
    private CreatorImplant _creatorImplant;


    public Background(string path, CreatorSkills creatorSkills, CreatorTalents creatorTalents, CreatorTraits creatorTraits, CreatorImplant creatorImplant)
    {
        _creatorSkills = creatorSkills;
        _creatorImplant = creatorImplant;
        _creatorTraits = creatorTraits;
        _creatorTalents = creatorTalents;

        _pathBackground = path;
        _name = GameStat.ReadText(path + "/Название.txt");
        _description = GameStat.ReadText(path + "/Описание.txt");
        _citata = GameStat.ReadText(path + "/Цитата.txt");
        _bonus = GameStat.ReadText(path + "/Бонус.txt");
        _rememberThings = GameStat.ReadText(path + "/Remember.txt").Split(new char[] { '/' }).ToList();

        DirectoryInfo directoryInfo = new DirectoryInfo(path);

        if(Directory.Exists(path + "/Get"))
        {
            DirectoryInfo[] tempdirs = new DirectoryInfo(path + "/Get").GetDirectories();
            foreach (DirectoryInfo dir in tempdirs)
            {
                if(dir.Name == "Skills")                
                    GetSkills(dir.FullName);
                
                else if(dir.Name == "Traits")
                    GetTraits(dir.FullName);

                else if(dir.Name == "Talents")
                    GetTalents(dir.FullName);

                else if(dir.Name == "Implants")
                    GetImplants(dir.FullName);

                else if(dir.Name == "Equipments")
                    GetEquipments(dir.FullName);
            }
        }

        if (File.Exists(path + "/Get/Inclinations.txt"))
        {
            List<string> incs = GameStat.ReadText(_pathBackground + "/Get/Inclinations.txt").Split(new char[] { '/' }).ToList();
            foreach(string incl in incs)
            {
                _inclinations.Add((GameStat.Inclinations)Enum.Parse(typeof(GameStat.Inclinations), incl));
            }
        }        
    }

    public List<List<Talent>> Talents => _talents; 
    public List<List<Skill>> Skills => _skills;
    public List<List<Equipment>> Equipments => _equipments;
    public List<GameStat.Inclinations> Inclinations => _inclinations;
    public List<List<MechImplant>> MechImplants => _mechImplants; 
    public string Name => _name; 
    public List<string> RememberThings => _rememberThings; 
    public string BonusText => _bonus;

    public string Description => _description;

    public string Citata => _citata;

    public string Path => _pathBackground;

    public List<List<Trait>> Traits => _traits;

    private void GetSkills(string path)
    {
        List<string> dirs = new List<string>();
        dirs.AddRange(Directory.GetDirectories(path));
        for (int i = 0; i < dirs.Count; i++)
        {
            string[] files = Directory.GetFiles(dirs[i], "*.JSON");
            _skills.Add(new List<Skill>());
            foreach (string file in files)
            {
                string[] jSonData = File.ReadAllLines(file);
                JSONSmallSkillLoader jSONSmall = JsonUtility.FromJson<JSONSmallSkillLoader>(jSonData[0]);

                _skills[^1].Add(_creatorSkills.GetSkill(jSONSmall.name));
            }
        }
    }

    private void GetTraits(string path)
    {
        List<string> files = new List<string>();
        List<List<string>> traits = new List<List<string>>();
        files.AddRange(Directory.GetFiles(path, "*.txt"));
        foreach (string file in files)
        {
            traits.Add(new List<string>());
            traits[^1].AddRange(GameStat.ReadText(file).Split(new char[] { '/' }).ToList());
        }

        foreach (List<string> traitList in traits)
        {
            _traits.Add(new List<Trait>());
            for (int i = 0; i < traitList.Count; i++)
            {
                Trait trait = _creatorTraits.GetTrait(traitList[i]);
                if (trait == null)
                    trait = new Trait(traitList[i], 0);

                _traits[^1].Add(trait);
            }
        }
    }

    private void GetTalents(string path)
    {
        List<string> files = new List<string>();
        List<List<string>> talents = new List<List<string>>();
        files.AddRange(Directory.GetFiles(path, "*.txt"));
        foreach (string file in files)
        {
            talents.Add(new List<string>());
            talents[^1].AddRange(GameStat.ReadText(file).Split(new char[] { '/' }).ToList());
        }

        foreach (List<string> talentList in talents)
        {
            _talents.Add(new List<Talent>());
            for (int i = 0; i < talentList.Count; i++)
            {
                Talent talent = _creatorTalents.GetTalent(talentList[i]);
                if (talent == null)
                    talent = new Talent(talentList[i]);

                _talents[^1].Add(talent);
            }
        }
    }

    private void GetImplants(string path)
    {
        List<string> files = new List<string>();
        List<List<string>> implants = new List<List<string>>();
        files.AddRange(Directory.GetFiles(path, "*.txt"));
        foreach (string file in files)
        {
            implants.Add(new List<string>());
            implants[^1].AddRange(GameStat.ReadText(file).Split(new char[] { '/' }).ToList());
        }

        foreach (List<string> implantList in implants)
        {
            _mechImplants.Add(new List<MechImplant>());
            for (int i = 0; i < implantList.Count; i++)
            {
                MechImplant implant = _creatorImplant.GetImplant(implantList[i]);
                if (implant == null)
                    implant = new MechImplant(implantList[i]);

                _mechImplants[^1].Add(implant);
            }
        }
    }

    private void GetEquipments(string path)
    {
        List<string> dirs = new List<string>();
        dirs.AddRange(Directory.GetDirectories(path));
        for (int i = 0; i < dirs.Count; i++)
        {
            string[] files = Directory.GetFiles(dirs[i], "*.JSON");
            _equipments.Add(new List<Equipment>());
            foreach (string file in files)
            {
                string[] jSonData = File.ReadAllLines(file);

                JSONTypeReader typeReader = JsonUtility.FromJson<JSONTypeReader>(jSonData[0]);
                if (typeReader.typeEquipment == Equipment.TypeEquipment.Thing.ToString())
                {
                    JSONEquipmentReader jSONSmall = JsonUtility.FromJson<JSONEquipmentReader>(jSonData[0]);
                    _equipments[i].Add(new Equipment(jSONSmall.name, jSONSmall.description, jSONSmall.rarity, jSONSmall.amount, jSONSmall.weight));
                }
                else if (typeReader.typeEquipment == Equipment.TypeEquipment.Melee.ToString())
                {
                    JSONMeleeReader meleeReader = JsonUtility.FromJson<JSONMeleeReader>(jSonData[0]);
                    _equipments[i].Add(new Weapon(meleeReader));
                }
                else if (typeReader.typeEquipment == Equipment.TypeEquipment.Range.ToString())
                {
                    JSONRangeReader rangeReader = JsonUtility.FromJson<JSONRangeReader>(jSonData[0]);
                    _equipments[i].Add(new Weapon(rangeReader));
                }
                else if (typeReader.typeEquipment == Equipment.TypeEquipment.Grenade.ToString())
                {
                    JSONGrenadeReader grenadeReader = JsonUtility.FromJson<JSONGrenadeReader>(jSonData[0]);
                    _equipments[i].Add(new Weapon(grenadeReader));
                }
                else if (typeReader.typeEquipment == Equipment.TypeEquipment.Armor.ToString())
                {
                    JSONArmorReader armorReader = JsonUtility.FromJson<JSONArmorReader>(jSonData[0]);
                    _equipments[i].Add(new Armor(armorReader));
                }
                else if (typeReader.typeEquipment == Equipment.TypeEquipment.Special.ToString())
                {
                    JSONSpecialReader specialReader = JsonUtility.FromJson<JSONSpecialReader>(jSonData[0]);
                    _equipments[i].Add(new Special(specialReader));
                }

            }
        }
    }
}
