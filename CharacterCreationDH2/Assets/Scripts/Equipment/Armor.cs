using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : Equipment
{
    private int defHead, defHands, defBody, defLegs, maxAgil, armorPoint, bonusStrength;
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
        bonusStrength = armorReader.bonusStrength;
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
        bonusStrength = armor.BonusStrength;
    }

    public int DefHead => defHead; 
    public int DefHands => defHands; 
    public int DefBody => defBody;
    public int DefLegs => defLegs;
    public int MaxAgil => maxAgil;
    public string PlaceArmor => placeArmor; 
    public int ArmorPoint => armorPoint;

    public int BonusStrength => bonusStrength;
}
