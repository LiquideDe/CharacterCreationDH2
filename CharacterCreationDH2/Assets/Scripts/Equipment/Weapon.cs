using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Equipment
{
    private string classWeapon, rof, damage, reload, properties;
    private int range, penetration, clip;

    public string ClassWeapon { get => classWeapon; }
    public int Range { get => range; }
    public string Rof { get => rof; }
    public string Damage { get => damage; }
    public int Penetration { get => penetration;  }
    public int Clip { get => clip; }
    public string Reload { get => reload;  }
    public string Properties { get => properties; }

    public Weapon(JSONRangeReader rangeReader) :base(rangeReader.name, rangeReader.description, rangeReader.rarity, rangeReader.weight)
    {
        typeEquipment = TypeEquipment.Range;
        classWeapon = rangeReader.weaponClass;
        range = rangeReader.range;
        rof = rangeReader.rof;
        damage = rangeReader.damage;
        penetration = rangeReader.penetration;
        clip = rangeReader.clip;
        reload = rangeReader.reload;
        properties = rangeReader.properties;
    }

    public Weapon(JSONMeleeReader meleeReader) : base(meleeReader.name, meleeReader.description, meleeReader.rarity, meleeReader.weight)
    {
        typeEquipment = TypeEquipment.Melee;
        classWeapon = meleeReader.weaponClass;
        damage = meleeReader.damage;
        penetration = meleeReader.penetration;
        properties = meleeReader.properties;
        rof = "";
    }

    public Weapon(JSONGrenadeReader grenadeReader) : base (grenadeReader.name, grenadeReader.description, grenadeReader.rarity, grenadeReader.weight)
    {
        typeEquipment = TypeEquipment.Grenade;
        classWeapon = grenadeReader.weaponClass;
        damage = grenadeReader.damage;
        penetration = grenadeReader.penetration;
        properties = grenadeReader.properties;
    }
}
