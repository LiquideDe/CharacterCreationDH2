using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CreatorEquipment
{
    private List<Equipment> equipments = new List<Equipment>();
    public CreatorEquipment()
    {
        string[] things = Directory.GetFiles($"{Application.dataPath}/StreamingAssets/Equipments" + "/Things", "*.JSON");
        foreach(string thing in things)
        {
            string[] data = File.ReadAllLines(thing);
            JSONEquipmentReader equipmentReader = JsonUtility.FromJson<JSONEquipmentReader>(data[0]);
            equipments.Add(new Equipment(equipmentReader.name, equipmentReader.description));
        }

        string[] armors = Directory.GetFiles($"{Application.dataPath}/StreamingAssets/Equipments" + "/Armor", "*.JSON");
        foreach (string armor in armors)
        {
            string[] data = File.ReadAllLines(armor);
            JSONArmorReader armortReader = JsonUtility.FromJson<JSONArmorReader>(data[0]);
            equipments.Add(new Armor(armortReader));
        }

        string[] meleeWeapons = Directory.GetFiles($"{Application.dataPath}/StreamingAssets/Equipments" + "/Weapons/Melee", "*.JSON");
        foreach(string melee in meleeWeapons)
        {
            string[] data = File.ReadAllLines(melee);
            JSONMeleeReader meleeReader = JsonUtility.FromJson<JSONMeleeReader>(data[0]);
            equipments.Add(new Weapon(meleeReader));
        }

        string[] rangeWeapons = Directory.GetFiles($"{Application.dataPath}/StreamingAssets/Equipments" + "/Weapons/Range", "*.JSON");
        foreach (string range in rangeWeapons)
        {
            string[] data = File.ReadAllLines(range);
            JSONRangeReader rangeReader = JsonUtility.FromJson<JSONRangeReader>(data[0]);
            equipments.Add(new Weapon(rangeReader));
        }

        string[] specialWeapons = Directory.GetFiles($"{Application.dataPath}/StreamingAssets/Equipments" + "/Special", "*.JSON");
        foreach(string special in specialWeapons)
        {
            string[] data = File.ReadAllLines(special);
            JSONSpecialReader specialReader = JsonUtility.FromJson<JSONSpecialReader>(data[0]);
            equipments.Add(new Special(specialReader));
        }
    }

    public Equipment GetEquipment(string nameEq)
    {
        foreach(Equipment equipment in equipments)
        {
            if(string.Compare(nameEq, equipment.Name, true) == 0)
            {
                return equipment;
            }
        }
        Debug.Log($"!!!!ВНИМАНИЕ!!!! Не нашли экипировку {nameEq}");
        return null;
    }
}
