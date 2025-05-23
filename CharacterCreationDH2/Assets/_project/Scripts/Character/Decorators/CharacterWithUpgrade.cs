﻿using System.Collections.Generic;
using UnityEngine;

namespace CharacterCreation
{
    public class CharacterWithUpgrade : CharacterDecorator, ICharacter
    {
        private List<Characteristic> _characteristics;
        private int _experienceSpent, _experienceUnspent, _experienceTotal, _psyrate;
        private int _wounds, _corruptionPoints;

        public CharacterWithUpgrade(ICharacter character) : base(character)
        {
            _experienceSpent = character.ExperienceSpent;
            _experienceUnspent = character.ExperienceUnspent;
            _experienceTotal = character.ExperienceTotal;
            _psyrate = character.PsyRating;
            _wounds = character.Wounds;
            _corruptionPoints = character.CorruptionPoints;

            _characteristics = new List<Characteristic>();
            foreach (Characteristic characteristic in _character.Characteristics)
            {
                _characteristics.Add(new Characteristic(characteristic));
            }
        }

        public int Age => _character.Age;

        public int InsanityPoints => _character.InsanityPoints;

        public int Wounds => _wounds;

        public int CorruptionPoints => _corruptionPoints;

        public int PsyRating => _psyrate;

        public int ExperienceTotal => _experienceTotal;

        public int ExperienceUnspent => _experienceUnspent;

        public int ExperienceSpent => _experienceSpent;

        public List<Characteristic> Characteristics => _characteristics;

        public List<string> MentalDisorders => _character.MentalDisorders;

        public string BonusBack => _character.BonusBack;

        public List<string> Mutations => _character.Mutations;

        public string Background => _character.Background;

        public string Role => _character.Role;

        public string AgeText => _character.AgeText;

        public string Constitution => _character.Constitution;

        public string Hair => _character.Hair;

        public string Eyes => _character.Eyes;

        public string Skeen => _character.Skeen;

        public string PhysFeatures => _character.PhysFeatures;

        public string MemoryOfHome => _character.MemoryOfHome;

        public string MemoryOfBackground => _character.MemoryOfBackground;

        public string Gender => _character.Gender;

        public string Homeworld => _character.Homeworld;

        public string Elite => _character.Elite;

        public string Tradition => _character.Tradition;

        public ICharacter GetCharacter => _character;

        public string BonusHomeworld => _character.BonusHomeworld;

        public string BonusRole => _character.BonusRole;

        public int FatePoint => _character.FatePoint;

        public string Name => _character.Name;

        public string Prophecy => _character.Prophecy;

        public void UpgradeSkill(Skill upgradeSkill, int experienceSpentForSkill)
        {
            if (upgradeSkill.IsKnowledge)
            {
                _skills.Add(new Knowledge((Knowledge)upgradeSkill, upgradeSkill.LvlLearned + 1));
            }
            else
                _skills.Add(new Skill(upgradeSkill, upgradeSkill.LvlLearned + 1));


            _experienceSpent += experienceSpentForSkill;
            _experienceUnspent -= experienceSpentForSkill;
            _experienceTotal = _experienceSpent + _experienceUnspent;
        }

        public void UpgradeTalent(Talent talent, int cost)
        {
            _talents.Add(new Talent(talent));
            _experienceSpent += cost;
            _experienceUnspent -= cost;
            _experienceTotal = _experienceSpent + _experienceUnspent;
            if (string.Compare(talent.Name, "Псайкер") == 0)
            {
                Debug.Log($"Gcfqrth");
                _inclinations.Add(GameStat.Inclinations.Psyker);
                if (string.Compare(_character.Background, "Адептус Астра Телепатика", true) == 0)
                {
                    _psyrate = 2;
                    _traits.Add(new Trait("Санкционированный", 0));
                }
                else
                {
                    _psyrate = 1;
                    System.Random random = new System.Random();
                    _corruptionPoints = random.Next(1, 11) + 3;
                }
            }
        }

        public void UpgradePsyPower(PsyPower psyPower, bool isEdit)
        {
            _psyPowers.Add(psyPower);
            if (isEdit == false)
            {
                _experienceSpent += psyPower.Cost;
                _experienceUnspent -= psyPower.Cost;
                _experienceTotal = _experienceSpent + _experienceUnspent;
            }
        }

        public void UpgradePsyrate(int cost)
        {
            _psyrate++;
            _experienceSpent += cost;
            _experienceUnspent -= cost;
            _experienceTotal = _experienceSpent + _experienceUnspent;
        }

        public void AddTrait(Trait trait)
        {
            _traits.Add(trait);
        }

        public void AddInclination(GameStat.Inclinations inclination)
        {
            if (_inclinations.Contains(inclination) == false)
                _inclinations.Add(inclination);
        }

        public void AddWound()
        {
            _wounds++;
        }

        public void AddEquipment(Equipment equipment)
        {
            _equipment.Add(equipment);
        }

        public void UpgradeWeapon(int costExp) => UpgradeCharacteristic(_characteristics[0], costExp);
        public void UpgradeBallistic(int costExp) => UpgradeCharacteristic(_characteristics[1], costExp);
        public void UpgradeStrength(int costExp) => UpgradeCharacteristic(_characteristics[2], costExp);
        public void UpgradeToughness(int costExp) => UpgradeCharacteristic(_characteristics[3], costExp);
        public void UpgradeAgility(int costExp) => UpgradeCharacteristic(_characteristics[4], costExp);
        public void UpgradeIntelligence(int costExp) => UpgradeCharacteristic(_characteristics[5], costExp);
        public void UpgradePerception(int costExp) => UpgradeCharacteristic(_characteristics[6], costExp);
        public void UpgradeWillpower(int costExp) => UpgradeCharacteristic(_characteristics[7], costExp);
        public void UpgradeFellowship(int costExp) => UpgradeCharacteristic(_characteristics[8], costExp);
        public void UpgradeInfluence(int costExp) => UpgradeCharacteristic(_characteristics[9], costExp);

        public void SetExperience(int experience) => _experienceUnspent += experience;

        private void UpgradeCharacteristic(Characteristic characteristic, int costExp)
        {
            characteristic.UpgradeLvl();
            _experienceSpent += costExp;
            _experienceUnspent -= costExp;
            _experienceTotal = _experienceSpent + _experienceUnspent;
        }
    }
}

