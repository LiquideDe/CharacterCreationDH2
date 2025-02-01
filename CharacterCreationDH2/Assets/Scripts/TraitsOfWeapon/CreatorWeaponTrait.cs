using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CreatorWeaponTrait
{
    public event Action TraitsIsCreated;
    List<WeaponTrait> _weaponTraits = new List<WeaponTrait>();
    private AudioManager _audioManager;
    public List<WeaponTrait> Traits => _weaponTraits; 

    public CreatorWeaponTrait(AudioManager audioManager) => _audioManager = audioManager;

    public void StartCreating() => _audioManager.StartCoroutine(CreateTraitsCoroutine());

    public WeaponTrait GetTrait(string name)
    {
        foreach (WeaponTrait trait in _weaponTraits)
        {
            if (string.Compare(name, trait.Name, true) == 0)
                return trait;
        }

        Debug.Log($"Не смогли найти weaponTrait {name}");
        return null;
    }

    public List<string> GetNames()
    {
        var names = new List<string>();
        foreach (var item in _weaponTraits)
        {
            names.Add(item.Name);
        }
        return names;
    }

    public WeaponTrait Get(string name)
    {
        foreach (var item in _weaponTraits)
        {
            if(string.Compare(item.Name, name, true) == 0)
                return item;
        }

        Debug.Log($"Не нашли WeaponTrait {name}");
        return null;
    }

    private IEnumerator CreateTraitsCoroutine()
    {
        List<string> dirs = new List<string>();
        dirs.AddRange(Directory.GetDirectories($"{Application.dataPath}/StreamingAssets/Equipments/WeaponTraits"));
        foreach (string path in dirs)
        {
            _weaponTraits.Add(new WeaponTrait(GameStat.ReadText(path + "/Название.txt"), GameStat.ReadText(path + "/Описание.txt")));
            yield return null;
        }
        TraitsIsCreated?.Invoke();
    }

    
}
