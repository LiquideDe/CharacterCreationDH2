using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Load
{
    public void LoadCharacter(Character character, string path)
    {
        //var path = $"{Application.dataPath}/StreamingAssets/CharacterSheets//.JSON";

        string[] jsonFile = Directory.GetFiles(path,"*.JSON");
        string allText = File.ReadAllText(jsonFile[0]);
        //string[] data = File.ReadAllLines(path);
        allText = allText.Replace(Environment.NewLine, string.Empty);
        string[] data = allText.Split(new[] {'{','}' }, StringSplitOptions.RemoveEmptyEntries);

        for(int i = 0; i < data.Length; i++)
        {
            data[i] = $"{{ {data[i]} }}";
        }

        SaveLoadCharacter loadCharacter = JsonUtility.FromJson<SaveLoadCharacter>(data[0]);

        List<SaveLoadCharacteristic> characteristics = new List<SaveLoadCharacteristic>();
        int min = 1;
        int max = character.Characteristics.Count + min;
        for (int i = min; i < max; i++)
        {
            SaveLoadCharacteristic characteristic = JsonUtility.FromJson<SaveLoadCharacteristic>(data[i]);
            characteristics.Add(characteristic);
        }
        //Debug.Log($"Первый объект Характеристика {data[min]}, последний объект {data[max-1]}, min = {min}, max = {max}");

        List<SaveLoadSkill> skills = new List<SaveLoadSkill>();
        min = character.Characteristics.Count + 1;
        max = min + loadCharacter.amountSkills;
        for (int i = min; i < max; i++)
        {
            SaveLoadSkill skill = JsonUtility.FromJson<SaveLoadSkill>(data[i]);
            skills.Add(skill);
        }
        //Debug.Log($"Первый объект Навык {data[min]}, последний объект {data[max-1]}, min = {min}, max = {max}");

        List<MechImplant> implants = new List<MechImplant>();
        if (loadCharacter.amountImplants > 0)
        {
            
            min = max;
            max = min + loadCharacter.amountImplants;
            //Debug.Log($"Первый Имплант {data[min]}, последний объект {data[max - 1]}, min = {min}, max = {max}");
            for (int i = min; i < max; i++)
            {
                SaveLoadImplant implant = JsonUtility.FromJson<SaveLoadImplant>(data[i]);
                implants.Add(new MechImplant(implant));
            }
        }
        

        List<Equipment> equipments = new List<Equipment>();       
        for(int i = max; i < data.Length; i++)
        {
            JSONTypeReader typeReader = JsonUtility.FromJson<JSONTypeReader>(data[i]);
            if (typeReader.typeEquipment == Equipment.TypeEquipment.Thing.ToString())
            {
                JSONEquipmentReader jSONSmall = JsonUtility.FromJson<JSONEquipmentReader>(data[i]);
                equipments.Add(new Equipment(jSONSmall.name, jSONSmall.description, jSONSmall.rarity, jSONSmall.amount, jSONSmall.weight));
            }
            else if (typeReader.typeEquipment == Equipment.TypeEquipment.Melee.ToString())
            {
                JSONMeleeReader meleeReader = JsonUtility.FromJson<JSONMeleeReader>(data[i]);
                equipments.Add(new Weapon(meleeReader));
            }
            else if (typeReader.typeEquipment == Equipment.TypeEquipment.Range.ToString())
            {
                JSONRangeReader rangeReader = JsonUtility.FromJson<JSONRangeReader>(data[i]);
                equipments.Add(new Weapon(rangeReader));
            }
            else if (typeReader.typeEquipment == Equipment.TypeEquipment.Grenade.ToString())
            {
                JSONGrenadeReader grenadeReader = JsonUtility.FromJson<JSONGrenadeReader>(data[i]);
                equipments.Add(new Weapon(grenadeReader));
            }
            else if (typeReader.typeEquipment == Equipment.TypeEquipment.Armor.ToString())
            {
                JSONArmorReader armorReader = JsonUtility.FromJson<JSONArmorReader>(data[i]);
                equipments.Add(new Armor(armorReader));
            }
        }

        character.LoadData(loadCharacter, characteristics, skills, implants,equipments);
    }

}

