using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : Equipment
{
    private int defHead, defHands, defBody, defLegs, maxAgil, weight;
    private string placeArmor;
    public Armor(string nameEquipment, string description, string placeArmor, int defHead, int defHands, int defBody, int defLegs, int maxAgil, int weight) : base (nameEquipment, description)
    {
        typeEquipment = TypeEquipment.Armor;
        this.defHead = defHead;
        this.defHands = defHands;
        this.defBody = defBody;
        this.defLegs = defLegs;
        this.maxAgil = maxAgil;
        this.weight = weight;
        this.placeArmor = placeArmor;
    }

    public int DefHead { get => defHead; }
    public int DefHands { get => defHands; }
    public int DefBody { get => defBody; }
    public int DefLegs { get => defLegs; }
    public int MaxAgil { get => maxAgil;  }
    public int Weight { get => weight;}
    public string PlaceArmor { get => placeArmor; }
}
