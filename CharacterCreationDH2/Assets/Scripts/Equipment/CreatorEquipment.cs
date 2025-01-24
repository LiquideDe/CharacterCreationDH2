using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System;

public class CreatorEquipment
{
    public event Action ThingIsDone;
    public event Action ArmorIsDone;
    public event Action MeleeIsDone;
    public event Action RangeIsDone;
    public event Action GrenadeIsDone;
    public event Action SpecialIsDone;

    private AudioManager _audioManager;
    private List<Equipment> equipments = new List<Equipment>();

    public List<Equipment> Equipments  => equipments; 

    public CreatorEquipment(AudioManager audioManager) => _audioManager = audioManager;

    public void StartCreating()
    {
        _audioManager.StartCoroutine(AddThingCoroutine());
        _audioManager.StartCoroutine(AddArmorCoroutine());
        _audioManager.StartCoroutine(AddMeleeCoroutine());
        _audioManager.StartCoroutine(AddRangeCoroutine());
        _audioManager.StartCoroutine(AddGrenadeCoroutine());
        _audioManager.StartCoroutine(AddSpecialCoroutine());
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

    public void AddEquipment(Equipment equipment)
    {
        equipments.Add(equipment);
    }

    private IEnumerator AddThingCoroutine()
    {
        string[] things = Directory.GetFiles($"{Application.dataPath}/StreamingAssets/Equipments" + "/Things", "*.JSON");
        foreach (string thing in things)
        {
            string[] data = File.ReadAllLines(thing);
            JSONEquipmentReader equipmentReader = JsonUtility.FromJson<JSONEquipmentReader>(data[0]);
            equipments.Add(new Equipment(equipmentReader.name, equipmentReader.description, equipmentReader.rarity, equipmentReader.amount, equipmentReader.weight));
            yield return null;
        }
        ThingIsDone?.Invoke();
    }

    private IEnumerator AddArmorCoroutine()
    {
        string[] armors = Directory.GetFiles($"{Application.dataPath}/StreamingAssets/Equipments" + "/Armor", "*.JSON");
        foreach (string armor in armors)
        {
            string[] data = File.ReadAllLines(armor);
            JSONArmorReader armortReader = JsonUtility.FromJson<JSONArmorReader>(data[0]);
            equipments.Add(new Armor(armortReader));
            yield return null;
        }
        ArmorIsDone?.Invoke();
    }

    private IEnumerator AddMeleeCoroutine()
    {
        string[] meleeWeapons = Directory.GetFiles($"{Application.dataPath}/StreamingAssets/Equipments" + "/Weapons/Melee", "*.JSON");
        foreach (string melee in meleeWeapons)
        {
            string[] data = File.ReadAllLines(melee);
            JSONMeleeReader meleeReader = JsonUtility.FromJson<JSONMeleeReader>(data[0]);
            equipments.Add(new Weapon(meleeReader));
            yield return null;
        }
        MeleeIsDone?.Invoke();
    }

    private IEnumerator AddRangeCoroutine()
    {
        string[] rangeWeapons = Directory.GetFiles($"{Application.dataPath}/StreamingAssets/Equipments" + "/Weapons/Range", "*.JSON");
        foreach (string range in rangeWeapons)
        {
            string[] data = File.ReadAllLines(range);
            JSONRangeReader rangeReader = JsonUtility.FromJson<JSONRangeReader>(data[0]);
            equipments.Add(new Weapon(rangeReader));
            yield return null;
        }
        RangeIsDone?.Invoke();
    }

    private IEnumerator AddGrenadeCoroutine()
    {
        string[] grenadeWeapons = Directory.GetFiles($"{Application.dataPath}/StreamingAssets/Equipments" + "/Weapons/Grenade", "*.JSON");
        foreach (string grenade in grenadeWeapons)
        {
            string[] data = File.ReadAllLines(grenade);
            JSONGrenadeReader grenadeReader = JsonUtility.FromJson<JSONGrenadeReader>(data[0]);
            equipments.Add(new Weapon(grenadeReader));
            yield return null;
        }
        GrenadeIsDone?.Invoke();
    }

    private IEnumerator AddSpecialCoroutine()
    {
        string[] specialWeapons = Directory.GetFiles($"{Application.dataPath}/StreamingAssets/Equipments" + "/Special", "*.JSON");
        foreach (string special in specialWeapons)
        {
            string[] data = File.ReadAllLines(special);
            JSONSpecialReader specialReader = JsonUtility.FromJson<JSONSpecialReader>(data[0]);
            equipments.Add(new Special(specialReader));
            yield return null;
        }
        SpecialIsDone?.Invoke();
    }
}
