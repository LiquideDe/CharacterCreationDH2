using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Equipment
{
    private string classWeapon, rof, damage, reload, properties;
    private int range, penetration, clip, weight;

    public string ClassWeapon { get => classWeapon; }
    public int Range { get => range; }
    public string Rof { get => rof; }
    public string Damage { get => damage; }
    public int Penetration { get => penetration;  }
    public int Clip { get => clip; }
    public string Reload { get => reload;  }
    public string Properties { get => properties; }
    public int Weight { get => weight; }

    public Weapon(JSONRangeReader rangeReader) :base(rangeReader.name, rangeReader.description)
    {
        typeEquipment = TypeEquipment.Weapon;
        classWeapon = rangeReader.weaponClass;
        range = rangeReader.range;
        rof = rangeReader.rof;
        damage = rangeReader.damage;
        penetration = rangeReader.penetration;
        clip = rangeReader.clip;
        reload = rangeReader.reload;
        properties = rangeReader.properties;
        weight = rangeReader.weight;
    }

    public Weapon(JSONMeleeReader meleeReader) : base(meleeReader.name, meleeReader.description)
    {
        typeEquipment = TypeEquipment.Weapon;
        classWeapon = meleeReader.weaponClass;
        damage = meleeReader.damage;
        penetration = meleeReader.penetration;
        properties = meleeReader.properties;
        weight = meleeReader.weight;
        rof = "";
    }
}
