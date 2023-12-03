using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Equipment
{
    private string classWeapon, rof, damage, penetration, clip, reload, properties, weight;
    private int range;

    public string ClassWeapon { get => classWeapon; }
    public int Range { get => range; }
    public string Rof { get => rof; }
    public string Damage { get => damage; }
    public string Penetration { get => penetration;  }
    public string Clip { get => clip; }
    public string Reload { get => reload;  }
    public string Properties { get => properties; }
    public string Weight { get => weight; }

    public Weapon(string nameEquipment, string description, string classWeapon, int range, string rof, string damage,
        string penetration, string clip, string reload, string properties, string weight) :base(nameEquipment, description)
    {
        typeEquipment = TypeEquipment.Weapon;
        this.classWeapon = classWeapon;
        this.range = range;
        this.rof = rof;
        this.damage = damage;
        this.penetration = penetration;
        this.clip = clip;
        this.reload = reload;
        this.properties = properties;
        this.weight = weight;
    }

    public Weapon(string nameEquipment, string description, string classWeapon, string damage, string penetration,
        string properties, string weight) : base(nameEquipment, description)
    {
        typeEquipment = TypeEquipment.Weapon;
        this.classWeapon = classWeapon;
        this.damage = damage;
        this.penetration = penetration;
        this.properties = properties;
        this.weight = weight;
        rof = "";
    }
}
