using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Save
{
    public Save(Character character)
    {        
        Directory.CreateDirectory($"{Application.dataPath}/StreamingAssets/CharacterSheets/{character.Name}");
        var path = Path.Combine($"{Application.dataPath}/StreamingAssets/CharacterSheets/{character.Name}", character.Name + ".JSON");
        List<string> data = new List<string>();

        SaveLoadCharacter saveLoad = new SaveLoadCharacter();

        saveLoad.age = character.Age;
        saveLoad.ageText = character.AgeText;
        saveLoad.background = character.Background;
        saveLoad.bonusBack = character.BonusBack;
        saveLoad.carryWeight = character.CarryWeight;
        saveLoad.constitution = character.Constitution;
        saveLoad.corruptionPoints = character.CorruptionPoints;
        saveLoad.experienceSpent = character.ExperienceSpent;
        saveLoad.experienceTotal = character.ExperienceTotal;
        saveLoad.experienceUnspent = character.ExperienceUnspent;
        saveLoad.eyes = character.Eyes;
        saveLoad.fatePoint = character.FatePoint;
        saveLoad.fatigue = character.Fatigue;
        saveLoad.fullMove = character.FullMove;
        saveLoad.gender = character.Gender;
        saveLoad.hair = character.Hair;
        saveLoad.halfMove = character.HalfMove;
        saveLoad.homeworld = character.Homeworld;
        saveLoad.insanityPoints = character.InsanityPoints;
        saveLoad.liftWeight = character.LiftWeight;
        saveLoad.memoryOfBackground = character.MemoryOfBackground;
        saveLoad.memoryOfHome = character.MemoryOfHome;
        saveLoad.name = character.Name;
        saveLoad.natisk = character.Natisk;
        saveLoad.physFeatures = character.PhysFeatures;
        saveLoad.prophecy = character.Prophecy;
        saveLoad.psyRating = character.PsyRating;
        saveLoad.pushWeight = character.PushWeight;
        saveLoad.role = character.Role;
        saveLoad.run = character.Run;
        saveLoad.skeen = character.Skeen;
        saveLoad.wounds = character.Wounds;
        saveLoad.elite = character.Elite;
        saveLoad.tradition = character.Tradition;

        saveLoad.talents = "";
        foreach (Talent talent in character.Talents)
        {
            saveLoad.talents += talent.Name;
            saveLoad.talents += "/";
        }
        saveLoad.talents = DeleteLastChar(saveLoad.talents);

        saveLoad.mentalDisorders = "";
        foreach (string mental in character.MentalDisorders)
        {
            saveLoad.mentalDisorders += mental;
            saveLoad.mentalDisorders += "/";
        }
        saveLoad.mentalDisorders = DeleteLastChar(saveLoad.mentalDisorders);

        saveLoad.mutation = "";
        foreach (string mutation in character.Mutation)
        {
            saveLoad.mutation += mutation;
            saveLoad.mutation += "/";
        }
        saveLoad.mutation = DeleteLastChar(saveLoad.mutation);

        saveLoad.implants = "";
        foreach (MechImplant implant in character.Implants)
        {
            saveLoad.implants += implant.Name;
            saveLoad.implants += "/";
        }
        saveLoad.implants = DeleteLastChar(saveLoad.implants);

        saveLoad.psyPowers = "";
        foreach (PsyPower psyPower in character.PsyPowers)
        {
            saveLoad.psyPowers += psyPower.NamePower;
            saveLoad.psyPowers += "/";
        }
        saveLoad.psyPowers = DeleteLastChar(saveLoad.psyPowers);

        saveLoad.inclinations = "";
        foreach (GameStat.Inclinations inclination in character.Inclinations)
        {
            saveLoad.inclinations += inclination.ToString();
            saveLoad.inclinations += "/";
        }
        saveLoad.inclinations = DeleteLastChar(saveLoad.inclinations);

        saveLoad.features = "";
        saveLoad.featuresLvl = "";
        foreach(Feature feature in character.Features)
        {
            saveLoad.features += feature.Name;
            saveLoad.features += "/";
            saveLoad.featuresLvl += feature.Lvl;
            saveLoad.featuresLvl += "/";
        }
        saveLoad.features = DeleteLastChar(saveLoad.features); 
        saveLoad.featuresLvl = DeleteLastChar(saveLoad.featuresLvl); 

        data.Add(JsonUtility.ToJson(saveLoad,true));

        foreach(Characteristic characteristic in character.Characteristics)
        {
            SaveLoadCharacteristic saveCharacteristic = new SaveLoadCharacteristic();
            saveCharacteristic.name = characteristic.Name;
            saveCharacteristic.amount = characteristic.Amount;
            saveCharacteristic.lvlLearnedChar = characteristic.LvlLearned;
            data.Add(JsonUtility.ToJson(saveCharacteristic,true));
        }

        foreach(Skill skill in character.Skills)
        {
            SaveLoadSkill saveSkill = new SaveLoadSkill();
            saveSkill.name = skill.Name;
            saveSkill.lvlLearned = skill.LvlLearned;
            data.Add(JsonUtility.ToJson(saveSkill, true));
        }

        foreach(Equipment equipment in character.Equipments)
        {
            if(equipment.TypeEq == Equipment.TypeEquipment.Armor)
            {
                Debug.Log($"Сохраняем броню {equipment.ClearName}");
                JSONArmorReader armorReader = new JSONArmorReader();
                Armor armor = (Armor)equipment;
                armorReader.amount = armor.Amount;
                armorReader.armorPoint = armor.ArmorPoint;
                armorReader.body = armor.DefBody;
                armorReader.description = armor.Description;
                armorReader.descriptionArmor = armor.PlaceArmor;
                armorReader.hands = armor.DefHands;
                armorReader.head = armor.DefHead;
                armorReader.legs = armor.DefLegs;
                armorReader.maxAgility = armor.MaxAgil;
                armorReader.name = armor.ClearName;
                armorReader.typeEquipment = armor.TypeEq.ToString(); ;
                armorReader.weight = armor.Weight;
                data.Add(JsonUtility.ToJson(armorReader, true));
            }
            else if(equipment.TypeEq == Equipment.TypeEquipment.Grenade)
            {
                Debug.Log($"Сохраняем гранату {equipment.ClearName}");
                JSONGrenadeReader grenadeReader = new JSONGrenadeReader();
                Weapon grenade = (Weapon)equipment;
                grenadeReader.amount = grenade.Amount;
                grenadeReader.damage = grenade.Damage;
                grenadeReader.description = grenade.Description;
                grenadeReader.name = grenade.ClearName;
                grenadeReader.penetration = grenade.Penetration;
                grenadeReader.properties = grenade.Properties;
                grenadeReader.rarity = grenade.Rarity;
                grenadeReader.typeEquipment = grenade.TypeEq.ToString();
                grenadeReader.weaponClass = grenade.ClassWeapon;
                grenadeReader.weight = grenade.Weight;
                data.Add(JsonUtility.ToJson(grenadeReader, true));
            }
            else if (equipment.TypeEq == Equipment.TypeEquipment.Melee)
            {
                Debug.Log($"Сохраняем ближний {equipment.ClearName}");
                JSONMeleeReader meleeReader = new JSONMeleeReader();
                Weapon melee = (Weapon)equipment;
                meleeReader.amount = melee.Amount;
                meleeReader.damage = melee.Damage;
                meleeReader.description = melee.Description;
                meleeReader.name = melee.ClearName;
                meleeReader.penetration = melee.Penetration;
                meleeReader.properties = melee.Properties;
                meleeReader.rarity = melee.Rarity;
                meleeReader.typeEquipment = melee.TypeEq.ToString();
                meleeReader.type = melee.TypeEq.ToString();
                meleeReader.weaponClass = melee.ClassWeapon;
                meleeReader.weight = melee.Weight;
                data.Add(JsonUtility.ToJson(meleeReader, true));
            }
            else if (equipment.TypeEq == Equipment.TypeEquipment.Range)
            {
                Debug.Log($"Сохраняем дальнюю {equipment.ClearName}");
                JSONRangeReader rangeReader = new JSONRangeReader();
                Weapon range = (Weapon)equipment;
                rangeReader.amount = range.Amount;
                rangeReader.damage = range.Damage;
                rangeReader.description = range.Description;
                rangeReader.name = range.ClearName;
                rangeReader.penetration = range.Penetration;
                rangeReader.properties = range.Properties;
                rangeReader.rarity = range.Rarity;
                rangeReader.typeEquipment = range.TypeEq.ToString();
                rangeReader.weaponClass = range.ClassWeapon;
                rangeReader.weight = range.Weight;
                rangeReader.clip = range.Clip;
                rangeReader.range = range.Range;
                rangeReader.reload = range.Reload;
                rangeReader.rof = range.Rof;
                data.Add(JsonUtility.ToJson(rangeReader, true));
            }
            else if (equipment.TypeEq == Equipment.TypeEquipment.Thing)
            {
                Debug.Log($"Сохраняем вещь {equipment.ClearName}");
                JSONEquipmentReader equipmentReader = new JSONEquipmentReader();
                equipmentReader.amount = equipment.Amount;
                equipmentReader.description = equipment.Description;
                equipmentReader.name = equipment.ClearName;
                equipmentReader.rarity = equipment.Rarity;
                equipmentReader.typeEquipment = equipment.TypeEq.ToString();
                equipmentReader.weight = equipment.Weight;
                data.Add(JsonUtility.ToJson(equipmentReader, true));
            }
        }

        File.WriteAllLines(path, data);
    }

    private string DeleteLastChar(string text)
    {
        if(text.Length > 0)
        {
            string tex = text.TrimEnd('/');
            return tex;
        }
        else
        {
            return text;
        }  
        
    }
}
