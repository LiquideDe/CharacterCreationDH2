using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static CharacterCreation.GameStat;

namespace CharacterCreation
{
    public class Character : ICharacter
    {
        private string _name, _background, _role, _ageText, _prophecy, _constitution, _hair, _eyes, _skeen, _physFeatures, _memoryOfHome,
            _memoryOfBackground, _gender, _bonusBack, _homeworld, _elite, _tradition, _bonusHomeworld, _bonusRole;
        private int _age, _fatePoint, _insanityPoints, _corruptionPoints, _wounds, _psyRating,
            _experienceTotal, _experienceUnspent, _experienceSpent;
        private List<Characteristic> _characteristics = new List<Characteristic>();
        private List<Inclinations> _inclinations = new List<Inclinations>();
        private List<Talent> _talents = new List<Talent>();
        private List<Skill> _skills = new List<Skill>();
        private List<string> _mentalDisorders = new List<string>();
        private List<string> _mutations = new List<string>();
        private List<PsyPower> _psyPowers = new List<PsyPower>();
        private List<Equipment> _equipments = new List<Equipment>();
        private List<MechImplant> _implants = new List<MechImplant>();
        private List<Trait> _traits = new List<Trait>();

        public Character(CreatorSkills skills)
        {
            //_skills = new List<Skill>(skills.Skills);
            _skills = new List<Skill>();
            foreach (Skill skill in skills.Skills)
            {
                if (skill is Knowledge knowledge)
                    _skills.Add(new Knowledge(knowledge, 0));

                else
                    _skills.Add(new Skill(skill, 0));
            }

            _inclinations.Add(GameStat.Inclinations.General);
            CreateCharacteristics();
        }

        #region Свойства

        public List<Equipment> Equipments => _equipments;
        public int Age => _age;
        public int FatePoint => _fatePoint;
        public int InsanityPoints => _insanityPoints;
        public int Wounds => _wounds;
        public int CorruptionPoints => _corruptionPoints;
        public int PsyRating => _psyRating;
        public int ExperienceTotal => _experienceTotal;
        public int ExperienceUnspent => _experienceUnspent;
        public int ExperienceSpent => _experienceSpent;
        public List<Characteristic> Characteristics => _characteristics;
        public List<Inclinations> Inclinations => _inclinations;
        public List<Skill> Skills => _skills;
        public List<Talent> Talents => _talents;
        public List<MechImplant> Implants => _implants;
        public List<string> MentalDisorders => _mentalDisorders;
        public string BonusBack => _bonusBack;
        public List<string> Mutations => _mutations;
        public List<PsyPower> PsyPowers => _psyPowers;
        public List<Trait> Traits => _traits;
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
        public string BonusHomeworld => _bonusHomeworld;
        public ICharacter GetCharacter => this;

        public string BonusRole => _bonusRole;

        #endregion

        public void AddInclination(GameStat.Inclinations inclination)
        {
            int vh = 0;
            foreach (GameStat.Inclinations incl in _inclinations)
            {
                if (incl == inclination)
                {
                    vh++;
                }
            }
            if (vh == 0)
            {
                _inclinations.Add(inclination);
            }
        }

