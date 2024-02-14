using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : Equipment
{
    private int defHead, defHands, defBody, defLegs, maxAgil, armorPoint;
    private string placeArmor;
    public Armor(JSONArmorReader armorReader) : base (armorReader.name, armorReader.description, armorReader.rarity,armorReader.weight)
    {
        typeEquipment = TypeEquipment.Armor;
        defHead = armorReader.head;
        defHands = armorReader.hands;
        defBody = armorReader.body;
        defLegs = armorReader.legs;
        maxAgil = armorReader.maxAgility;
        placeArmor = armorReader.descriptionArmor;
        armorPoint = armorReader.armorPoint;
    }

    public int DefHead { get => defHead; }
    public int DefHands { get => defHands; }
    public int DefBody { get => defBody; }
    public int DefLegs { get => defLegs; }
    public int MaxAgil { get => maxAgil;  }
    public string PlaceArmor { get => placeArmor; }
    public int ArmorPoint { get => armorPoint; }
}
