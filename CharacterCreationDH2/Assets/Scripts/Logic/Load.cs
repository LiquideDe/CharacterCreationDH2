using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Load
{
    public void LoadCharacter(Character character, string path)
    {
        //var path = $"{Application.dataPath}/StreamingAssets/CharacterSheets//.JSON";
        string[] data = File.ReadAllLines(path);

        SaveLoadCharacter loadCharacter = JsonUtility.FromJson<SaveLoadCharacter>(data[0]);

        List<SaveLoadCharacteristic> characteristics = new List<SaveLoadCharacteristic>();
        for (int i = 1; i < character.Characteristics.Count + 1; i++)
        {
            SaveLoadCharacteristic characteristic = JsonUtility.FromJson<SaveLoadCharacteristic>(data[i]);
            characteristics.Add(characteristic);
        }

        List<SaveLoadSkill> skills = new List<SaveLoadSkill>();
        for(int i = 1 + character.Characteristics.Count + 1; i < data.Length; i++)
        {
            SaveLoadSkill skill = JsonUtility.FromJson<SaveLoadSkill>(data[i]);
            skills.Add(skill);
        }

        character.LoadData(loadCharacter, characteristics, skills);
    }

}