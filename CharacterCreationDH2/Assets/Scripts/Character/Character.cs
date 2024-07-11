using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Character : ICharacter
{
    private string _name, _background, _role, _ageText, _prophecy, _constitution, _hair, _eyes, _skeen, _physFeatures, _memoryOfHome, 
        _memoryOfBackground, _gender, _bonusBack, _homeworld, _elite, _tradition, _bonusHomeworld, _bonusRole;
    private int _age, _fatePoint, _insanityPoints, _corruptionPoints, _wounds, _psyRating, _halfMove, _fullMove, _natisk, _run, _fatigue,
        _experienceTotal, _experienceUnspent, _experienceSpent;
    private float _carryWeight, _liftWeight, _pushWeight;
    private List<Characteristic> _characteristics = new List<Characteristic>();
    private List<GameStat.Inclinations> _inclinations = new List<GameStat.Inclinations>();
    private List<Talent> _talents = new List<Talent>();
    private List<Skill> _skills = new List<Skill>();
    private List<string> _mentalDisorders = new List<string>();
    private List<string> _mutation = new List<string>();
    private List<PsyPower> _psyPowers = new List<PsyPower>();
    private List<Equipment> _equipments = new List<Equipment>();
    private List<MechImplant> _implants = new List<MechImplant>();
    private List<Feature> _features = new List<Feature>();

    #region ��������

    public List<Equipment> Equipments => _equipments;
    public int Age => _age;
    public int FatePoint => _fatePoint;
    public int InsanityPoints => _insanityPoints;
    public int Wounds => _wounds;
    public int CorruptionPoints => _corruptionPoints;
    public int PsyRating => _psyRating; 
    public int HalfMove => _halfMove;
    public int FullMove => _fullMove;
    public int Natisk => _natisk;
    public int Fatigue => _fatigue;
    public float CarryWeight => _carryWeight;
    public float LiftWeight => _liftWeight;
    public float PushWeight => _pushWeight;
    public int ExperienceTotal => _experienceTotal;
    public int ExperienceUnspent => _experienceUnspent;
    public int ExperienceSpent => _experienceSpent;
    public List<Characteristic> Characteristics => _characteristics;
    public List<GameStat.Inclinations> Inclinations => _inclinations; 
    public List<Skill> Skills => _skills; 
    public List<Talent> Talents => _talents; 
    public List<MechImplant> Implants => _implants; 
    public List<string> MentalDisorders => _mentalDisorders;
    public int Run => _run; 
    public string BonusBack => _bonusBack;
    public List<string> Mutation => _mutation; 
    public List<PsyPower> PsyPowers => _psyPowers; 
    public List<Feature> Features => _features; 
    public string Name => _name;
    public string Background => _background;
    public string Role => _role;
    public string AgeText => _ageText;
    public string Prophecy => _prophecy;
    public string Constitution => _constitution;
    public string Hair => _hair;
    public string Eyes => _eyes;
    public string Skeen => _skeen;
    public string PhysFeatures => _physFeatures;
    public string MemoryOfHome => _memoryOfHome;
    public string MemoryOfBackground => _memoryOfBackground;
    public string Gender => _gender;
    public string Homeworld => _homeworld;
    public string Elite => _elite; 
    public string Tradition => _tradition; 
    public int BonusToughness => GetBonusToughness();
    public string BonusHomeworld => _bonusHomeworld;
    public ICharacter GetCharacter => this;

    public string BonusRole => _bonusRole;

    #endregion

    public Character(CreatorSkills skills)
    {
        _skills = new List<Skill>(skills.Skills);
        _inclinations.Add(GameStat.Inclinations.General);
        CreateCharacteristics();
    }

    public void AddInclination(GameStat.Inclinations inclination)
    {
        int vh = 0;
        foreach (GameStat.Inclinations incl in _inclinations)
        {
            if(incl == inclination)
            {
                vh++;
            }
        }
        if(vh == 0)
        {
            _inclinations.Add(inclination);
        }
    }

    public void LoadData(SaveLoadCharacter loadCharacter, List<SaveLoadCharacteristic> characteristics, List<SaveLoadSkill> skills, List<MechImplant> implants , List<Equipment> equipments)
    {
        _age = loadCharacter.age;
        _ageText = loadCharacter.ageText;
        _background = loadCharacter.background;
        _bonusBack = loadCharacter.bonusBack;
        _carryWeight = loadCharacter.carryWeight;
        _constitution = loadCharacter.constitution;
        _corruptionPoints = loadCharacter.corruptionPoints;
        _elite = loadCharacter.elite;
        _bonusHomeworld = loadCharacter.bonusHomeworld;
        _bonusRole = loadCharacter.bonusRole;

        List<string> listFeat = loadCharacter.features.Split(new char[] { '/' }).ToList();
        if (CheckString(listFeat))
        {
            List<string> featureLvl = loadCharacter.featuresLvl.Split(new char[] { '/' }).ToList();
            for(int i = 0; i < listFeat.Count; i++)
            {
                int.TryParse(featureLvl[i], out int lvl);
                _features.Add(new Feature(listFeat[i], lvl));
            }
        }

        _experienceSpent = loadCharacter.experienceSpent;
        _experienceTotal = loadCharacter.experienceTotal;
        _experienceUnspent = loadCharacter.experienceUnspent;
        _eyes = loadCharacter.eyes;
        _fatePoint = loadCharacter.fatePoint;
        _fatigue = loadCharacter.fatigue;
        _fullMove = loadCharacter.fullMove;
        _gender = loadCharacter.gender;
        _hair = loadCharacter.hair;
        _halfMove = loadCharacter.halfMove;
        _homeworld = loadCharacter.homeworld;

        _implants.AddRange(implants);

        List<string> incls = new List<string>();
        incls = loadCharacter.inclinations.Split(new char[] { '/' }).ToList();
        if (CheckString(incls))
        {
            foreach (string inclination in incls)
            {
                AddInclination((GameStat.Inclinations)Enum.Parse(typeof(GameStat.Inclinations), inclination));
            }
        }
        

        _insanityPoints = loadCharacter.insanityPoints;
        _liftWeight = loadCharacter.liftWeight;
        _memoryOfBackground = loadCharacter.memoryOfBackground;
        _memoryOfHome = loadCharacter.memoryOfHome;

        if(loadCharacter.mentalDisorders.Length > 0)
        {
            _mentalDisorders = loadCharacter.mentalDisorders.Split(new char[] { '/' }).ToList();
        }
        
        if(loadCharacter.mutation.Length > 0)
        {
            _mutation = loadCharacter.mutation.Split(new char[] { '/' }).ToList();
        }
        
        _name = loadCharacter.name;
        _natisk = loadCharacter.natisk;
        _physFeatures = loadCharacter.physFeatures;
        _prophecy = loadCharacter.prophecy;
        
        _pushWeight = loadCharacter.pushWeight;
        _role = loadCharacter.role;
        _run = loadCharacter.run;
        _skeen = loadCharacter.skeen;
        _wounds = loadCharacter.wounds;

        List<string> tl = new List<string>();
        tl = loadCharacter.talents.Split(new char[] { '/' }).ToList();
        if(CheckString(tl))
        foreach(string talent in tl)
        {
            _talents.Add(new Talent(talent));
        }

        List<string> psy = new List<string>();
        psy = loadCharacter.psyPowers.Split(new char[] { '/' }).ToList();
        if(CheckString(psy))
        foreach(string p in psy)
        {
            _psyPowers.Add(new PsyPower(p));
        }

        for(int i = 0; i < characteristics.Count; i++)
        {
            this._characteristics[i].Amount = characteristics[i].amount;
            this._characteristics[i].LvlLearned = characteristics[i].lvlLearnedChar;
        }

        foreach(Skill skill in this._skills)
        {
            foreach(SaveLoadSkill loadSkill in skills)
            {
                if(string.Compare(skill.Name, loadSkill.name) == 0)
                {
                    skill.LvlLearned = loadSkill.lvlLearned;
                    break;
                }
            }
        }

        _psyRating = loadCharacter.psyRating;
        _tradition = loadCharacter.tradition;
        _equipments.AddRange(equipments);
    }

    public void UpdateData(SaveLoadCharacter loadCharacter)
    {
        _name = loadCharacter.name;
        _homeworld = loadCharacter.homeworld;
        _background = loadCharacter.background;
        _role = loadCharacter.role;
        _prophecy = loadCharacter.prophecy;
        _elite = loadCharacter.elite;
        _gender = loadCharacter.gender;
        _age = loadCharacter.age;
        _skeen = loadCharacter.skeen;
        _constitution = loadCharacter.constitution;
        _hair = loadCharacter.hair;
        _physFeatures = loadCharacter.physFeatures;
        _eyes = loadCharacter.eyes;
        _tradition = loadCharacter.tradition;
        _memoryOfHome = loadCharacter.memoryOfHome;
        _memoryOfBackground = loadCharacter.memoryOfBackground;        
    }

    public void ChangeCorruption(int amount) => _corruptionPoints += amount;

    public void ChangeFatepoints(int amount) => _fatePoint += amount;

    public void ChangeFullmove(int amount) => _fullMove += amount;

    public void ChangeHalfmove(int amount) => _halfMove += amount;

    public void ChangeMadness(int amount) => _insanityPoints += amount;

    public void ChangeNatisk(int amount) => _natisk += amount;

    public void ChangeRun(int amount) => _run += amount;

    public void ChangeWounds(int amount) => _wounds += amount;

    private bool CheckString(List<string> list)
    {
        if(list.Count > 0)
        {
            if(list[0].Length > 0)
            {
                return true;
            }
        }

        return false;
    }

    private int GetBonusToughness()
    {
        int bToughness = _characteristics[3].Amount / 10;
        foreach(Feature feature in _features)
        {
            if (string.Compare(feature.Name, "������������������ ������������") == 0 || string.Compare(feature.Name, "������������") == 0)
            {
                bToughness += feature.Lvl;
            }
        }

        return bToughness;
    }

    private void CreateCharacteristics()
    {
        _characteristics.Add(new Characteristic(GameStat.CharacteristicName.WeaponSkill, GameStat.Inclinations.Weapon, GameStat.Inclinations.Offense)); //0
        _characteristics.Add(new Characteristic(GameStat.CharacteristicName.BallisticSkill, GameStat.Inclinations.Ballistic, GameStat.Inclinations.Finesse)); //1
        _characteristics.Add(new Characteristic(GameStat.CharacteristicName.Strength, GameStat.Inclinations.Strength, GameStat.Inclinations.Offense)); //2
        _characteristics.Add(new Characteristic(GameStat.CharacteristicName.Toughness, GameStat.Inclinations.Toughness, GameStat.Inclinations.Defense)); //3
        _characteristics.Add(new Characteristic(GameStat.CharacteristicName.Agility, GameStat.Inclinations.Agility, GameStat.Inclinations.Finesse)); //4
        _characteristics.Add(new Characteristic(GameStat.CharacteristicName.Intelligence, GameStat.Inclinations.Intelligence, GameStat.Inclinations.Knowledge)); //5
        _characteristics.Add(new Characteristic(GameStat.CharacteristicName.Perception, GameStat.Inclinations.Perception, GameStat.Inclinations.Fieldcraft)); //6
        _characteristics.Add(new Characteristic(GameStat.CharacteristicName.Willpower, GameStat.Inclinations.Willpower, GameStat.Inclinations.Psyker)); //7
        _characteristics.Add(new Characteristic(GameStat.CharacteristicName.Fellowship, GameStat.Inclinations.Fellowship, GameStat.Inclinations.Social)); //8
        _characteristics.Add(new Characteristic(GameStat.CharacteristicName.Influence, GameStat.Inclinations.None, GameStat.Inclinations.None)); //9
    }
}