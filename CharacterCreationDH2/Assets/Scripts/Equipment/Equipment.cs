using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment
{
    private string nameEquipment, description;
    private float weight;
    public enum TypeEquipment
    {
        Thing, Melee, Range, Armor, Special
    }
    protected TypeEquipment typeEquipment;
    public Equipment(string nameEquipment, string description, float weight = 0)
    {
        this.nameEquipment = nameEquipment;
        this.description = description;
        typeEquipment = TypeEquipment.Thing;
        this.weight = weight;
    }

    public string Name { get => nameEquipment; }
    public string Description { get => description; }
    public TypeEquipment TypeEq { get => typeEquipment; }
    public float Weight { get => weight; }
}
