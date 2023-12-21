using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : Equipment
{
    private int defHead, defHands, defBody, defLegs, maxAgil, weight;
    private string placeArmor;
    public Armor(JSONArmorReader armorReader) : base (armorReader.name, armorReader.description)
    {
        typeEquipment = TypeEquipment.Armor;
        defHead = armorReader.head;
        defHands = armorReader.hands;
        defBody = armorReader.body;
        defLegs = armorReader.legs;
        maxAgil = armorReader.maxAgility;
        weight = armorReader.weight;
        placeArmor = armorReader.descriptionArmor;
    }

    public int DefHead { get => defHead; }
    public int DefHands { get => defHands; }
    public int DefBody { get => defBody; }
    public int DefLegs { get => defLegs; }
    public int MaxAgil { get => maxAgil;  }
    public int Weight { get => weight;}
    public string PlaceArmor { get => placeArmor; }
}
