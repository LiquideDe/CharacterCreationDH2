using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : IName
{
    private string nameEquipment, description, rarity;
    private float weight;
    public enum TypeEquipment
    {
        Thing, Melee, Range, Armor, Special, Grenade
    }
    protected TypeEquipment typeEquipment;
    public Equipment(string nameEquipment, string description, string rarity, float weight = 0)
    {
        this.nameEquipment = nameEquipment;
        this.description = description;
        typeEquipment = TypeEquipment.Thing;
        this.weight = weight;
        this.rarity = rarity;
    }

    public string Name { get => nameEquipment; }
    public string Description { get => description; }
    public TypeEquipment TypeEq { get => typeEquipment; }
    public float Weight { get => weight; }
    public string Rarity { get => rarity; }
}