        public void LoadData(SaveLoadCharacter loadCharacter, List<SaveLoadCharacteristic> characteristics, List<SaveLoadSkill> skills, List<MechImplant> implants, List<Equipment> equipments)
        {
            _age = loadCharacter.age;
            _ageText = loadCharacter.ageText;
            _background = loadCharacter.background;
            _bonusBack = loadCharacter.bonusBack;
            _constitution = loadCharacter.constitution;
            _corruptionPoints = loadCharacter.corruptionPoints;
            _elite = loadCharacter.elite;
            _bonusHomeworld = loadCharacter.bonusHomeworld;
            _bonusRole = loadCharacter.bonusRole;

            List<string> listTrait = loadCharacter.traits.Split(new char[] { '/' }).ToList();
            if (CheckString(listTrait))
            {
                List<string> traitLvl = loadCharacter.traitsLvl.Split(new char[] { '/' }).ToList();
                for (int i = 0; i < listTrait.Count; i++)
                {
                    int.TryParse(traitLvl[i], out int lvl);
                    _traits.Add(new Trait(listTrait[i], lvl));
                }
            }



            _experienceSpent = loadCharacter.experienceSpent;
            _experienceTotal = loadCharacter.experienceTotal;
            _experienceUnspent = loadCharacter.experienceUnspent;
            _eyes = loadCharacter.eyes;
            _fatePoint = loadCharacter.fatePoint;
            _gender = loadCharacter.gender;
            _hair = loadCharacter.hair;
            _homeworld = loadCharacter.homeworld;

            _implants.AddRange(implants);

            List<string> incls = new List<string>();
            incls = loadCharacter.inclinations.Split(new char[] { '/' }).ToList();
            if (CheckString(incls))
            {
                foreach (string inclination in incls)
                {
                    AddInclination((Inclinations)Enum.Parse(typeof(Inclinations), inclination));
                }
            }


            _insanityPoints = loadCharacter.insanityPoints;
            _memoryOfBackground = loadCharacter.memoryOfBackground;
            _memoryOfHome = loadCharacter.memoryOfHome;

            if (loadCharacter.mentalDisorders.Length > 0)
            {
                _mentalDisorders = loadCharacter.mentalDisorders.Split(new char[] { '/' }).ToList();
            }

            if (loadCharacter.mutation.Length > 0)
            {
                _mutations = loadCharacter.mutation.Split(new char[] { '/' }).ToList();
            }

            _name = loadCharacter.name;
            _physFeatures = loadCharacter.physFeatures;
            _prophecy = loadCharacter.prophecy;
            _role = loadCharacter.role;
            _skeen = loadCharacter.skeen;
            _wounds = loadCharacter.wounds;

            List<string> tl = new List<string>();
            tl = loadCharacter.talents.Split(new char[] { '/' }).ToList();
            if (CheckString(tl))
                foreach (string talent in tl)
                {
                    _talents.Add(new Talent(talent));
                }

            List<string> psy = new List<string>();
            psy = loadCharacter.psyPowers.Split(new char[] { '/' }).ToList();
            if (CheckString(psy))
                foreach (string p in psy)
                {
                    _psyPowers.Add(new PsyPower(p));
                }

            for (int i = 0; i < characteristics.Count; i++)
            {
                this._characteristics[i].Amount = characteristics[i].amount;
                this._characteristics[i].LvlLearned = characteristics[i].lvlLearnedChar;
            }

            foreach (Skill skill in _skills)
            {
                foreach (SaveLoadSkill loadSkill in skills)
                {
                    if (string.Compare(skill.Name, loadSkill.name) == 0)
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

        public void LoadData(CharacterData characterData)
        {
            _age = characterData.character.age;
            _ageText = characterData.character.ageText;
            _background = characterData.character.background;
            _bonusBack = characterData.character.bonusBack;
            _constitution = characterData.character.constitution;
            _corruptionPoints = characterData.character.corruptionPoints;
            _elite = characterData.character.elite;
            _bonusHomeworld = characterData.character.bonusHomeworld;
            _bonusRole = characterData.character.bonusRole;
            _experienceSpent = characterData.character.experienceSpent;
            _experienceTotal = characterData.character.experienceTotal;
            _experienceUnspent = characterData.character.experienceUnspent;
            _eyes = characterData.character.eyes;
            _fatePoint = characterData.character.fatePoint;
            _gender = characterData.character.gender;
            _hair = characterData.character.hair;
            _homeworld = characterData.character.homeworld;
            _insanityPoints = characterData.character.insanityPoints;
            _memoryOfBackground = characterData.character.memoryOfBackground;
            _memoryOfHome = characterData.character.memoryOfHome;
            _name = characterData.character.name;
            _physFeatures = characterData.character.physFeatures;
            _prophecy = characterData.character.prophecy;
            _role = characterData.character.role;
            _skeen = characterData.character.skeen;
            _wounds = characterData.character.wounds;
            _psyRating = characterData.character.psyRating;
            _tradition = characterData.character.tradition;

            _talents = characterData.talents.Select(t => new Talent(t.name)).ToList();
            _mentalDisorders = characterData.mentalDisorders.Select(x => x.name).ToList();
            _mutations = characterData.mutations.Select(x => x.name).ToList();
            _psyPowers = characterData.psyPowers.Select(p => new PsyPower(p.name)).ToList();
            _inclinations = characterData.inclinations.
                Select(i =>
                {
                    if (Enum.TryParse<Inclinations>(i.name, out var result))
                        return result;
                    else
                        throw new Exception($"Invalid inclination enum value: {i.name}");
                }).ToList();

            _traits = characterData.traits.Select(t => new Trait(t.name, t.lvl)).ToList();
            foreach (Skill skill in _skills)
            {
                foreach (SaveLoadSkill loadSkill in characterData.skills)
                {
                    if (string.Compare(skill.Name, loadSkill.name) == 0)
                    {
                        skill.LvlLearned = loadSkill.lvlLearned;
                        break;
                    }
                }
            }
            for (int i = 0; i < characterData.characteristics.Count; i++)
            {
                Debug.Log($"{characterData.characteristics[i].name} = {characterData.characteristics[i].lvlLearnedChar}");
                _characteristics[i].Amount = characterData.characteristics[i].amount;
                _characteristics[i].LvlLearned = characterData.characteristics[i].lvlLearnedChar;
            }
            _implants = characterData.implants.Select(i => new MechImplant(i)).ToList();
            List<Armor> armors = characterData.armors.Select(a => new Armor(a)).ToList();
            List<Weapon> ranges = characterData.ranges.Select(r => new Weapon(r)).ToList();
            List<Weapon> melees = characterData.melees.Select(m => new Weapon(m)).ToList();
            List<Weapon> grenades = characterData.grenades.Select(g => new Weapon(g)).ToList();
            List<Equipment> equipments = characterData.equipments.Select(e => new Equipment(e)).ToList();

            _equipments.AddRange(armors);
            _equipments.AddRange(ranges);
            _equipments.AddRange(melees);
            _equipments.AddRange(grenades);
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

        public void ChangeMadness(int amount) => _insanityPoints += amount;

        public void ChangeWounds(int amount) => _wounds += amount;

        private bool CheckString(List<string> list)
        {
            if (list.Count > 0)
            {
                if (list[0].Length > 0)
                {
                    return true;
                }
            }

            return false;
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

}
