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
        saveLoad.homeworld = character.HomeWorld;
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

        saveLoad.equipments = "";
        foreach (Equipment equipment in character.Equipments)
        {
            saveLoad.equipments += equipment.Name;
            saveLoad.equipments += "/";
        }
        saveLoad.equipments = DeleteLastChar(saveLoad.equipments);

        saveLoad.implants = "";
        foreach (MechImplants implant in character.Implants)
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

        data.Add(JsonUtility.ToJson(saveLoad));

        foreach(Characteristic characteristic in character.Characteristics)
        {
            SaveLoadCharacteristic saveCharacteristic = new SaveLoadCharacteristic();
            saveCharacteristic.name = characteristic.Name;
            saveCharacteristic.amount = characteristic.Amount;
            saveCharacteristic.lvlLearnedChar = characteristic.LvlLearned;
            data.Add(JsonUtility.ToJson(saveCharacteristic));
        }

        foreach(Skill skill in character.Skills)
        {
            SaveLoadSkill saveSkill = new SaveLoadSkill();
            saveSkill.name = skill.Name;
            saveSkill.lvlLearned = skill.LvlLearned;
            data.Add(JsonUtility.ToJson(saveSkill));
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
