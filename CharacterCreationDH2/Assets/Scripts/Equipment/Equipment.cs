using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : IName
{
    private string nameEquipment, description, rarity;
    private float weight;
    private int amount;
    public enum TypeEquipment
    {
        Thing, Melee, Range, Armor, Special, Grenade
    }
    protected TypeEquipment typeEquipment;
    public Equipment(string nameEquipment, string description, string rarity, int amount=1, float weight = 0)
    {
        this.nameEquipment = nameEquipment;
        this.description = description;
        typeEquipment = TypeEquipment.Thing;
        this.weight = weight;
        this.rarity = rarity;
        this.amount = amount;
    }

    public string Name { get => GetName(); }
    public string ClearName { get => nameEquipment; }
    public string Description { get => description; }
    public TypeEquipment TypeEq { get => typeEquipment; }
    public float Weight { get => weight; }
    public string Rarity { get => rarity; }
    public int Amount { get => amount; set => amount = value; }

    private string GetName()
    {
        if(amount < 2)
        {
            return nameEquipment;
        }

        return $"{nameEquipment}-{amount} רע.";
    }
}
