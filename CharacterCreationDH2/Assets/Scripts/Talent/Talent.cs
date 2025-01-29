using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using static GameStat;

public class Talent : ISkillTalentEtcForList, INameWithDescription
{
    private string _name;
    private string _textDescription, _shortDescription, _listOfRequrements;
    private GameStat.Inclinations[] _inclinations = new GameStat.Inclinations[2];
    private List<Characteristic> _requirementCharacteristics = new List<Characteristic>();
    private List<Skill> _requirementSkills = new List<Skill>();
    private List<MechImplant> _requirementImplants = new List<MechImplant>();
    private List<Talent> _requirementTalents = new List<Talent>();
    private List<Trait> _requirementTraits = new List<Trait>();
    private int _requirementPsyRate;
    private int _requirementInsanity = 0, _requirementCorruption = 0;
    private bool _isRepeatable, _isCanTaken;
    private int _rank;
    private string _requirementBackground = "";
    private List<List<Talent>> _getTalents = new List<List<Talent>>();
    private List<List<GameStat.Inclinations>> _getInclinations = new List<List<GameStat.Inclinations>>();
    private List<List<Skill>> _getSkills = new List<List<Skill>>();
    private List<List<Trait>> _getTraits = new List<List<Trait>>();
    private List<Talent> _conflictTalent = new List<Talent>();
    private int _getWounds;
    private List<List<Equipment>> _getEquipments = new List<List<Equipment>>();
    private CreatorSkills _creatorSkills;
    private CreatorTalents _creatorTalents;
    private CreatorTraits _creatorTraits;

    public string Name => _name;
    public string LongDescription => _textDescription;
    public string ListRequirments => _listOfRequrements;
    public GameStat.Inclinations[] Inclinations => _inclinations; 
    public string Description => _shortDescription; 
    public bool IsCanTaken => _isCanTaken;
    public bool IsRepeatable => _isRepeatable;

    public List<Characteristic> RequirementCharacteristics => _requirementCharacteristics;

    public List<Skill> RequirementSkills => _requirementSkills;

    public List<MechImplant> RequirementImplants => _requirementImplants;

    public List<Talent> RequirementTalents => _requirementTalents;

    public int RequirementPsyRate => _requirementPsyRate; 
    public int RequirementInsanity => _requirementInsanity;
    public int RequirementCorruption => _requirementCorruption;

    public int Rank => _rank;

    public List<Trait> RequirementTraits => _requirementTraits;

    public string RequirementBackground => _requirementBackground;

    public List<List<Talent>> GetTalents => _getTalents;
    public List<List<GameStat.Inclinations>> GetInclinations => _getInclinations; 
    public List<List<Skill>> GetSkills => _getSkills;
    public List<List<Trait>> GetTraits => _getTraits;
    public int GetWounds => _getWounds;
    public List<List<Equipment>> GetEquipments => _getEquipments;

    public List<Talent> ConflictTalent => _conflictTalent; 

