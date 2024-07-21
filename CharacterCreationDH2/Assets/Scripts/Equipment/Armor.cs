using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : Equipment
{
    private int defHead, defHands, defBody, defLegs, maxAgil, armorPoint;
    private string placeArmor;
    public Armor(JSONArmorReader armorReader) : base (armorReader.name, armorReader.description, armorReader.rarity, armorReader.amount, armorReader.weight)
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

    public Armor(Armor armor) : base (armor.Name, armor.Description, armor.Rarity, armor.Amount, armor.Weight)
    {
        typeEquipment = armor.typeEquipment;
        defHead = armor.DefHead;
        defHands = armor.DefHands;
        defBody = armor.DefBody;
        defLegs = armor.DefLegs;
        maxAgil = armor.MaxAgil;
        placeArmor = armor.PlaceArmor;
        armorPoint = armor.ArmorPoint;
    }

    public int DefHead { get => defHead; }
    public int DefHands { get => defHands; }
    public int DefBody { get => defBody; }
    public int DefLegs { get => defLegs; }
    public int MaxAgil { get => maxAgil;  }
    public string PlaceArmor { get => placeArmor; }
    public int ArmorPoint { get => armorPoint; }
}
