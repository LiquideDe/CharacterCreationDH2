using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment
{
    private string nameEquipment, description;
    public enum TypeEquipment
    {
        Thing, Weapon, Armor, Special
    }
    protected TypeEquipment typeEquipment;
    public Equipment(string nameEquipment, string description)
    {
        this.nameEquipment = nameEquipment;
        this.description = description;
        typeEquipment = TypeEquipment.Thing;
    }

    public string Name { get => nameEquipment; }
    public string Description { get => description; }
    public TypeEquipment TypeEq { get => typeEquipment; }
}