    public Talent(string path, CreatorSkills creatorSkills, CreatorTalents creatorTalents, CreatorTraits creatorTraits)
    {
        _creatorSkills = creatorSkills;
        _creatorTalents = creatorTalents;
        _creatorTraits = creatorTraits;
        string[] data = File.ReadAllLines(path + "/Param.JSON");
        JSONTalentReader talentReader = JsonUtility.FromJson<JSONTalentReader>(data[0]);
        _name = talentReader.name;
        _inclinations[0] = (GameStat.Inclinations)Enum.Parse(typeof(GameStat.Inclinations), talentReader.inclinationFirst);
        _inclinations[1] = (GameStat.Inclinations)Enum.Parse(typeof(GameStat.Inclinations), talentReader.inclinationSecond);
        _rank = talentReader.rank;
        _isCanTaken = talentReader.canActivate;
        _isRepeatable = talentReader.repeatable;
        _textDescription = GameStat.ReadText(path + "/Описание.txt");
        _shortDescription = GameStat.ReadText(path + "/Краткое описание.txt");
        if(Directory.Exists(path + "/Req"))
        {
            _listOfRequrements = "Требования для Таланта.\n";
            string reqPath = path+"/Req";
            if (Directory.Exists(reqPath + "/Characteristics"))            
                AddRequirementCharacteristic(reqPath + "/Characteristics");            

            _listOfRequrements = CheckLastSymbol(_listOfRequrements);

            if(Directory.Exists(reqPath + "/Skills"))            
                AddRequirementSkills(reqPath + "/Skills");            

            _listOfRequrements = CheckLastSymbol(_listOfRequrements);
            if (File.Exists(reqPath + "/ReqImplants.txt"))            
                AddRequirementImplants(reqPath + "/ReqImplants.txt");            

            _listOfRequrements = CheckLastSymbol(_listOfRequrements);

            if (File.Exists(reqPath + "/ReqTalents.txt"))            
                AddRequirementTalent(reqPath + "/ReqTalents.txt");
            
            _listOfRequrements = CheckLastSymbol(_listOfRequrements);

            if (File.Exists(reqPath + "/ReqCorruption.txt"))
            {
                _requirementCorruption = int.Parse(GameStat.ReadText(reqPath + "/ReqCorruption.txt"));
                _listOfRequrements += $" Очков Порчи {_requirementCorruption}.";
            }

            if (File.Exists(reqPath + "/ReqInsanity.txt"))
            {
                _requirementInsanity = int.Parse(GameStat.ReadText(reqPath + "/ReqInsanity.txt"));
                _listOfRequrements += $" Очков Безумия {_requirementInsanity}.";
            }

            if(File.Exists(reqPath + "/ReqPsy.txt"))
            {
                _requirementPsyRate = int.Parse(GameStat.ReadText(reqPath + "/ReqPsy.txt"));
                _listOfRequrements += $" Пси Рейтинг {_requirementPsyRate}.";
            }
            else            
                _requirementPsyRate = 0;
            

            if(File.Exists(reqPath + "/ReqTraits.txt"))            
                AddRequirementTraits(reqPath + "/ReqTraits.txt");

            if(File.Exists(reqPath + "/ReqBackground.txt"))
            {
                _requirementBackground = GameStat.ReadText(reqPath + "/ReqBackground.txt");
                _listOfRequrements += $" Предыстория {_requirementBackground}.";
            }

            if (File.Exists(reqPath + "/ReqConflict.txt"))
            {
                string textConflict = ReadText(reqPath + "/ReqConflict.txt");
                var conflicts = textConflict.Split(new char[] { '/' }).ToList();
                _listOfRequrements += " Нет следующих талантов:";
                foreach (string conflict in conflicts)
                {
                    _conflictTalent.Add(new Talent(conflict));
                    _listOfRequrements += $" {_conflictTalent[^1].Name},";
                }
            }
        }

        if (Directory.Exists(path + "/Get"))
        {
            string getPath = path + "/Get";

            if (Directory.Exists(getPath + "/GetInclinations"))
                AddGetInclination(getPath + "/GetInclinations");

            if (Directory.Exists(getPath + "/GetEquipments"))            
                AddGetEquipments(getPath + "/GetEquipments");

            if (Directory.Exists(getPath + "/GetSkills"))
                AddGetSkills(getPath + "/GetSkills");

            if (Directory.Exists(getPath + "/GetTalents"))
                AddGetTalents(getPath + "/GetTalents");

            if (Directory.Exists(getPath + "/GetTraits"))
                AddGetTraits(getPath + "/GetTraits");

        }
    }

    private void AddRequirementCharacteristic(string path)
    {
        _listOfRequrements += "Характеристики:";
        foreach (GameStat.CharacteristicName charName in Enum.GetValues(typeof(GameStat.CharacteristicName)))
        {
            string searchFile = $"{path}/{charName}.txt";
            if (File.Exists(searchFile))
            {
                _requirementCharacteristics.Add(new Characteristic(charName, int.Parse(GameStat.ReadText(searchFile))));
                _listOfRequrements += $" {_requirementCharacteristics[^1].Name} - {_requirementCharacteristics[^1].Amount},";
            }
        }
    }

    private void AddRequirementSkills(string path)
    {
        _listOfRequrements += "Навыки:";
        string[] files = Directory.GetFiles(path, "*.JSON");
        foreach (string file in files)
        {
            string[] jSonData = File.ReadAllLines(file);
            JSONSmallSkillLoader jSONSmall = JsonUtility.FromJson<JSONSmallSkillLoader>(jSonData[0]);
            _requirementSkills.Add(new Skill(jSONSmall.name, jSONSmall.lvl));
            _listOfRequrements += $" {_requirementSkills[^1].Name} - {_requirementSkills[^1].LvlLearned},";
        }
    }

    private void AddRequirementImplants(string path)
    {
        string textImplants = GameStat.ReadText(path);
        var implants = textImplants.Split(new char[] { '/' }).ToList();
        _listOfRequrements += " Импланты:";
        foreach (string implant in implants)
        {
            _requirementImplants.Add(new MechImplant(implant));
            _listOfRequrements += $" {_requirementImplants[^1].Name},";
        }
    }

    private void AddRequirementTalent(string path)
    {
        string textTalents = GameStat.ReadText(path);
        var talents = textTalents.Split(new char[] { '/' }).ToList();
        _listOfRequrements += "Таланты:";
        foreach (string talent in talents)
        {
            _requirementTalents.Add(new Talent(talent));
            _listOfRequrements += $" {_requirementTalents[^1].Name},";
        }
    }

    private void AddRequirementTraits(string path)
    {
        string textTrait = ReadText(path);
        var traits = textTrait.Split(new char[] { '/' }).ToList();
        _listOfRequrements += "Черты:";
        foreach (string trait in traits)
        {
            _requirementTraits.Add(new Trait(trait, 0));
            _listOfRequrements += $" {trait},";
        }
    }

    private void AddGetInclination(string path)
    {      
        List<string> dirs = new List<string>();
        dirs.AddRange(Directory.GetDirectories(path));
        for (int i = 0; i < dirs.Count; i++)
        {
            string[] files = Directory.GetFiles(dirs[i], "*.txt");
            _getInclinations.Add(new List<Inclinations>());
            foreach (string file in files)
            {
                string textIncl = ReadText(file);
                _getInclinations[^1].Add((Inclinations)Enum.Parse(typeof(Inclinations), textIncl));
            }
        }
    }

