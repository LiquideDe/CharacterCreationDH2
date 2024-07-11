using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CreatorWeaponProperties
{
    private List<string> _properties;

    public CreatorWeaponProperties()
    {
        _properties = new List<string>();
        _properties.AddRange(GameStat.ReadText($"{Application.dataPath}/StreamingAssets/Equipments/PropertiesOfWeapon.txt").Split(new char[] { '/' }).ToList());
    }

    public List<string> GetProperties() => _properties;
}
