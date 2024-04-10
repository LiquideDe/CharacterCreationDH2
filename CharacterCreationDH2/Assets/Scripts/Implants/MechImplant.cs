using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechImplant
{
    public enum PartsOfBody { Head, RightHand, LeftHand, Body, RightLeg, LeftLeg, All};
    private string name;
    private string textDescription;
    public PartsOfBody Place { get; set; }
    public int Armor { get; set; }
    public string Name { get { return name; } }
    public string Description { get { return textDescription; } set => textDescription = value; }
    public int BonusToughness { get; set; }

    public MechImplant(string name, string textDescription)
    {
        this.name = name;
        this.textDescription = textDescription;
    }

    public MechImplant(string name)
    {
        this.name = name;
    }

    public MechImplant(string name, PartsOfBody place, int armor, string description, int bonusToughness)
    {
        this.name = name;
        Place = place;
        Armor = armor;
        textDescription = description;
        BonusToughness = bonusToughness;
    }

    public MechImplant(ImplantSaveLoad implantSave)
    {
        name = implantSave.name;
        Place = (PartsOfBody)Enum.Parse(typeof(PartsOfBody),implantSave.partsOfBody);
        Armor = implantSave.armor;
        textDescription = implantSave.description;
        BonusToughness = implantSave.bonusToughness;
    }

}