    private void AddGetEquipments(string path)
    {
        List<string> dirs = new List<string>();
        dirs.AddRange(Directory.GetDirectories(path));
        for (int i = 0; i < dirs.Count; i++)
        {
            string[] files = Directory.GetFiles(dirs[i], "*.JSON");
            _getEquipments.Add(new List<Equipment>());
            foreach (string file in files)
            {
                string[] jSonData = File.ReadAllLines(file);

                JSONTypeReader typeReader = JsonUtility.FromJson<JSONTypeReader>(jSonData[0]);
                if (typeReader.typeEquipment == Equipment.TypeEquipment.Thing.ToString())
                {
                    JSONEquipmentReader jSONSmall = JsonUtility.FromJson<JSONEquipmentReader>(jSonData[0]);
                    _getEquipments[i].Add(new Equipment(jSONSmall.name, jSONSmall.description, jSONSmall.rarity, jSONSmall.amount, jSONSmall.weight));
                }
                else if (typeReader.typeEquipment == Equipment.TypeEquipment.Melee.ToString())
                {
                    JSONMeleeReader meleeReader = JsonUtility.FromJson<JSONMeleeReader>(jSonData[0]);
                    _getEquipments[i].Add(new Weapon(meleeReader));
                }
                else if (typeReader.typeEquipment == Equipment.TypeEquipment.Range.ToString())
                {
                    JSONRangeReader rangeReader = JsonUtility.FromJson<JSONRangeReader>(jSonData[0]);
                    _getEquipments[i].Add(new Weapon(rangeReader));
                }
                else if (typeReader.typeEquipment == Equipment.TypeEquipment.Grenade.ToString())
                {
                    JSONGrenadeReader grenadeReader = JsonUtility.FromJson<JSONGrenadeReader>(jSonData[0]);
                    _getEquipments[i].Add(new Weapon(grenadeReader));
                }
                else if (typeReader.typeEquipment == Equipment.TypeEquipment.Armor.ToString())
                {
                    JSONArmorReader armorReader = JsonUtility.FromJson<JSONArmorReader>(jSonData[0]);
                    _getEquipments[i].Add(new Armor(armorReader));
                }
                else if (typeReader.typeEquipment == Equipment.TypeEquipment.Special.ToString())
                {
                    JSONSpecialReader specialReader = JsonUtility.FromJson<JSONSpecialReader>(jSonData[0]);
                    _getEquipments[i].Add(new Special(specialReader));
                }

            }
        }
    }

    private void AddGetSkills(string path)
    {
        List<string> dirs = new List<string>();
        dirs.AddRange(Directory.GetDirectories(path));
        for (int i = 0; i < dirs.Count; i++)
        {
            string[] files = Directory.GetFiles(dirs[i], "*.JSON");
            _getSkills.Add(new List<Skill>());
            foreach (string file in files)
            {
                string[] jSonData = File.ReadAllLines(file);
                JSONSmallSkillLoader jSONSmall = JsonUtility.FromJson<JSONSmallSkillLoader>(jSonData[0]);

                _getSkills[^1].Add(_creatorSkills.GetSkill(jSONSmall.name));
            }
        }
    }

    private void AddGetTalents(string path)
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
            _getTalents.Add(new List<Talent>());
            for (int i = 0; i < talentList.Count; i++)
            {
                Talent talent = _creatorTalents.GetTalent(talentList[i]);
                if (talent == null)
                    talent = new Talent(talentList[i]);

                _getTalents[^1].Add(talent);
            }
        }
    }

    private void AddGetTraits(string path)
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
            _getTraits.Add(new List<Trait>());
            for (int i = 0; i < traitList.Count; i++)
            {
                Trait trait = _creatorTraits.GetTrait(traitList[i]);
                if (trait == null)
                    trait = new Trait(traitList[i], 0);

                _getTraits[^1].Add(trait);
            }
        }
    }

    private string CheckLastSymbol(string text)
    {
        if (text.EndsWith(","))
        {
            string tempstring = text.TrimEnd(',');
            return tempstring + ". ";
        }
        else
        {
            return text;
        }
    }
    public Talent(string name)
    {
        this._name = name;
    }

    public Talent(Talent talent)
    {
        _textDescription = talent.LongDescription;
        _shortDescription = talent.Description;
        _name = talent.Name;
        _inclinations[0] = talent.Inclinations[0];
        _inclinations[1] = talent.Inclinations[1];
        _isCanTaken = talent.IsCanTaken;
        _isRepeatable = talent.IsRepeatable;
        
    }

    public bool CheckTalentRepeat(List<Talent> talentsOfCharacter)
    {
        if (!_isRepeatable)
        {
            foreach (Talent talent in talentsOfCharacter)
            {
                if (string.Compare(talent.Name, _name, true) == 0)
                {
                    return false;
                }
            }
        }
        
        return true;
    }
    


    
}
