using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace CharacterCreation
{
    public class Save
    {
        public Save(ICharacter character)
        {
            CharacterData characterData = new CharacterData();

            Directory.CreateDirectory($"{Application.dataPath}/StreamingAssets/CharacterSheets/{character.Name}");
            var path = Path.Combine($"{Application.dataPath}/StreamingAssets/CharacterSheets/{character.Name}", character.Name + ".jsonn");

            characterData.character = new NewSaveLoadCharacter();
            characterData.character.name = character.Name;
            characterData.character.age = character.Age;
            characterData.character.ageText = character.AgeText;
            characterData.character.background = character.Background;
            characterData.character.bonusBack = character.BonusBack;
            characterData.character.constitution = character.Constitution;
            characterData.character.corruptionPoints = character.CorruptionPoints;
            characterData.character.experienceSpent = character.ExperienceSpent;
            characterData.character.experienceTotal = character.ExperienceTotal;
            characterData.character.experienceUnspent = character.ExperienceUnspent;
            characterData.character.eyes = character.Eyes;
            characterData.character.fatePoint = character.FatePoint;
            characterData.character.gender = character.Gender;
            characterData.character.hair = character.Hair;
            characterData.character.homeworld = character.Homeworld;
            characterData.character.insanityPoints = character.InsanityPoints;
            characterData.character.memoryOfBackground = character.MemoryOfBackground;
            characterData.character.memoryOfHome = character.MemoryOfHome;
            characterData.character.physFeatures = character.PhysFeatures;
            characterData.character.prophecy = character.Prophecy;
            characterData.character.psyRating = character.PsyRating;
            characterData.character.role = character.Role;
            characterData.character.skeen = character.Skeen;
            characterData.character.wounds = character.Wounds;
            characterData.character.elite = character.Elite;
            characterData.character.tradition = character.Tradition;
            characterData.character.bonusHomeworld = character.BonusHomeworld;
            characterData.character.bonusRole = character.BonusRole;

            characterData.talents = character.Talents.Select(talent => new SaveLoadName { name = talent.Name }).ToList();
            characterData.mentalDisorders = character.MentalDisorders.Select(mental => new SaveLoadName {name = mental }).ToList();
            characterData.mutations = character.Mutations.Select(mutation => new SaveLoadName { name = mutation}).ToList();
            characterData.psyPowers = character.PsyPowers.Select(psyPower => new SaveLoadName { name = psyPower.Name }).ToList();
            characterData.inclinations = character.Inclinations.Select(inclination => new SaveLoadName { name = inclination.ToString()}).ToList();
            characterData.traits = character.Traits.Select(trait => new SaveLoadTrait { name = trait.Name, lvl = trait.Lvl }).ToList();
            characterData.skills = character.Skills.Where(skill => skill.LvlLearned > 0).
                Select(skill => new SaveLoadSkill { name = skill.Name, lvlLearned = skill.LvlLearned}).ToList();
            characterData.characteristics = character.Characteristics.
                Select(characteristic => new SaveLoadCharacteristic
                {
                    name = characteristic.Name,
                    amount = characteristic.Amount,
                    lvlLearnedChar = characteristic.LvlLearned
                }).ToList();

            characterData.implants = character.Implants.
                Select(implant => new SaveLoadImplant
                {
                    name = implant.Name,
                    partsOfBody = implant.Place.ToString(),
                    description = implant.Description,
                    armor = implant.Armor,
                    bonusToughness = implant.BonusToughness
                }).ToList();

            characterData.armors = new List<JSONArmorReader>();
            characterData.equipments = new List<JSONEquipmentReader>();
            characterData.grenades = new List<JSONGrenadeReader>();
            characterData.melees = new List<JSONMeleeReader>();
            characterData.ranges = new List<JSONRangeReader>();

            foreach (Equipment equipment in character.Equipments)
            {
                if (equipment is ISerializableEquipment serializable)
                {
                    var jsonObj = serializable.ToJsonReader();

                    switch (equipment.TypeEq)
                    {
                        case Equipment.TypeEquipment.Armor:
                        case Equipment.TypeEquipment.Shield:
                            characterData.armors.Add((JSONArmorReader)jsonObj);
                            break;

                        case Equipment.TypeEquipment.Grenade:
                            characterData.grenades.Add((JSONGrenadeReader)jsonObj);
                            break;

                        case Equipment.TypeEquipment.Melee:
                            characterData.melees.Add((JSONMeleeReader)jsonObj);
                            break;

                        case Equipment.TypeEquipment.Range:
                            characterData.ranges.Add((JSONRangeReader)jsonObj);
                            break;

                        case Equipment.TypeEquipment.Thing:
                            characterData.equipments.Add((JSONEquipmentReader)jsonObj);
                            break;
                    }
                }
            }
            var json = JsonUtility.ToJson(characterData, true);
            File.WriteAllText(path, json);
        }
    }
}

